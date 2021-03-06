﻿//------------------------------------------------------------------------------
// <copyright file="ISALES_FAVORITERepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_FAVORITE 
    /// </summary>
    public interface ISALES_FAVORITERepository : IRepository<SALES_FAVORITE>
    {
        IEnumerable<SALES_FAVORITE_MASTER> QueryEntities(int count, string strWhere, string strOrder);

        string GetFavFolderFirstImg(string favFolderID);

        bool IsFavFolderFirstImg(string favFolderID);
    }
}

