//------------------------------------------------------------------------------
// <copyright file="SALES_EBASKETRepository.cs">
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
    /// 仓储操作层接口 —— SALES_EBASKET 
    /// </summary>
    [Export(typeof(ISALES_EBASKETRepository))]
    public class SALES_EBASKETRepository : EFRepositoryBase<SALES_EBASKET>, ISALES_EBASKETRepository
    {
        public SALES_EBASKETRepository() : base("default")
        {
        }
    }
}

