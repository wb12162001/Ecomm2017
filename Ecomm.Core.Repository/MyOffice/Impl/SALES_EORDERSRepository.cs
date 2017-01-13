//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERSRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/12
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_EORDERS 
    /// </summary>
    [Export(typeof(ISALES_EORDERSRepository))]
    public class SALES_EORDERSRepository : EFRepositoryBase<SALES_EORDERS>, ISALES_EORDERSRepository
    {
        public SALES_EORDERSRepository() : base("default")
        {
        }
    }
}

