//------------------------------------------------------------------------------
// <copyright file="PROD_RELATEDITEMMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/2/6
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Domain.Data.Mapping.Product
{
    /// <summary>
    /// 数据表映射 —— PROD_RELATEDITEM 
    /// </summary>    
	partial class PROD_RELATEDITEMMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_RELATEDITEMMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_RELATEDITEM");
            // Properties
            // Primary Key
            this.HasKey(t => new { t.ProductNo, t.RelatedID });  		
            
            //this.Property(t => t.ProductNo).HasColumnName("ProductNo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.HasKey(t => t.RelatedID);   		
            
            //this.Property(t => t.RelatedID).HasColumnName("RelatedID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
            //this.HasRequired(a => a.Product).WithMany().Map(l => l.MapKey("RelatedID")).WillCascadeOnDelete(false);
        }

		
    }
}

