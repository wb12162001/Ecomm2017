using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

using Quick.Framework.Tool;


namespace Quick.Framework.EFData
{
    /// <summary>
    ///     EF数据访问上下文
    /// </summary>
    [Export("EFGPSPS", typeof(DbContext))]
    public class EFGPSPSDbContext : DbContext
    {
        public EFGPSPSDbContext()
            : base("gpsps") { }

        public EFGPSPSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString ?? "gpsps") {
            this.Database.Connection.ConnectionString = nameOrConnectionString;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public EFGPSPSDbContext(DbConnection existingConnection)
            : base(existingConnection, true) { }

        [ImportMany(typeof(IEntityMapper))]
        public IEnumerable<IEntityMapper> EntityMappers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //EF默认设置级联删除，先移除默认规则，需要再配置
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            if (EntityMappers == null)
            {
                return;
            }

            foreach (var mapper in EntityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }
    }
}