//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_INDEXRepository.cs">
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
    /// 仓储操作层接口 —— PROD_GROUP_INDEX 
    /// </summary>
    [Export(typeof(IPROD_GROUP_INDEXRepository))]
    public class PROD_GROUP_INDEXRepository : EFRepositoryBase<PROD_GROUP_INDEX>, IPROD_GROUP_INDEXRepository
    {
        public PROD_GROUP_INDEXRepository() : base("default")
        {
        }
    }
}

