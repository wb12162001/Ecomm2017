//------------------------------------------------------------------------------
// <copyright file="INFOR_CATEGORIESRepository.cs">
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
    /// 仓储操作层接口 —— INFOR_CATEGORIES 
    /// </summary>
    [Export(typeof(IINFOR_CATEGORIESRepository))]
    public class INFOR_CATEGORIESRepository : EFRepositoryBase<INFOR_CATEGORIES>, IINFOR_CATEGORIESRepository
    {
        public INFOR_CATEGORIESRepository() : base("default")
        {
        }
    }
}

