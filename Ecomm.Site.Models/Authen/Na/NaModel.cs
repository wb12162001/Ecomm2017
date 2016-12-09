using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quick.Site.Common.Models;
using System.Web.Mvc;

namespace Ecomm.Site.Models.Authen.Na
{
	public class NaModel : EntityCommon
    {
		public NaModel()
		{
		}

        public int Id { get; set; }

        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "名称{2}～{1}个字符")]
        public string Name { get; set; }
    }
}
