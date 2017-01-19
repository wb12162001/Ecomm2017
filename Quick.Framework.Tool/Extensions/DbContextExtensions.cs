﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using Quick.Framework.Tool;
using Quick.Framework.Tool.Entity;
using System.Data.Entity.Core.Metadata.Edm;

namespace Quick.Framework.Tool
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Adds an entity (if newly created) or update (if has non-default Id).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The db context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <remarks>
        /// Will not work for HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
        /// Will not work for composite keys.
        /// </remarks>
        public static T AddOrUpdate<T>(this DbContext context, T entity)
            where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (entity == null) throw new ArgumentNullException("entity");

            if (IsTransient(context, entity))
            {
                context.Set<T>().Add(entity);
            }
            else
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }

        /// <summary>
        /// Determines whether the specified entity is newly created (Id not specified).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is transient; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Will not work for HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
        /// Will not work for composite keys.
        /// </remarks>
        public static bool IsTransient<T>(this DbContext context, T entity)
            where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (entity == null) throw new ArgumentNullException("entity");

            var propertyInfo = FindPrimaryKeyProperty<T>(context);
            var propertyType = propertyInfo.PropertyType;
            //what's the default value for the type?
            var transientValue = propertyType.IsValueType ?
                Activator.CreateInstance(propertyType) : null;
            //is the pk the same as the default value (int == 0, string == null ...)
            return Equals(propertyInfo.GetValue(entity, null), transientValue);
        }
        /// <summary>
        /// Loads a stub entity (or actual entity if already loaded).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks>
        /// Will not work for composite keys.
        /// </remarks>
        public static T Load<T>(this DbContext context, object id)
             where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (id == null) throw new ArgumentNullException("id");

            var property = FindPrimaryKeyProperty<T>(context);
            //check to see if it's already loaded (slow if large numbers loaded)
            var entity = context.Set<T>().Local
                .FirstOrDefault(x => id.Equals(property.GetValue(x, null)));
            if (entity == null)
            {
                //it's not loaded, just create a stub with only primary key set
                entity = CreateEntity<T>(id, property);

                context.Set<T>().Attach(entity);
            }
            return entity;
        }

        /// <summary>
        /// Determines whether the specified entity is loaded from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is loaded; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Will not work for composite keys.
        /// </remarks>
        public static bool IsLoaded<T>(this DbContext context, object id)
            where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (id == null) throw new ArgumentNullException("id");

            var property = FindPrimaryKeyProperty<T>(context);
            //check to see if it's already loaded (slow if large numbers loaded)
            var entity = context.Set<T>().Local
                .FirstOrDefault(x => id.Equals(property.GetValue(x, null)));
            return entity != null;
        }

        /// <summary>
        /// Marks the reference navigation properties unchanged. 
        /// Use when adding a new entity whose references are known to be unchanged.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="entity">The entity.</param>
        public static void MarkReferencesUnchanged<T>(DbContext context, T entity)
            where T : class
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var objectSet = objectContext.CreateObjectSet<T>();
            var elementType = objectSet.EntitySet.ElementType;
            var navigationProperties = elementType.NavigationProperties;
            //the references
            var references = from navigationProperty in navigationProperties
                             let end = navigationProperty.ToEndMember
                             where end.RelationshipMultiplicity == RelationshipMultiplicity.ZeroOrOne ||
                             end.RelationshipMultiplicity == RelationshipMultiplicity.One
                             select navigationProperty.Name;
            //NB: We don't check Collections. EF wants to handle the object graph.

            var parentEntityState = context.Entry(entity).State;
            foreach (var navigationProperty in references)
            {
                //if it's modified but not loaded, don't need to touch it
                if (parentEntityState == EntityState.Modified &&
                    !context.Entry(entity).Reference(navigationProperty).IsLoaded)
                    continue;
                var propertyInfo = typeof(T).GetProperty(navigationProperty);
                var value = propertyInfo.GetValue(entity, null);
                context.Entry(value).State = EntityState.Unchanged;
            }
        }

        /// <summary>
        /// Merges a DTO into a new or existing entity attached/added to context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="dataTransferObject">The data transfer object. It must have a primary key property of the same name and type as the actual entity.</param>
        /// <returns></returns>
        /// <remarks>
        /// Will not work for composite keys.
        /// </remarks>
        public static T Merge<T>(this DbContext context, object dataTransferObject)
             where T : class
        {
            if (context == null) throw new ArgumentNullException("context");
            if (dataTransferObject == null) throw new ArgumentNullException("dataTransferObject");

            var property = FindPrimaryKeyProperty<T>(context);
            //find the id property of the dto
            var idProperty = dataTransferObject.GetType().GetProperty(property.Name);
            if (idProperty == null)
                throw new InvalidOperationException("Cannot find an id on the dataTransferObject");
            var id = idProperty.GetValue(dataTransferObject, null);
            //has the id been set (existing item) or not (transient)?
            var propertyType = property.PropertyType;
            var transientValue = propertyType.IsValueType ?
                Activator.CreateInstance(propertyType) : null;
            var isTransient = Equals(id, transientValue);
            T entity;
            if (isTransient)
            {
                //it's transient, just create a dummy
                entity = CreateEntity<T>(id, property);
                //if DatabaseGeneratedOption(DatabaseGeneratedOption.None) and no id, this errors
                context.Set<T>().Attach(entity);
            }
            else
            {
                //try to load from identity map or database
                entity = context.Set<T>().Find(id);
                if (entity == null)
                {
                    //could not find entity, assume assigned primary key
                    entity = CreateEntity<T>(id, property);
                    context.Set<T>().Add(entity);
                }
            }
            //copy the values from DTO onto the entry
            context.Entry(entity).CurrentValues.SetValues(dataTransferObject);
            return entity;
        }


        private static PropertyInfo FindPrimaryKeyProperty<T>(IObjectContextAdapter context)
            where T : class
        {
            //find the primary key
            var objectContext = context.ObjectContext;
            //this will error if it's not a mapped entity
            var objectSet = objectContext.CreateObjectSet<T>();
            var elementType = objectSet.EntitySet.ElementType;
            var pk = elementType.KeyMembers.First();
            //look it up on the entity
            var propertyInfo = typeof(T).GetProperty(pk.Name);
            return propertyInfo;
        }

        private static T CreateEntity<T>(object id, PropertyInfo property)
            where T : class
        {
            // consider IoC here
            var entity = (T)Activator.CreateInstance(typeof(T));
            //set the value of the primary key (may error if wrong type)
            property.SetValue(entity, id, null);
            return entity;
        }

        public static void Update<TEntity>(this DbContext dbContext, params TEntity[] entities) where TEntity : class//EntityBase<TKey>
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (TEntity entity in entities)
            {
                DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
                try
                {
                    DbEntityEntry<TEntity> entry = dbContext.Entry(entity);
                    if (entry.State == EntityState.Detached)
                    {
                        dbSet.Attach(entity);
                        entry.State = EntityState.Modified;
                    }
                }
                catch (InvalidOperationException exc)
                {
                    //TEntity oldEntity = dbSet.Find(entity.Id);
                    //dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);

                    throw new Exception("ObjectContext中已有相同键值对象 " + typeof(TEntity).Name + "：" + exc.Message);
                }
            }
        }
        /// <summary>
        /// 方法调用方式：
        ///db.Update<Member>(m => new { m.Password }, member);
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="propertyExpression"></param>
        /// <param name="entities"></param>
        public static void Update<TEntity>(this DbContext dbContext, Expression<Func<TEntity, object>> propertyExpression, params TEntity[] entities)
            where TEntity : class//EntityBase<TKey>
        {
            if (propertyExpression == null) throw new ArgumentNullException("propertyExpression");
            if (entities == null) throw new ArgumentNullException("entities");
            ReadOnlyCollection<MemberInfo> memberInfos = ((dynamic)propertyExpression.Body).Members;
            foreach (TEntity entity in entities)
            {
                DbSet<TEntity> dbSet = dbContext.Set<TEntity>();
                try
                {
                    //方法二; 可以成功
                    dbSet.Attach(entity);
                    var stateEntry = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
                    
                    foreach (var memberInfo in memberInfos)
                    {
                        stateEntry.SetModifiedProperty(memberInfo.Name);
                    }

                    /*
                    //方法一: 没有成功过???
                    DbEntityEntry<TEntity> entry = dbContext.Entry(entity);
                    entry.State = EntityState.Unchanged;
                    foreach (var memberInfo in memberInfos)
                    {
                        entry.Property(memberInfo.Name).IsModified = true;
                    }*/
                }
                catch (InvalidOperationException exc)
                {
                    //throw new Exception("ObjectContext中已有相同键值对象 " + typeof(TEntity).Name + "：" + exc.Message);
                    //TEntity originalEntity = dbSet.Local.Single(m => Equals(m.Id, entity.Id));
                    //ObjectContext objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                    //ObjectStateEntry objectEntry = objectContext.ObjectStateManager.GetObjectStateEntry(originalEntity);
                    //objectEntry.ApplyCurrentValues(entity);
                    //objectEntry.ChangeState(System.Data.EntityState.Unchanged);
                    //foreach (var memberInfo in memberInfos)
                    //{
                    //    objectEntry.SetModifiedProperty(memberInfo.Name);
                    //}
                }
            }
        }

        public static int SaveChanges(this DbContext dbContext, bool validateOnSaveEnabled)
        {
            bool isReturn = dbContext.Configuration.ValidateOnSaveEnabled != validateOnSaveEnabled;
            try
            {
                dbContext.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;
                return dbContext.SaveChanges();
            }
            finally
            {
                if (isReturn)
                {
                    dbContext.Configuration.ValidateOnSaveEnabled = !validateOnSaveEnabled;
                }
            }
        }
    }
}
