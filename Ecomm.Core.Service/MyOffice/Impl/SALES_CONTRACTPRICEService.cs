//------------------------------------------------------------------------------
// <copyright file="SALES_CONTRACTPRICEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Core.Repository.MyOffice;
using Ecomm.Site.Models;
using Ecomm.Site.Models.MyOffice.SALES_CONTRACTPRICE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_CONTRACTPRICEService
    /// </summary>
    [Export(typeof(ISALES_CONTRACTPRICEService))]
    public class SALES_CONTRACTPRICEService : CoreServiceBase, ISALES_CONTRACTPRICEService
    {
        #region 属性

        [Import]
        public ISALES_CONTRACTPRICERepository SALES_CONTRACTPRICERepository { get; set; }

        public IQueryable<SALES_CONTRACTPRICE> SALES_CONTRACTPRICEList
        {
            get { return SALES_CONTRACTPRICERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public IEnumerable<ContractPrice_PAGE_MASTER> GetContractPric(string strwhere, string orderby, int pagesize, int pageIndex, out int totalCount)
        {
            return SALES_CONTRACTPRICERepository.GetContractPric(strwhere, orderby, pagesize, pageIndex, out totalCount);
        }

        public OperationResult Insert(SALES_CONTRACTPRICEModel model)
        {
            var entity = new SALES_CONTRACTPRICE
            {
                CustomerID = model.CustomerID,
                ProductNo = model.ProductNo,
                ContractPrice = model.ContractPrice,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Status = model.Status,
                RowID = model.RowID,
            };
            SALES_CONTRACTPRICERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_CONTRACTPRICEModel model)
        {
			var entity = SALES_CONTRACTPRICEList.First(t => t.CustomerID == model.CustomerID && t.ProductNo == model.ProductNo);
            entity.CustomerID = model.CustomerID;
            entity.ProductNo = model.ProductNo;
            entity.ContractPrice = model.ContractPrice;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Status = model.Status;
            entity.RowID = model.RowID;

            SALES_CONTRACTPRICERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  CustomerID,string  ProductNo)
        {
            var model = SALES_CONTRACTPRICEList.FirstOrDefault(t => t.CustomerID == CustomerID && t.ProductNo == ProductNo);

            SALES_CONTRACTPRICERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        public bool IsExist(string customerID, string productNo)
        {
            bool ret = false;
            var info = SALES_CONTRACTPRICEList.FirstOrDefault(t => t.CustomerID == customerID && t.ProductNo == productNo);
            if (info != null && info.ContractPrice > 0)
            {
                ret = true;
            }
            return ret;
        }

        #endregion
    }
}

