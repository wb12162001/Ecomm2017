//------------------------------------------------------------------------------
// <copyright file="PROD_RELATED_PROPERTYMap.cs">
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
    /// 数据表映射 —— PROD_RELATED_PROPERTY 
    /// </summary>    
	partial class PROD_RELATED_PROPERTYMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_RELATED_PROPERTYMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_RELATED_PROPERTY");
            // Properties
            // Primary Key
            this.HasKey(t => t.ProductNo);   		
            
            this.Property(t => t.ProductNo).HasColumnName("ProductNo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.PropertyID);   		
            
            this.Property(t => t.PropertyID).HasColumnName("PropertyID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

