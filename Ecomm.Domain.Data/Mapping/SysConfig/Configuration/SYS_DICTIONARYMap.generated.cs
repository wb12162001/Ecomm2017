//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARYMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/5
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.SysConfig;


namespace Ecomm.Domain.Data.Mapping.SysConfig
{
    /// <summary>
    /// 数据表映射 —— SYS_DICTIONARY 
    /// </summary>      
	internal partial class SYS_DICTIONARYMap : EntityTypeConfiguration<SYS_DICTIONARY>, IEntityMapper
    {
        /// <summary>
        /// Role-数据表映射构造函数
        /// </summary>
        public SYS_DICTIONARYMap()
        {
			SYS_DICTIONARYMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void SYS_DICTIONARYMapAppend();
		
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="configurations">实体映射配置注册器</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            configurations.Add(this);
        }
    }
}

