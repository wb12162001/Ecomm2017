// ===================================================================
// File: RM00102.cs
// 2017/3/15: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomm.Domain.Models.GPSPS
{
    [NotMapped]
    public class RM00102 : EntityBase<string>
    {
        public RM00102()
        {
            
        }

		public string CUSTNMBR  { get; set; }


		public string ADRSCODE  { get; set; }


		public string SLPRSNID  { get; set; }


		public string UPSZONE  { get; set; }


		public string SHIPMTHD  { get; set; }


		public string TAXSCHID  { get; set; }


		public string CNTCPRSN  { get; set; }


		public string ADDRESS1  { get; set; }


		public string ADDRESS2  { get; set; }


		public string ADDRESS3  { get; set; }


		public string COUNTRY  { get; set; }


		public string CITY  { get; set; }


		public string STATE  { get; set; }


		public string ZIP  { get; set; }


		public string PHONE1  { get; set; }


		public string PHONE2  { get; set; }


		public string PHONE3  { get; set; }


		public string FAX  { get; set; }


		public DateTime MODIFDT  { get; set; }


		public DateTime CREATDDT  { get; set; }


		public string GPSFOINTEGRATIONID  { get; set; }


		public short INTEGRATIONSOURCE  { get; set; }


		public string INTEGRATIONID  { get; set; }


		public string CCode  { get; set; }


		public string DECLID  { get; set; }


		public string LOCNCODE  { get; set; }


		public string SALSTERR  { get; set; }


		public string USERDEF1  { get; set; }


		public string USERDEF2  { get; set; }


		public string ShipToName  { get; set; }


		public short Print_Phone_NumberGB  { get; set; }


		public DateTime DEX_ROW_TS  { get; set; }


		public int DEX_ROW_ID  { get; set; }

        
        
    }
    
    
}

