//------------------------------------------------------------------------------
// <copyright file="PROD_PROPERTIESMap.cs">
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
    /// 数据表映射 —— PROD_PROPERTIES 
    /// </summary>    
	partial class PROD_PROPERTIESMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_PROPERTIESMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_PROPERTIES");
            // Properties
            // Primary Key
            this.HasKey(t => t.ID);   		
            
            this.Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

