﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
// <copyright file="PermissionMap.generated.cs">
//		Copyright(c)2013 QuickFramework.All rights reserved.
//		开发组织：QuickFramework
//		公司网站：QuickFramework
//		所属工程：Ecomm.Domain.Data
//		生成时间：2016-12-08 17:38
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Authen;


namespace Ecomm.Domain.Data.Mapping.Authen
{
    /// <summary>
    /// 数据表映射 —— Permission
    /// </summary>    
	internal partial class PermissionMap : EntityTypeConfiguration<Permission>, IEntityMapper
    {
        /// <summary>
        /// Permission-数据表映射构造函数
        /// </summary>
        public PermissionMap()
        {
			PermissionMapAppend();
        }

		/// <summary>
        /// 额外的数据映射
        /// </summary>
        partial void PermissionMapAppend();
		
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
