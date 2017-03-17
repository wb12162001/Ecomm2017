//------------------------------------------------------------------------------
// <copyright file="PROD_PROMOTIONSRepository.cs">
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
    /// 仓储操作层接口 —— PROD_PROMOTIONS 
    /// </summary>
    [Export(typeof(IPROD_PROMOTIONSRepository))]
    public class PROD_PROMOTIONSRepository : EFRepositoryBase<PROD_PROMOTIONS>, IPROD_PROMOTIONSRepository
    {
        public PROD_PROMOTIONSRepository() : base("default")
        {
        }
    }
}

