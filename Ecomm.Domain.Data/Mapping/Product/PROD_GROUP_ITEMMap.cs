//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_ITEMMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2016/12/28
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Domain.Data.Mapping.Product
{
    /// <summary>
    /// 数据表映射 —— PROD_GROUP_ITEM 
    /// </summary>    
	partial class PROD_GROUP_ITEMMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_GROUP_ITEMMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_GROUP_ITEM");
            // Properties
            // Primary Key
            this.HasKey(t => t.ProductID);   		
            
            //this.Property(t => t.ProductID).HasColumnName("ProductID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.GROUP_INDEX);

            //this.Property(t => t.GROUP_INDEX).HasColumnName("GROUP_INDEX").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
            //this.HasOptional(t => t.Group).WithMany().HasForeignKey(d => d.GROUP_INDEX).WillCascadeOnDelete(false); 
            //this.HasOptional(t => t.Product).WithMany().HasForeignKey(d => d.ProductID).WillCascadeOnDelete(false);
        }

		
    }
}

