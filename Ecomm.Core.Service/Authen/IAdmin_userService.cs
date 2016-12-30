//------------------------------------------------------------------------------
// <copyright file="IAdmin_userService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/23 14:34:48
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.Authen;
using Ecomm.Site.Models.Authen.Admin_user;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.Authen
{
	/// <summary>
    /// 服务层接口 —— IAdmin_userService
    /// </summary>
    public interface IAdmin_userService
    {
		#region 属性

        IQueryable<Admin_user> Admin_userList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Admin_userModel model);
        OperationResult Update(Admin_user model);
        OperationResult Update(UpdateAdmin_userModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete( string Id );

        OperationResult Update(ChangePwdModel model);
        #endregion
    }
}

