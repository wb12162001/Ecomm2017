﻿//------------------------------------------------------------------------------
// <copyright file="IRela_account_locationService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:27
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Site.Models.EpSnell.Rela_account_location;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.EpSnell
{
	/// <summary>
    /// 服务层接口 —— IRela_account_locationService
    /// </summary>
    public interface IRela_account_locationService
    {
		#region 属性

        IQueryable<Rela_account_location> Rela_account_locationList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(Rela_account_locationModel model);
        OperationResult Update(UpdateRela_account_locationModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  Account_no,string  Address_id);

        string GetAddress(string account_no, string address_id);

        IEnumerable<Rela_account_location_shipto> Query_SHIPTO(string account_no, string contact_id);

        IEnumerable<Rela_account_location_shipto_item> QueryDropList(string account_no);
        #endregion
    }
}

