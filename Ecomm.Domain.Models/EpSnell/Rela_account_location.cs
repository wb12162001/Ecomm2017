// ===================================================================
// File: Rela_account_location.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_account_location : EntityBase<string>
    {
        public Rela_account_location()
        {
            
        }

		public string Account_no  { get; set; }


		public string Address_id  { get; set; }


		public string Name  { get; set; }


		public string Description  { get; set; }


		public string Contact_id  { get; set; }


		public string Address1  { get; set; }


		public string Address2  { get; set; }


		public string City  { get; set; }


		public string State  { get; set; }


		public string Country  { get; set; }


		public string Zip  { get; set; }


		public string P_address1  { get; set; }


		public string P_address2  { get; set; }


		public string P_city  { get; set; }


		public string P_state  { get; set; }


		public string P_country  { get; set; }


		public string P_zip  { get; set; }


		public string Phone1  { get; set; }


		public string Phone2  { get; set; }


		public string Fax  { get; set; }


		public string Email  { get; set; }


		public string Www  { get; set; }


		public string Isort  { get; set; }


		public string Pic_s  { get; set; }


		public string Pic_b  { get; set; }


		public string Detail  { get; set; }


		public byte? Status  { get; set; }


		public string Cretuser  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Modiuser  { get; set; }


		public int Row_id  { get; set; }

        
        
    }

    [NotMapped]
    public class Rela_account_location_shipto
    {
        public string address1 { get; set; }

        public string address2 { get; set; }
        public string address_id { get; set; }
        public string description { get; set; }

        public string contact_id { get; set; }

        public int isSel { get; set; }

    }

    [NotMapped]
    public class Rela_account_location_shipto_item
    {
        public string id { get; set; }

        public string name { get; set; }

    }


}

