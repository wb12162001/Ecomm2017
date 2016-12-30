//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2016/12/20
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_MASTER 
    /// </summary>
    [Export(typeof(IPROD_MASTERRepository))]
    public class PROD_MASTERRepository : EFRepositoryBase<PROD_MASTER>, IPROD_MASTERRepository
    {
        public PROD_MASTERRepository() : base("default")
        {
        }
    }
}

