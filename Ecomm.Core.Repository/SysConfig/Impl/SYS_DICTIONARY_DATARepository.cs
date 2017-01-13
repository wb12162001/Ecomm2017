//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARY_DATARepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/5
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.SysConfig;


namespace Ecomm.Core.Repository.SysConfig
{
	/// <summary>
    /// 仓储操作层接口 —— SYS_DICTIONARY_DATA 
    /// </summary>
    [Export(typeof(ISYS_DICTIONARY_DATARepository))]
    public class SYS_DICTIONARY_DATARepository : EFRepositoryBase<SYS_DICTIONARY_DATA>, ISYS_DICTIONARY_DATARepository
    {
        public SYS_DICTIONARY_DATARepository() : base("default")
        {
        }
    }
}

