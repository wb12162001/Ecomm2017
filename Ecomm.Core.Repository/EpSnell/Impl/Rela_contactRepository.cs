//------------------------------------------------------------------------------
// <copyright file="Rela_contactRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/3
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.EpSnell
{
	/// <summary>
    /// 仓储操作层接口 —— Rela_contact 
    /// </summary>
    [Export(typeof(IRela_contactRepository))]
    public class Rela_contactRepository : EFRepositoryBase<Rela_contact>, IRela_contactRepository
    {
        public Rela_contactRepository() : base("default")
        {
        }

    }
}

