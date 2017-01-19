//------------------------------------------------------------------------------
// <copyright file="SALES_INTERNETPRICEService.cs">
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
using Ecomm.Site.Models.MyOffice.SALES_INTERNETPRICE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_INTERNETPRICEService
    /// </summary>
    [Export(typeof(ISALES_INTERNETPRICEService))]
    public class SALES_INTERNETPRICEService : CoreServiceBase, ISALES_INTERNETPRICEService
    {
        #region 属性

        [Import]
        public ISALES_INTERNETPRICERepository SALES_INTERNETPRICERepository { get; set; }

        public IQueryable<SALES_INTERNETPRICE> SALES_INTERNETPRICEList
        {
            get { return SALES_INTERNETPRICERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_INTERNETPRICEModel model)
        {
            var entity = new SALES_INTERNETPRICE
            {
                CustomerID = model.CustomerID,
                ProductNo = model.ProductNo,
                IPrice = model.IPrice,
                Status = model.Status,
            };
            SALES_INTERNETPRICERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_INTERNETPRICEModel model)
        {
			var entity = SALES_INTERNETPRICEList.First(t => t.CustomerID == model.CustomerID && t.ProductNo == model.ProductNo);
            entity.CustomerID = model.CustomerID;
            entity.ProductNo = model.ProductNo;
            entity.IPrice = model.IPrice;
            entity.Status = model.Status;

            SALES_INTERNETPRICERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  CustomerID,string  ProductNo)
        {
            var model = SALES_INTERNETPRICEList.FirstOrDefault(t => t.CustomerID == CustomerID && t.ProductNo == ProductNo);

            SALES_INTERNETPRICERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

