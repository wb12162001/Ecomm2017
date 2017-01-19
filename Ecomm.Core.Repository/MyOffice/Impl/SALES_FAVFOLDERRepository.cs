//------------------------------------------------------------------------------
// <copyright file="SALES_FAVFOLDERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_FAVFOLDER 
    /// </summary>
    [Export(typeof(ISALES_FAVFOLDERRepository))]
    public class SALES_FAVFOLDERRepository : EFRepositoryBase<SALES_FAVFOLDER>, ISALES_FAVFOLDERRepository
    {
        public SALES_FAVFOLDERRepository() : base("default")
        {
        }
    }
}

