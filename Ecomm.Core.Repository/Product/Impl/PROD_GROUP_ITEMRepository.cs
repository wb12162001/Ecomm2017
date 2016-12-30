//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_ITEMRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2016/12/28
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_GROUP_ITEM 
    /// </summary>
    [Export(typeof(IPROD_GROUP_ITEMRepository))]
    public class PROD_GROUP_ITEMRepository : EFRepositoryBase<PROD_GROUP_ITEM>, IPROD_GROUP_ITEMRepository
    {
        public PROD_GROUP_ITEMRepository() : base("default")
        {
        }
    }
}

