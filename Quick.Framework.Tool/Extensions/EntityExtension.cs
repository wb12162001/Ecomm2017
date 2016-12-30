namespace Quick.Framework.Tool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.ComponentModel.DataAnnotations;
    public static class EntityExtension
    {
        public static HashSet<Type> PrimitiveTypes = null;

        static EntityExtension()
        {
            PrimitiveTypes = new HashSet<Type>() 
                { 
                    typeof(String),
                    typeof(Byte[]),
                    typeof(Byte),
                    typeof(Int16),
                    typeof(Int32),
                    typeof(Int64),
                    typeof(Single),
                    typeof(Double),
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(Guid),
                    typeof(Boolean),
                    typeof(TimeSpan),
                    typeof(Byte?),
                    typeof(Int16?),
                    typeof(Int32?),
                    typeof(Int64?),
                    typeof(Single?),
                    typeof(Double?),
                    typeof(Decimal?),
                    typeof(DateTime?),
                    typeof(Guid?),
                    typeof(Boolean?),
                    typeof(TimeSpan?)
                };
        }



        public static string GetChangedFields<T>(this T newEntity, T oldEntity) where T : class
        {
            StringBuilder updatedFields = new StringBuilder();
            Type entityType = typeof(T);
            PropertyInfo[] properties = entityType.GetProperties().Where(o => o.CanWrite && PrimitiveTypes.Contains(o.PropertyType) && !o.GetCustomAttributes(false).OfType<NotMappedAttribute>().Any()).ToArray();
            foreach (var p in properties)
            {
                if (p.Name == "ModifiedDate" || p.Name == "ModifiedByName" || p.Name == "ModifiedById") continue;
                object oldValue = p.GetValue(oldEntity, null);
                object newValue = p.GetValue(newEntity, null);
                if ((oldValue == null && newValue == null))
                {
                    continue;
                }
                else if (oldValue == null && newValue != null || oldValue != null && newValue == null || !Eq(p.PropertyType, oldValue, newValue))
                {
                    string fieldName;
                    var display = p.GetCustomAttribute<DisplayAttribute>(false);
                    fieldName = display != null ? display.Name : p.Name;
                    // 2015-06-10 去掉LimitChangeType判断
                    //switch (p.Name)
                    //{
                    //    case "LimitChangeType":
                    //        updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue.ToString() == "1" ? "限制退改期" : "不限制退改期", newValue.ToString() == "1" ? "限制退改期" : "不限制退改期");
                    //        break;
                    //    default:
                    //        updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue ?? "NULL", newValue ?? "NULL");
                    //        break;
                    //}
                    updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue ?? "NULL", newValue ?? "NULL");
                }
            }

            return updatedFields.ToString();
        }

        public static string GetChangedProperty<T>(this T newEntity, T oldEntity) where T : class
        {
            StringBuilder updatedFields = new StringBuilder();
            Type entityType = typeof(T);
            PropertyInfo[] properties = entityType.GetProperties().Where(o => o.CanWrite && (PrimitiveTypes.Contains(o.PropertyType) || o.PropertyType.IsArray) && !o.GetCustomAttributes(false).OfType<NotMappedAttribute>().Any()).ToArray();
            foreach (var p in properties)
            {
                if (p.Name == "ModifiedDate" || p.Name == "ModifiedByName" || p.Name == "ModifiedById") continue;
                object oldValue = p.GetValue(oldEntity, null);
                object newValue = p.GetValue(newEntity, null);
                if ((oldValue == null && newValue == null))
                {
                    continue;
                }
                else if (oldValue == null && newValue != null || oldValue != null && newValue == null || !Eq(p.PropertyType, oldValue, newValue) || p.PropertyType.IsArray)
                {
                    string fieldName;
                    var display = p.GetCustomAttribute<DisplayAttribute>(false);
                    fieldName = display != null ? display.Name : p.Name;
                    if (p.PropertyType.IsArray)
                    {
                        var oldArray = (Array)oldValue;
                        var newArray = (Array)newValue;
                        StringBuilder oldSb = new StringBuilder("[ "), newSb = new StringBuilder("[ ");
                        if (oldArray != null)
                        {
                            foreach (var item in oldArray)
                            {
                                if (item.GetType().IsEnum)
                                {
                                    oldSb.Append(((Enum)item).ToDescription()).Append(",");
                                }
                                else
                                {
                                    oldSb.Append(item.ToString()).Append(",");
                                }
                            }
                        }
                        if (newArray != null)
                        {
                            foreach (var item in newArray)
                            {
                                if (item.GetType().IsEnum)
                                {
                                    newSb.Append(((Enum)item).ToDescription()).Append(",");
                                }
                                else
                                {
                                    newSb.Append(item.ToString()).Append(",");
                                }
                            }
                        }
                        oldSb.Append(" ]");
                        newSb.Append(" ]");
                        string oldStr = oldSb.ToString(), newStr = newSb.ToString();
                        if (oldStr != newStr)
                        {
                            updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldStr, newStr);
                        }
                    }
                    else
                    {
                        // 2015-06-10 去掉LimitChangeType判断
                        //switch (p.Name)
                        //{
                        //    case "LimitChangeType":
                        //        updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue.ToString() == "1" ? "限制退改期" : "不限制退改期", newValue.ToString() == "1" ? "限制退改期" : "不限制退改期");
                        //        break;
                        //    default:
                        //        updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue ?? "NULL", newValue ?? "NULL");
                        //        break;
                        //}
                        updatedFields.AppendFormat("{0}:{1}->{2}; ", fieldName, oldValue ?? "NULL", newValue ?? "NULL");
                    }
                }
            }

            return updatedFields.ToString();
        }

        private static bool Eq(Type propertyType, object oldValue, object newValue)
        {
            if (propertyType == typeof(Decimal) || propertyType == typeof(Decimal?))
            {
                return decimal.Parse(oldValue.ToString()) == decimal.Parse(newValue.ToString());
            }
            else
            {
                return string.Equals(oldValue.ToString(), newValue.ToString());
            }
        }
    }
}