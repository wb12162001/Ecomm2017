﻿//------------------------------------------------------------------------------
// <copyright file="PROD_PROMOTIONSMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/2/6
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Domain.Data.Mapping.Product
{
    /// <summary>
    /// 数据表映射 —— PROD_PROMOTIONS 
    /// </summary>      
	internal partial class PROD_PROMOTIONSMap : EntityTypeConfiguration<PROD_PROMOTIONS>, IEntityMapper
    {
        /// <summary>
        /// Role-数据表映射构造函数
        /// </summary>
        public PROD_PROMOTIONSMap()
        {
			PROD_PROMOTIONSMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void PROD_PROMOTIONSMapAppend();
		
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

