//------------------------------------------------------------------------------
// <copyright file="INFOR_MASTERRepository.cs">
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
    /// 仓储操作层接口 —— INFOR_MASTER 
    /// </summary>
    [Export(typeof(IINFOR_MASTERRepository))]
    public class INFOR_MASTERRepository : EFRepositoryBase<INFOR_MASTER>, IINFOR_MASTERRepository
    {
        public INFOR_MASTERRepository() : base("default")
        {
        }
    }
}

