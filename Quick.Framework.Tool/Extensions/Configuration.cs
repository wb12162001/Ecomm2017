/* ==============================================================================
 * 功能描述：Configuration  
 * 创 建 者：蒲奎民
 * 创建日期：2016-08-29 10:47:49
 * CLR Version :4.0.30319.42000
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Quick.Framework.Tool
{
    public static class ConfigurationExt
    {
        /// <summary>
        /// 或取应用程序 Bin 路径
        /// </summary>
        /// <param name="inWeb">是否 web 应用</param>
        /// <returns></returns>
        public static IList<Assembly> DefaultAssemblies(bool inWeb)
        {
            var exts = new[] { "exe", "dll" };
            var dir = inWeb ? HttpRuntime.BinDirectory : AppDomain.CurrentDomain.BaseDirectory;
            var ns = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;//获取本类的命名空间
            var nsStrs = ns.Split(new char[] { '.' });//拆分要取命名空间前缀
            var files = Directory.EnumerateFiles(dir, nsStrs[0] + "*", SearchOption.TopDirectoryOnly)
                .Where(file => exts.Any(x => file.EndsWith(x, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            return files.Select(Assembly.LoadFrom).ToList();
        }

        public static ContainerConfiguration WithDefaultAssemblies(this ContainerConfiguration configuration)
        {
            configuration.WithAssemblies(DefaultAssemblies(true));
            return configuration;
        }
        public static bool IsInNamespace(this Type type, string namespaceFragment)
        {
            return type.Namespace != null && (type.Namespace.EndsWith("." + namespaceFragment) || type.Namespace.Contains("." + namespaceFragment + "."));
        }
    }
}
