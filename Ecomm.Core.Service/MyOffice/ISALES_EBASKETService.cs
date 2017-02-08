//------------------------------------------------------------------------------
// <copyright file="ISALES_EBASKETService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:04
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_EBASKETService
    /// </summary>
    public interface ISALES_EBASKETService
    {
		#region 属性

        IQueryable<SALES_EBASKET> SALES_EBASKETList { get; }
        IEnumerable<SALES_EBASKET> Entities { get; }
        IEnumerable<SALES_EBASKET> EntitiesToList { get; }
        #endregion

        #region 公共方法
        OperationResult Insert(SALES_EBASKETModel model);
        OperationResult Update(UpdateSALES_EBASKETModel model);

        int UpdateEBasketQuantity(string custId, string contactId, string proNo, float quantity);
        int ModificationByProce(SALES_EBASKETModel model);
        int ModificationCart(SALES_EBASKETModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        int DeleteItem(string ID);

        Domain.Models.EpSnell.Rela_contact GetUser();
        #endregion
    }
}

