//------------------------------------------------------------------------------
// <copyright file="SALES_INTERNETPRICERepository.cs">
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
    /// 仓储操作层接口 —— SALES_INTERNETPRICE 
    /// </summary>
    [Export(typeof(ISALES_INTERNETPRICERepository))]
    public class SALES_INTERNETPRICERepository : EFRepositoryBase<SALES_INTERNETPRICE>, ISALES_INTERNETPRICERepository
    {
        public SALES_INTERNETPRICERepository() : base("default")
        {
        }
    }
}

