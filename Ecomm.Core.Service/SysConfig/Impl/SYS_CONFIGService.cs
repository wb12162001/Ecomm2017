//------------------------------------------------------------------------------
// <copyright file="SYS_CONFIGService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Core.Repository.SysConfig;
using Ecomm.Site.Models;
using Ecomm.Site.Models.SysConfig.SYS_CONFIG;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— SYS_CONFIGService
    /// </summary>
    [Export(typeof(ISYS_CONFIGService))]
    public class SYS_CONFIGService : CoreServiceBase, ISYS_CONFIGService
    {
        #region 属性

        [Import]
        public ISYS_CONFIGRepository SYS_CONFIGRepository { get; set; }

        public IQueryable<SYS_CONFIG> SYS_CONFIGList
        {
            get { return SYS_CONFIGRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(SYS_CONFIGModel model)
        {
            var entity = new SYS_CONFIG
            {
                ID = model.ID,
                ConfigName = model.ConfigName,
                ConfigContent = model.ConfigContent,
                FieldProperty = model.FieldProperty,
                IsSystem = model.IsSystem,
            };
            SYS_CONFIGRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSYS_CONFIGModel model)
        {
			var entity = SYS_CONFIGList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.ConfigName = model.ConfigName;
            entity.ConfigContent = model.ConfigContent;
            entity.FieldProperty = model.FieldProperty;
            entity.IsSystem = model.IsSystem;

            SYS_CONFIGRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SYS_CONFIGList.FirstOrDefault(t => t.ID == ID);

            SYS_CONFIGRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion

        public object GetSysConfigContent(string confiID)
        {
            var model = SYS_CONFIGList.FirstOrDefault(t => t.ID == confiID);
            return model.ConfigContent;
        }

        public object GetSysConfigContentByname(string confiName)
        {
            var model = SYS_CONFIGList.FirstOrDefault(t => t.ConfigName == confiName);
            return model.ConfigContent;
        }

        /// <summary>
        /// From SysConfig Table for "E3E0E0F3-1CF7-480A-96DB-F42BE94C006C" ID
        /// </summary>
        /// <returns></returns>
        public double GetFreight()
        {
            object o = GetSysConfigContent("E3E0E0F3-1CF7-480A-96DB-F42BE94C006C");//hustle code
            return o != null ? Convert.ToDouble(o) : 8.9500;
        }
        /// <summary>
        /// From SysConfig Table for "CD183AD3-2BA0-4F16-A7F8-805ECAFFFEC1" ID
        /// </summary>
        /// <returns></returns>
        public double GetGst()
        {
            object o = GetSysConfigContent("CD183AD3-2BA0-4F16-A7F8-805ECAFFFEC1");//hustle code
            return (o != null ? Convert.ToDouble(o) : 0.15);
        }

        public double GetCalculatedGst(double freight, double misc, double subtotal)
        {
            double gst = GetGst();
            return (freight + misc + subtotal) * gst;
        }
        public int GetPageSize()
        {
            object o = GetSysConfigContent("0A2FA243-FA5E-442C-9BFA-EA19ED64C8FA");//hustle code
            return (o != null ? Convert.ToInt32(o) : 20);
        }

        public string GetRepEmail()
        {
            object o = GetSysConfigContent("B17B1097-14EA-4A2B-B8A1-0BE5A33CE919");
            return (o != null ? o.ToString() : string.Empty);
        }

        public string GetGstNo()
        {
            object o = GetSysConfigContent("9FB8F386-51CA-40F5-96E6-47BB1B37650E");
            return (o != null ? o.ToString() : "11-753-604");
        }

        public string GetHomePageBanner()
        {
            object o = GetSysConfigContent("804914D5-83DB-48AA-9EA0-19EED6C938DD");
            return (o != null ? o.ToString() : string.Empty);
        }

        public string GetHomePageBannerUrl()
        {
            object o = GetSysConfigContent("8300C5BD-F47D-4D1A-B8F3-4B7515342B40");
            return (o != null ? o.ToString() : string.Empty);
        }
        public bool IsOpenEOFBanner()
        {
            object o = GetSysConfigContent("D44ECFDF-B5DE-40C1-82BC-D779D99A835E");//hustle code
            return (o != null ? Convert.ToBoolean(int.Parse(o.ToString())) : false);
        }
        public string GetEofPageBanner()
        {
            object o = GetSysConfigContent("C6E0B2B5-24E5-4700-A7BF-8DA4624899AF");
            return (o != null ? o.ToString() : string.Empty);
        }

        public string GetEofPageBannerUrl()
        {
            object o = GetSysConfigContent("529EC20F-421D-4B7E-972A-49C55987DFAF");
            return (o != null ? o.ToString() : string.Empty);
        }
    }
}

