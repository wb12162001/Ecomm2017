// ===================================================================
// File: Rela_account.cs
// 2017/1/16: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_account : EntityBase<string>
    {
        public Rela_account()
        {
            
        }

		public string Id  { get; set; }


		public string Account_type  { get; set; }


		public string Account_no  { get; set; }


		public string Pid  { get; set; }


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


		public string Territory_id  { get; set; }


		public string Region_id  { get; set; }


		public string Rating  { get; set; }


		public string Employees  { get; set; }


		public string Industry  { get; set; }


		public string Ownership  { get; set; }


		public string Onhold  { get; set; }


		public string Payment_term  { get; set; }


		public string Currency_id  { get; set; }


		public string Revenue  { get; set; }


		public string Ticker_symbol  { get; set; }


		public string Sic_code  { get; set; }


		public string Isort  { get; set; }


		public string Pic_s  { get; set; }


		public string Pic_b  { get; set; }


		public string Detail  { get; set; }


		public string Rep_id  { get; set; }


		public DateTime? Open_date  { get; set; }


		public string Ship_method  { get; set; }


		public string Account_class  { get; set; }


		public string Item1  { get; set; }


		public string Item2  { get; set; }


		public string Item3  { get; set; }


		public string Item4  { get; set; }


		public string Item5  { get; set; }


		public string Item6  { get; set; }


		public string Class1  { get; set; }


		public string Class2  { get; set; }


		public string Class3  { get; set; }


		public string Class4  { get; set; }


		public string Class5  { get; set; }


		public string Class6  { get; set; }


		public decimal? MinOrderValue  { get; set; }


		public decimal? MinOrderSize  { get; set; }


		public decimal? MinOrderFreight  { get; set; }


		public decimal? MinOrderMisc  { get; set; }


		public byte? Status  { get; set; }


		public string Cretuser  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Modiuser  { get; set; }


		public int Row_id  { get; set; }


		public byte? Isprivate  { get; set; }


		public string Owner  { get; set; }


		public byte[] Rn_id  { get; set; }


		public byte? EcomRecommend  { get; set; }

        
        
    }
    
    
}

