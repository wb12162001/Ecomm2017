// ===================================================================
// File: INFOR_MASTER.cs
// 2017/1/5: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.SysConfig
{
    public class INFOR_MASTER : EntityBase<string>
    {
        public INFOR_MASTER()
        {
            
        }

		public string ID  { get; set; }


		public string InforSubject  { get; set; }


		public string InforCategoryID  { get; set; }

        [ForeignKey("InforCategoryID")]
        public virtual INFOR_CATEGORIES InforCategory { get; set; }


		public string Introduction  { get; set; }


		public string Author  { get; set; }


		public int? ViewTimes  { get; set; }


		public string Description  { get; set; }


		public string Creator  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public int? DisplayOrder  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }


		public bool IsOuterLink  { get; set; }


		public string ActiveLink  { get; set; }


		public string Target  { get; set; }


		public string LinkTitle  { get; set; }


		public string LinkText  { get; set; }


		public string LinkStyle  { get; set; }


		public string ParentID  { get; set; }

        
        
    }

    [NotMapped]
    public class INFOR_MASTER_PAGE:INFOR_MASTER
    {
        public string InforCategoryName { get; set; }
        public string ParentSubject { get; set; }
        public string color { get; set; }
    }


}

