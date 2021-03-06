﻿//------------------------------------------------------------------------------
// <copyright file="ISALES_FAVORITEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_FAVORITE;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_FAVORITEService
    /// </summary>
    public interface ISALES_FAVORITEService
    {
		#region 属性

        IQueryable<SALES_FAVORITE> SALES_FAVORITEList { get; }

        #endregion

        #region 公共方法
        IEnumerable<SALES_FAVORITE_MASTER> QueryEntities(int count, string strWhere, string strOrder);

        IEnumerable<SALES_FAVORITE_MASTER> GetAllByCondition(string custID, string contactID,string strWhere);
        OperationResult Insert(SALES_FAVORITEModel model);
        OperationResult Update(UpdateSALES_FAVORITEModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);

        string GetFavFolderFirstImg(string favFolderID);
        #endregion
    }
}

