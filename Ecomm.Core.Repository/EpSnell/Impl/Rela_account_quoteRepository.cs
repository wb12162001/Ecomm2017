//------------------------------------------------------------------------------
// <copyright file="Rela_account_quoteRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/16
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;


namespace Ecomm.Core.Repository.EpSnell
{
	/// <summary>
    /// 仓储操作层接口 —— Rela_account_quote 
    /// </summary>
    [Export(typeof(IRela_account_quoteRepository))]
    public class Rela_account_quoteRepository : EFRepositoryBase<Rela_account_quote>, IRela_account_quoteRepository
    {
        public Rela_account_quoteRepository() : base("default")
        {
        }
    }
}

