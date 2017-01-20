﻿//------------------------------------------------------------------------------
// <copyright file="SALES_ESIORDERFORMRepository.cs">
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
    /// 仓储操作层接口 —— SALES_ESIORDERFORM 
    /// </summary>
    [Export(typeof(ISALES_ESIORDERFORMRepository))]
    public class SALES_ESIORDERFORMRepository : EFRepositoryBase<SALES_ESIORDERFORM>, ISALES_ESIORDERFORMRepository
    {
        public SALES_ESIORDERFORMRepository() : base("default")
        {
        }
    }
}
