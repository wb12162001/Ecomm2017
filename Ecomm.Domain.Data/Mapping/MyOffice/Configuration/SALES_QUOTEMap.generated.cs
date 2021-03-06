﻿//------------------------------------------------------------------------------
// <copyright file="SALES_QUOTEMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Domain.Data.Mapping.MyOffice
{
    /// <summary>
    /// 数据表映射 —— SALES_QUOTE 
    /// </summary>      
	internal partial class SALES_QUOTEMap : EntityTypeConfiguration<SALES_QUOTE>, IEntityMapper
    {
        /// <summary>
        /// Role-数据表映射构造函数
        /// </summary>
        public SALES_QUOTEMap()
        {
			SALES_QUOTEMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void SALES_QUOTEMapAppend();
		
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

