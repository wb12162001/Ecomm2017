//------------------------------------------------------------------------------
// <copyright file="ISALES_ESIORDERFORMService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_ESIORDERFORM;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_ESIORDERFORMService
    /// </summary>
    public interface ISALES_ESIORDERFORMService
    {
		#region 属性

        IQueryable<SALES_ESIORDERFORM> SALES_ESIORDERFORMList { get; }

        #endregion

        #region 公共方法

        IEnumerable<SALES_ESIORDERFORM_MASTER> QueryEntities(int count, string strWhere, string strOrder);

        OperationResult Insert(SALES_ESIORDERFORMModel model);
        OperationResult Update(UpdateSALES_ESIORDERFORMModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  CustomerID,string  ProductNo,string  ShipTo);

        IEnumerable<ESIORDERFORM_PAGE_MASTER> GetByCustIDAndShipto(string customer, string contactID, string shipTo, int curPage, int pageRows, string strWhere, string orderby, out int pageCount);

        IEnumerable<ESIORDERFORM_PAGE_MASTER> GetItems(string customer,string strWhrer, string location, string orderby, int pageIndex, int pageSize, out int pageCount);

        IEnumerable<ESIORDERFORM_PAGE_MASTER> GetByCustIDAndShipto(string customer, string contactID, string shipTo, string strWhere, string orderby);
        double getCurrentPrice(object currentPrice, object listPrice);

        List<Location> GetEOFShipToCount(string strWhere);


        IEnumerable<CustomizedProduct_PAGE_MASTER> GetCustomizedProducts(string strwhere, string custnmbr, string sortModle, int pagesize, int pageIndex, out int totalCount);

        IEnumerable<MyFavourite_QTY_MASTER> GetQTY(string customerID, string productNo);

        double[] GetQTYBycustomerID(string customerID, string productNo);
        #endregion
    }
}

