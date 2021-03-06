﻿//------------------------------------------------------------------------------
// <copyright file="ISALES_FAVFOLDERRepository.cs">
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
    /// 仓储操作层接口 —— SALES_FAVFOLDER 
    /// </summary>
    public interface ISALES_FAVFOLDERRepository : IRepository<SALES_FAVFOLDER>
    {
        List<MyFavFolders> GetFavFoldersAndItemCount(string custID, string contactID);

        int Delete(string favId);
    }
}

