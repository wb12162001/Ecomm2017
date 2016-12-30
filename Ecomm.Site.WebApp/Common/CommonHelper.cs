using System;
using System.Collections.Generic;
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

        public static string SiteRootURL
        {
            get
            {
                string returnValue = System.Configuration.ConfigurationManager.AppSettings["SiteRootURL"];
                if (!string.IsNullOrEmpty(returnValue))
                {
                    if (!returnValue.EndsWith("/"))
                    {
                        returnValue += "/";
                    }
                    if (returnValue.StartsWith("/") && returnValue.Length > 1)
                    {
                        returnValue = returnValue.TrimStart('/');
                    }
                }
                else
                {

                    returnValue = System.Web.HttpContext.Current.Request.ApplicationPath;
                }
                //ben 2014-03-31
                //string host = System.Web.HttpContext.Current.Request.Url.Host;
                //if (returnValue.ToLower().IndexOf(host.ToLower()) == -1)
                //{
                //    returnValue = string.Format("http://{0}/", host.ToLower());
                //}
                return returnValue;
            }
        }
        public static string UploadFilesSiteRootUrl
        {
            get
            {
                string returnValue = System.Configuration.ConfigurationManager.AppSettings["UploadFilesRootUrl"];
                if (!string.IsNullOrEmpty(returnValue))
                {
                    if (!returnValue.EndsWith("/"))
                    {
                        returnValue += "/";
                    }
                    if (returnValue.StartsWith("/") && returnValue.Length > 1)
                    {
                        returnValue = returnValue.TrimStart('/');
                    }
                }
                else
                {

                    returnValue = System.Web.HttpContext.Current.Request.ApplicationPath;
                }
                return returnValue;
            }
        }

        public static string UploadFiles
        {
            get
            {
                string returnValue = System.Configuration.ConfigurationManager.AppSettings["UploadFiles"];
                if (string.IsNullOrEmpty(returnValue))
                {
                    returnValue = "UploadFiles";
                }
                //if (!returnValue.EndsWith(@"\"))
                //{
                //    returnValue += @"\";
                //}
                if (!returnValue.EndsWith("/"))
                {
                    returnValue += "/";
                }
                return returnValue;
            }
        }

        public static string UploadFilesRoot
        {
            get
            {
                string returnValue = System.Web.HttpContext.Current.Server.MapPath(string.Format(@"~/{0}", UploadFiles));
                if (!returnValue.EndsWith(@"\"))
                {
                    returnValue += @"\";
                }
                return returnValue;
            }
        }
        public static string UploadFilesRootURL
        {
            get
            {
                string returnValue = UploadFilesSiteRootUrl + UploadFiles;
                if (returnValue.EndsWith(@"\"))
                {
                    returnValue = returnValue.Replace(@"\", "/");
                }
                return returnValue;
            }
        }
    }
}