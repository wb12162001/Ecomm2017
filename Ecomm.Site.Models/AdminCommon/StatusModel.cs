using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ecomm.Site.Models.AdminCommon
{
    public class StatusModel
    {
        public StatusModel()
        {
            EnabledItems = new List<SelectListItem> {
                new SelectListItem { Text = "--- Please select ---", Value = "", Selected = true },
                new SelectListItem { Text = "Disable", Value = "1" },
                new SelectListItem { Text = "Enable", Value = "0" }
            };
        }

        public List<SelectListItem> EnabledItems { get; set; }
    }

    public class TargetModel
    {
        public TargetModel()
        {
            TargetItems = new List<SelectListItem> {
                new SelectListItem { Text = "--- Please select ---", Value = "", Selected = true },
                new SelectListItem { Text = "_blank", Value = "_blank" },
                new SelectListItem { Text = "_parent", Value = "_parent" },
                new SelectListItem { Text = "_self", Value = "_self" },
                new SelectListItem { Text = "_top", Value = "_top" }
            };
        }

        public List<SelectListItem> TargetItems { get; set; }
    }
}
