// ===================================================================
// File: SALES_CLEARANCE.cs
// 2017/1/17: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.MyOffice
{
    public class SALES_CLEARANCE : EntityBase<string>
    {
        public SALES_CLEARANCE()
        {
            
        }

		public string ID  { get; set; }


		public string Name  { get; set; }


		public string ImgFile  { get; set; }


		public string Notes  { get; set; }


		public string SortNo  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? StartDate  { get; set; }


		public DateTime? EndDate  { get; set; }


		public int? Status  { get; set; }

        
        
    }
    
    
}

