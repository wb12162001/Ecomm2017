//------------------------------------------------------------------------------
// <copyright file="ISYS_CONFIGService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Site.Models.SysConfig.SYS_CONFIG;
using System.Collections.Generic;
using Quick.Site.Common.Models;


namespace Ecomm.Core.Service.SysConfig
{
	/// <summary>
    /// 服务层接口 —— ISYS_CONFIGService
    /// </summary>
    public interface ISYS_CONFIGService
    {
		#region 属性

        IQueryable<SYS_CONFIG> SYS_CONFIGList { get; }

        #endregion

        #region 公共方法
        OperationResult Insert(SYS_CONFIGModel model);
        OperationResult Update(UpdateSYS_CONFIGModel model);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        OperationResult Delete(string  ID);
        #endregion

        object GetSysConfigContent(string confiID);


         object GetSysConfigContentByname(string confiName);


        /// <summary>
        /// From SysConfig Table for "E3E0E0F3-1CF7-480A-96DB-F42BE94C006C" ID
        /// </summary>
        /// <returns></returns>
         double GetFreight();

        /// <summary>
        /// From SysConfig Table for "CD183AD3-2BA0-4F16-A7F8-805ECAFFFEC1" ID
        /// </summary>
        /// <returns></returns>
         double GetGst();


         double GetCalculatedGst(double freight, double misc, double subtotal);

         int GetPageSize();


         string GetRepEmail();


         string GetGstNo();


         string GetHomePageBanner();


         string GetHomePageBannerUrl();

         bool IsOpenEOFBanner();

         string GetEofPageBanner();


         string GetEofPageBannerUrl();

    }
}

