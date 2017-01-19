//------------------------------------------------------------------------------
// <copyright file="Rela_accountRepository.cs">
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
    /// 仓储操作层接口 —— Rela_account 
    /// </summary>
    [Export(typeof(IRela_accountRepository))]
    public class Rela_accountRepository : EFRepositoryBase<Rela_account>, IRela_accountRepository
    {
        public Rela_accountRepository() : base("ep_snell")
        {
        }
    }
}

