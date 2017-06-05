// ===================================================================
// File: SALES_FAVFOLDER.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_FAVFOLDER : EntityBase<string>
    {
        public SALES_FAVFOLDER()
        {
            
        }

		public string ID  { get; set; }


		public string FolderName  { get; set; }


		public string CustomerID  { get; set; }


		public string ContactID  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public int? Status  { get; set; }

        
        
    }

    [NotMapped]
    public class MyFavFolders
    {
        public string ID { get; set; }
        public int itemCount { get; set; }
        public string FolderName { get; set; }
    }
}

