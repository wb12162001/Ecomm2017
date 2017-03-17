//------------------------------------------------------------------------------
// <copyright file="PROD_RELATED_PROPERTYRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/2/6
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_RELATED_PROPERTY 
    /// </summary>
    [Export(typeof(IPROD_RELATED_PROPERTYRepository))]
    public class PROD_RELATED_PROPERTYRepository : EFRepositoryBase<PROD_RELATED_PROPERTY>, IPROD_RELATED_PROPERTYRepository
    {
        public PROD_RELATED_PROPERTYRepository() : base("default")
        {
        }
    }
}

