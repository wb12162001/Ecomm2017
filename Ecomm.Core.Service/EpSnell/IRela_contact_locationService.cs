//------------------------------------------------------------------------------
// <copyright file="IRela_contact_locationService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:27
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_contact_location;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_contact_locationService
    /// </summary>
    public interface IRela_contact_locationService
    {
		#region 属性

        IQueryable<Rela_contact_location> Rela_contact_locationList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Rela_contact_locationModel model);
        OperationResult Update(UpdateRela_contact_locationModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Account_no,string  Contact_id,string  Address_no);
        #endregion
	}
}

