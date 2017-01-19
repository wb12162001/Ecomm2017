//------------------------------------------------------------------------------
// <copyright file="SALES_CONTRACTPRICERepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_CONTRACTPRICE 
    /// </summary>
    [Export(typeof(ISALES_CONTRACTPRICERepository))]
    public class SALES_CONTRACTPRICERepository : EFRepositoryBase<SALES_CONTRACTPRICE>, ISALES_CONTRACTPRICERepository
    {
        public SALES_CONTRACTPRICERepository() : base("default")
        {
        }
    }
}

