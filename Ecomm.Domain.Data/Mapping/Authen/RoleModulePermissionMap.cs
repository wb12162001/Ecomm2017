﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//
// <copyright file="RoleModulePermissionMap.cs">
//		Copyright(c)2013 QuickFramework.All rights reserved.
//		开发组织：QuickFramework
//		公司网站：QuickFramework
//		所属工程：Ecomm.Domain.Data
//		生成时间：2016-12-08 17:38
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Authen;


namespace Ecomm.Domain.Data.Mapping.Authen
{
    /// <summary>
    /// 数据表映射 —— RoleModulePermission
    /// </summary>    
	partial class RoleModulePermissionMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void RoleModulePermissionMapAppend()
        {
			// Primary Key
            this.HasKey(t => t.Id);

            // Properties
            
            // Table & Column Mappings
            this.ToTable("");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            // Relation
        }

		
    }
}
