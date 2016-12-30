using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Framework.Tool
{
    /// <summary>
    /// 扩展System.Data.Entity.Database
    /// </summary>
    public static class DataBaseExtension
    {
        public static int ExecuteSqlCommandWithNoLock(this Database database, string sql, params object[] parameters)
        {
            sql = "set transaction isolation level read uncommitted;" + sql;
            return database.ExecuteSqlCommand(sql, parameters);
        }

        public static IEnumerable<TElement> SqlQueryWithNoLock<TElement>(this Database database, string sql, params object[] parameters)
        {
            sql = "set transaction isolation level read uncommitted;" + sql;
            if (EntityExtension.PrimitiveTypes.Contains(typeof(TElement)))
            {
                return database.SqlQuery<TElement>(sql, parameters);
            }
            else
            {
                return database.ExecuteQuery<TElement>(sql, CommandType.Text, null, parameters);
            }
        }

        public static DataSet SqlQueryWithNoLock(this Database database, string sql, params object[] parameters)
        {
            sql = "set transaction isolation level read uncommitted;" + sql;
            return database.ExecuteQuery(sql, CommandType.Text, parameters);

        }

        static IEnumerable<T> ExecuteQuery<T>(this Database database, string command, CommandType type = CommandType.Text, Action<T> setter = null, IEnumerable<object> parameters = null)
        {
            var ds = ExecuteQuery(database, command, type, parameters);
            return ds.Tables[0].ToModels<T>(null);
        }



        static DataSet ExecuteQuery(this Database database, string command, CommandType type = CommandType.Text, IEnumerable<object> parameters = null)
        {

            using (var conn = new SqlConnection(database.Connection.ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = command;
                    cmd.CommandType = type;

                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }

                    var ds = new DataSet();
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }

                    return ds;
                }
            }
        }

        static T ToModel<T>(this DataRow row, Action<T, DataRow> setter = null)
        {
            Type type = typeof(T);
            T model = Activator.CreateInstance<T>();
            var properties = type.GetProperties();
            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo p = properties.FirstOrDefault(o => string.Equals(o.Name, column.ColumnName, StringComparison.InvariantCultureIgnoreCase));
                if (p != null)
                {
                    var value = row[column.ColumnName];
                    if (value == DBNull.Value)
                    {
                        value = null;
                    }
                    p.SetValue(model, value, null);
                }
            }
            if (setter != null) setter(model, row);
            return model;
        }

        static IEnumerable<T> ToModels<T>(this DataTable datatable, Action<T, DataRow> setter = null)
        {
            foreach (DataRow row in datatable.Rows)
            {
                yield return row.ToModel(setter);
            }
        }


    }
}
