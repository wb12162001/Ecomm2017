//------------------------------------------------------------------------------
// <copyright file="PROD_PHOTORepository.cs">
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
    /// 仓储操作层接口 —— PROD_PHOTO 
    /// </summary>
    [Export(typeof(IPROD_PHOTORepository))]
    public class PROD_PHOTORepository : EFRepositoryBase<PROD_PHOTO>, IPROD_PHOTORepository
    {
        public PROD_PHOTORepository() : base("default")
        {
        }
    }
}

