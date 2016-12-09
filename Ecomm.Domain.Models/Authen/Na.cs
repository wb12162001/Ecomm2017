using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Authen
{
    public class Na : EntityBase<int>
    {
        public string Name { get; set; }

        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }

    }
}
