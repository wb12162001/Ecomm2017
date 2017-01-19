//------------------------------------------------------------------------------
// <copyright file="Rela_location_limitRepository.cs">
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
    /// 仓储操作层接口 —— Rela_location_limit 
    /// </summary>
    [Export(typeof(IRela_location_limitRepository))]
    public class Rela_location_limitRepository : EFRepositoryBase<Rela_location_limit>, IRela_location_limitRepository
    {
        public Rela_location_limitRepository() : base("ep_snell")
        {
        }
    }
}

