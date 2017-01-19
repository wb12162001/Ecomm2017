// ===================================================================
// File: Rela_contact_location.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_contact_location : EntityBase<string>
    {
        public Rela_contact_location()
        {
            
        }

		public string Account_no  { get; set; }


		public string Contact_id  { get; set; }


		public string Address_no  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Cretuser  { get; set; }


		public string Modiuser  { get; set; }


		public int? Display_order  { get; set; }


		public int Row_id  { get; set; }


		public byte Status  { get; set; }


		public string Item1  { get; set; }


		public string Item2  { get; set; }


		public string Item3  { get; set; }


		public string Item4  { get; set; }


		public string Item5  { get; set; }


		public string Item6  { get; set; }

        
        
    }
    
    
}

