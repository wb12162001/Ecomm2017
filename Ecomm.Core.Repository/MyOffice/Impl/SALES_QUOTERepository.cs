//------------------------------------------------------------------------------
// <copyright file="SALES_QUOTERepository.cs">
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
    /// 仓储操作层接口 —— SALES_QUOTE 
    /// </summary>
    [Export(typeof(ISALES_QUOTERepository))]
    public class SALES_QUOTERepository : EFRepositoryBase<SALES_QUOTE>, ISALES_QUOTERepository
    {
        public SALES_QUOTERepository() : base("default")
        {
        }
    }
}

