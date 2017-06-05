//------------------------------------------------------------------------------
// <copyright file="ISALES_FAVFOLDERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Site.Models.MyOffice.SALES_FAVFOLDER;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.MyOffice
{
	/// <summary>
    /// 服务层接口 —— ISALES_FAVFOLDERService
    /// </summary>
    public interface ISALES_FAVFOLDERService
    {
		#region 属性

        IQueryable<SALES_FAVFOLDER> SALES_FAVFOLDERList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SALES_FAVFOLDERModel model);
        OperationResult Update(UpdateSALES_FAVFOLDERModel model);


        int Update(SALES_FAVFOLDER model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);

        List<MyFavFolders> GetFavFoldersAndItemCount(string custID, string contactID);

        int DeleteBysql(string favId);

        string GetFavName(string favId);
        #endregion
    }
}

