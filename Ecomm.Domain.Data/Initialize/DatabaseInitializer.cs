using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using Quick.Framework.EFData;
using Ecomm.Domain.Data.Migrations;

namespace Ecomm.Domain.Data.Initialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /**
         * CreateDatabaseIfNotExists：该项也是默认初始化数据库的一项，要是数据库不存在就创建数据库。
         * DropCreateDatabaseIfModelChanges：只要数据模型发生了改变就重新创建数据库。
         * DropCreateDatabaseAlways：只要每次初始化上下文时就创建数据库。
         **/
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            //每次重构的时候，必须要关闭数据库连接，才能执行成功；
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>()); 
            //即可见数据库在不修改数据的情况下实现了字段的修改   
            Database.SetInitializer<EFDbContext>(null);
            Database.SetInitializer<EFAppDbContext>(null);
            Database.SetInitializer<EFEpsnellDbContext>(null);
            Database.SetInitializer<EFGPSPSDbContext>(null);
            Database.SetInitializer<EFInetAppDbContext>(null);
        }
    }
}
