﻿//------------------------------------------------------------------------------
// <copyright file="Rela_location_limitMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/16
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;


namespace Ecomm.Domain.Data.Mapping.EpSnell
{
    /// <summary>
    /// 数据表映射 —— Rela_location_limit 
    /// </summary>      
	internal partial class Rela_location_limitMap : EntityTypeConfiguration<Rela_location_limit>, IEntityMapper
    {
        /// <summary>
        /// Role-数据表映射构造函数
        /// </summary>
        public Rela_location_limitMap()
        {
			Rela_location_limitMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void Rela_location_limitMapAppend();
		
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
