using Ecomm.Core.Service.SysConfig;
using Ecomm.Site.Models.SysConfig.INFOR_MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomm.Site.WebApp.Common
{
    public class CommonHelper
    {
        public static string GetStatusString(bool statue)
        {
            return statue ? "<span class='date badge badge-success'>True</span>" : "<span class='date badge badge-warning'>False</span>";
        }

        public static string GetEnableStatusString(int? Enable)
        {
            return Enable==0 ? "<span class='date badge badge-success'>True</span>" : "<span class='date badge badge-warning'>False</span>";
        }
        public static string GetImageString(string img)
        {
            return !string.IsNullOrEmpty(img) ? string.Format("<img style='width: 150px; height: auto' src='{0}' />", img) : "";
        }
        //本地路径转换成URL相对路径
        public static string UrlConvertor(string imagesurl1)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            //imagesurl2 = imagesurl2.Replace(@"Aspx_Uc/", @"");
            return imagesurl2;
        }
        //相对路径转换成服务器本地物理路径
        public static string UrlConvertorlocal(string imagesurl1)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径
            return imagesurl2;
        }


        public static string GetCateName(string desc, string categoryName)
        {
            if (string.IsNullOrEmpty(desc)) return categoryName;

            desc = desc.Replace("/", " & ");
            desc = desc.Trim();
            if (desc.Length > 25)
            {
                desc = desc.Replace("Products", "");
                desc = desc.Replace("products", "");
            }
            return desc;
        }
    }
}