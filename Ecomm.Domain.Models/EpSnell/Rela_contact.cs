// ===================================================================
// File: Rela_contact.cs
// 2017/1/3: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.EpSnell
{
    public class Rela_contact : EntityBase<string>
    {
        public Rela_contact()
        {
            
        }

		public string Id  { get; set; }


		public string Name  { get; set; }


		public string Title  { get; set; }


		public string Job_title  { get; set; }


		public string Fname  { get; set; }


		public string Lname  { get; set; }


		public string Mname  { get; set; }


		public string Gender  { get; set; }


		public string Account_id  { get; set; }


		public byte? Iskey  { get; set; }


		public string Description  { get; set; }


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


		public string Territory_id  { get; set; }


		public string Home_phone  { get; set; }


		public string Mobile  { get; set; }


		public string Department  { get; set; }


		public DateTime? Birthday  { get; set; }


		public string Assistant  { get; set; }


		public string Assistant_phone  { get; set; }


		public string Report_to  { get; set; }


		public string Lead_source  { get; set; }


		public string Personal_details  { get; set; }


		public string Background  { get; set; }


		public string Family  { get; set; }


		public string Qualifications  { get; set; }


		public string Memberships  { get; set; }


		public string Projects  { get; set; }


		public string Interests  { get; set; }


		public string Quote  { get; set; }


		public string Skills  { get; set; }


		public string Cretuser  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Modiuser  { get; set; }


		public int Row_id  { get; set; }


		public byte? Isprivate  { get; set; }


		public string Owner  { get; set; }


		public byte[] Rn_id  { get; set; }


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


		public bool IsManager  { get; set; }


		public string UserName  { get; set; }


		public string Password  { get; set; }


		public double? QtyLimit  { get; set; }


		public double? AmountLimit  { get; set; }


		public double? ItemQtyLimit  { get; set; }


		public double? ItemAmountLimit  { get; set; }


		public string AccountRole  { get; set; }


		public bool IsContractLimit  { get; set; }


		public string HomePage  { get; set; }


		public string Report_To_Email  { get; set; }

        [ForeignKey("Account_id")]
        public virtual Rela_account AccountInfo { get; set; }

        [NotMapped]
        public double Freight = 0;
        [NotMapped]
        public double Miscellaneous = 0;
        [NotMapped]
        public int PageSize = 12;
        [NotMapped]
        public int EofPageSize = 8;
        [NotMapped]
        public double MinOrderValue {
            get
            {
                if (this.AccountInfo != null)
                {
                    return (double)this.AccountInfo.MinOrderValue;
                }
                return 0;
            }
        }
        [NotMapped]
        public double MinOrderSize
        {
            get
            {
                if (this.AccountInfo != null)
                {
                    return (double)this.AccountInfo.MinOrderSize;
                }
                return 0;
            }
            //set { _minOrderSize = value; }
        }
        [NotMapped]
        public double MinOrderFreight
        {
            get
            {
                if (this.AccountInfo != null)
                {
                    return (double)this.AccountInfo.MinOrderFreight;
                }
                return 0;
            }
            //set { _minOrderFreight = value; }
        }

        [NotMapped]
        public double MinOrderMisc
        {
            get
            {
                if (this.AccountInfo != null)
                {
                    return (double)this.AccountInfo.MinOrderMisc;
                }
                return 0;
            }
            //set { _minOrderMisc = value; }
        }
        [NotMapped]
        public bool IsClearPrice;

    }
    
    
}

