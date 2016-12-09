﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
//	   如存在本生成代码外的新需求，请在相同命名空间下创建同名分部类进行实现。
// </auto-generated>
//
// <copyright file="IRoleModulePermissionService.cs">
//		Copyright(c)2013 QuickFramework.All rights reserved.
//		开发组织：QuickFramework
//		公司网站：QuickFramework
//		所属工程：Ecomm.Core.Service
//		生成时间：2013-12-11 23:55
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Core.Repository.Authen;
using Ecomm.Domain.Models.Authen;
using Ecomm.Site.Models.Authen.Permission;
using Ecomm.Site.Models.Authen.RoleModulePermission;


namespace Ecomm.Core.Service.Authen
{
	/// <summary>
    /// 服务层接口 —— IRoleModulePermissionService
    /// </summary>
	public interface IRoleModulePermissionService
    {
        #region 属性

		IQueryable<RoleModulePermission> RoleModulePermissions { get; }

        #endregion

        #region 公共方法

        OperationResult SetRoleModulePermission(int roleId, IEnumerable<RoleModulePermissionModel> addModulePermissionList, IEnumerable<RoleModulePermissionModel> removeModulePermissionList);
        
        #endregion
    }
}
