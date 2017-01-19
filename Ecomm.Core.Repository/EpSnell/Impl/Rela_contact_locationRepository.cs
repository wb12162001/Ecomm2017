//------------------------------------------------------------------------------
// <copyright file="Rela_contact_locationRepository.cs">
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
    /// 仓储操作层接口 —— Rela_contact_location 
    /// </summary>
    [Export(typeof(IRela_contact_locationRepository))]
    public class Rela_contact_locationRepository : EFRepositoryBase<Rela_contact_location>, IRela_contact_locationRepository
    {
        public Rela_contact_locationRepository() : base("ep_snell")
        {
        }
    }
}

