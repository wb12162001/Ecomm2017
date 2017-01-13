//------------------------------------------------------------------------------
// <copyright file="SYS_CONFIGRepository.cs">
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
    /// 仓储操作层接口 —— SYS_CONFIG 
    /// </summary>
    [Export(typeof(ISYS_CONFIGRepository))]
    public class SYS_CONFIGRepository : EFRepositoryBase<SYS_CONFIG>, ISYS_CONFIGRepository
    {
        public SYS_CONFIGRepository() : base("default")
        {
        }
    }
}

