﻿//------------------------------------------------------------------------------
// <copyright file="ISALES_QUOTEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_QUOTE;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_QUOTEService
    /// </summary>
    public interface ISALES_QUOTEService
    {
		#region 属性

        IQueryable<SALES_QUOTE> SALES_QUOTEList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SALES_QUOTEModel model);
        OperationResult Update(UpdateSALES_QUOTEModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion
	}
}

