//------------------------------------------------------------------------------
// <copyright file="SALES_VIEWEDRepository.cs">
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
    /// 仓储操作层接口 —— SALES_VIEWED 
    /// </summary>
    [Export(typeof(ISALES_VIEWEDRepository))]
    public class SALES_VIEWEDRepository : EFRepositoryBase<SALES_VIEWED>, ISALES_VIEWEDRepository
    {
        public SALES_VIEWEDRepository() : base("default")
        {
        }
    }
}

