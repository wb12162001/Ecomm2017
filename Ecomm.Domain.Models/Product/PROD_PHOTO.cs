// ===================================================================
// File: PROD_PHOTO.cs
// 2017/2/6: Ben Wang    Original Version
// ===================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Product
{
    public class PROD_PHOTO : EntityBase<string>
    {
        public PROD_PHOTO()
        {
            
        }

		public string ID  { get; set; }


		public string PhotoTitle  { get; set; }


		public string FilePath  { get; set; }


		public int? IsDefault  { get; set; }


		public int? PhotoType  { get; set; }


		public string EntityID  { get; set; }


		public string SmallPic  { get; set; }


		public string BigPic  { get; set; }


		public string MiddlePic  { get; set; }


		public DateTime? CreateDate  { get; set; }


		public DateTime? ModiDate  { get; set; }


		public string Creator  { get; set; }


		public string Modifier  { get; set; }


		public int? DisplayOrder  { get; set; }


		public int? Status  { get; set; }


		public string Item01  { get; set; }


		public string Item02  { get; set; }


		public string Item03  { get; set; }


		public string Item04  { get; set; }


		public string Item05  { get; set; }

        
        
    }
    
    
}

