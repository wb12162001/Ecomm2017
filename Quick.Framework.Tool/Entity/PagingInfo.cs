using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Framework.Tool.Entity
{
    public class PagingInfo
    {
        public PagingInfo()
        {
            PageIndex = 1;
            NeedPage = true;
        }

        /// <summary>
        /// 是否需要分页，用于控制是否分页，默认为true
        /// </summary>
        public bool NeedPage { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int RecCount { get; set; }

        /// <summary>
        /// 计算页数
        /// </summary>
        /// <returns></returns>
        public int CalcPageCount()
        {
            if ((PageSize != 0) && (this.RecCount != 0))
            {
                return (int)Math.Ceiling(RecCount / ((double)PageSize));
            }
            return 0;
        }
    }
}
