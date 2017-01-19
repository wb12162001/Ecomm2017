// ===================================================================
// File: Rela_account_quote.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_account_quote : EntityBase<string>
    {
        public Rela_account_quote()
        {
            
        }

		public string Quote_id  { get; set; }


		public string Account_no  { get; set; }


		public string Item_no  { get; set; }


		public double? Price  { get; set; }


		public double? Cost  { get; set; }


		public double? Gp  { get; set; }


		public string Unit  { get; set; }


		public byte? Status  { get; set; }


		public string Account_type  { get; set; }


		public string Reference  { get; set; }


		public string Cretuser  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Modiuser  { get; set; }

        
        
    }
    
    
}

