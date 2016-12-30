using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Text;


namespace Quick.Framework.Tool
{
    /// <summary>
    ///     枚举扩展方法类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     获取枚举项的Description特性的描述文字
        /// </summary>
        /// <param name="enumeration"> </param>
        /// <returns> </returns>
        public static string ToDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] members = type.GetMember(enumeration.CastTo<string>());
            if (members.Length > 0)
            {
                return members[0].ToDescription();
            }
            return enumeration.CastTo<string>();
        }

        /// <summary>
        /// 根据枚举类型返回类型中的所有值，文本及描述
        /// </summary>
        /// <param name="type"></param>
        /// <returns>返回三列数组，第0列为Description,第1列为Value，第2列为Text</returns>
        public static IEnumerable<EnumItem> GetEnumOpt(this Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            for (int i = 0, count = fields.Length; i < count; i++)
            {
                FieldInfo field = fields[i];
                var desc = field.Name;

                object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs != null && objs.Length > 0)
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    desc = da.Description;
                }
                yield return new EnumItem { Description = desc, Name = field.Name, Value = Convert.ToInt32(Enum.Parse(type, field.Name)) };
            }
        }

    }

    public class EnumItem
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}