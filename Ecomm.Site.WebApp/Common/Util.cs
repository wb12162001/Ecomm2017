using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomm.Site.WebApp.Common
{
    public class Util
    {
        public static DateTime DeadDate
        {
            get
            {
                return new DateTime(1900, 1, 1);
            }
        }
        public static DateTime defaultDate = Convert.ToDateTime("01/01/1753 12:00:00");
        public static decimal toqty = 999999999999.99900m;
        /// <summary>
        /// Convert date to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string TransformDateToString(object obj)
        {
            try
            {
                DateTime dt = System.Convert.ToDateTime(obj);
                string outString = dt.ToString("MM/dd/yyyy");
                if (outString == "01/01/1900")
                {
                    return "";
                }
                else
                {
                    return outString;
                }
            }
            catch
            {
                return "";
            }
        }

        public static DateTime TransformObjToDate(object obj)
        {
            try
            {
                if (obj != DBNull.Value)
                {
                    return System.Convert.ToDateTime(obj);
                }
                else
                {
                    return Util.DeadDate;
                }
            }
            catch
            {
                return Util.DeadDate;
            }
        }

        public static double TransformObjToDou(object obj)
        {
            try
            {
                if (obj != DBNull.Value)
                {
                    return System.Convert.ToDouble(obj);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert a description to unorderd list if set to use bullets display format.
        /// </summary>
        /// <param name="objDescription"></param>
        /// <param name="objUseBullets"></param>
        /// <returns></returns>
        public static string TransformDescription(object objDescription)
        {
            string description = objDescription.ToString().Trim();
            string oStr;

            if (description.Length <= 200)
            {
                oStr = description;
            }
            else
            {
                oStr = description.Substring(0, 197) + "...";
            }

            return oStr;
        }


        /// <summary>
        /// Get a integer URL parameter
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static int GetIntQueryString(string paramName)
        {
            int returnValue = 0;
            try
            {
                returnValue = Convert.ToInt32(HttpContext.Current.Request.Params[paramName]);
            }
            catch
            {
            }
            return returnValue;
        }

        /// <summary>
        /// Get a integer URL parameter
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static decimal GetDecimalQueryString(string paramName)
        {
            decimal returnValue = 0M;
            try
            {
                returnValue = Convert.ToDecimal(HttpContext.Current.Request.Params[paramName]);
            }
            catch
            {
            }
            return returnValue;
        }


        /// <summary>
        /// Get a integer URL parameter, return default value in case of parameter is not found or can't be converted to a integer.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static int GetIntQueryString(string paramName, int defaultValue)
        {
            int returnValue = defaultValue;
            try
            {
                object obj = HttpContext.Current.Request.Params[paramName];
                if (obj != null)
                {
                    returnValue = Convert.ToInt32(obj.ToString());
                }
            }
            catch
            {
            }
            return returnValue;
        }

        /// <summary>
        /// Get a string URL parameter
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string GetStringQueryString(string paramName)
        {
            string returnValue = "";
            try
            {
                returnValue = HttpContext.Current.Request.Params[paramName].ToString();
            }
            catch
            {
            }

            return returnValue;
        }

        /// <summary>
        /// Get a string URL parameter, return default value if parameter not found.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string GetStringQueryString(string paramName, string defaultValue)
        {
            string returnValue = defaultValue;
            try
            {
                returnValue = HttpContext.Current.Request.Params[paramName].ToString();
            }
            catch
            {
            }

            return returnValue;
        }

        public static void SetCookie(string paramName, string val)
        {
            try
            {
                HttpCookie acookie = new HttpCookie(paramName);
                acookie.Value = val;
                acookie.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(acookie);
            }
            catch
            {
            }
        }
        public static string GetCookie(string paramName)
        {
            string str = string.Empty;
            try
            {
                if (HttpContext.Current.Request.Cookies[paramName] != null)
                {
                    str = HttpContext.Current.Request.Cookies[paramName].Value;
                }
            }
            catch
            {
            }
            return str;
        }
        public static string DateToString(DateTime dt)
        {
            string result = string.Empty;
            if (dt != Util.DeadDate)
            {
                result = dt.ToString();
            }
            return result;
        }

        public static string GetMonthName(int month)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo cinfo = new System.Globalization.CultureInfo("en-US");
            string monthName = cinfo.DateTimeFormat.GetMonthName(month);
            return monthName.Substring(0, 3);
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

        public static string GetProductImgUrl(object productImg)
        {
            return GetProductImgUrl(productImg, true);
        }
        public static string GetProductNewImgUrl(object productImg)
        {
            string img = "images/none_snew.png";
            if (productImg != null && !string.IsNullOrEmpty(productImg.ToString()))
            {
                img = UploadFilesRootURL + productImg.ToString();
            }
            return img;
        }
        public static string GetProductImgUrl(object productImg, bool isSmall)
        {
            if (productImg != null && !string.IsNullOrEmpty(productImg.ToString()))
            {
                return UploadFilesRootURL + productImg.ToString();
            }
            string img = "images/none.png";
            if (isSmall)
            {
                img = "images/none_s.png";
            }
            return img;
        }

        public static bool IsTesting
        {
            get
            {
                bool ret = false;
                if (System.Configuration.ConfigurationManager.AppSettings["IsTesting"] == null)
                {
                    return false;
                }// end if
                Boolean.TryParse(System.Configuration.ConfigurationManager.AppSettings["IsTesting"].ToString(), out ret);
                return ret;
            }
        }

        public static ArrayList GetMonths()
        {
            ArrayList al = new ArrayList();
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Globalization.CultureInfo cinfo = new System.Globalization.CultureInfo("en-US");
            string[] monthNames = cinfo.DateTimeFormat.MonthNames;
            var mNames = from m in monthNames where !string.IsNullOrEmpty(m) select new { text = m.Substring(0, Math.Min(m.Length, 3)), id = Array.IndexOf(monthNames.ToArray<string>(), m) + 1 };
            foreach (var mon in mNames)
            {
                al.Add(mon);
            }
            return al;
            //return new ArrayList(mNames.ToArray<string>());
        }

        public static ArrayList GetYears(int limit)
        {
            ArrayList al = new ArrayList();
            Int32 i = default(Int32);
            for (i = DateTime.Now.Year - limit; i <= DateTime.Now.Year; i++)
            {
                al.Add(new { text= i.ToString(), id = i });
            }
            return al;
        }

    }
}