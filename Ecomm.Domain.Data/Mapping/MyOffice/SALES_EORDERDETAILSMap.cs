//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERDETAILSMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/12
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Domain.Data.Mapping.MyOffice
{
    /// <summary>
    /// 数据表映射 —— SALES_EORDERDETAILS 
    /// </summary>    
	partial class SALES_EORDERDETAILSMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SALES_EORDERDETAILSMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SALES_EORDERDETAILS");
            // Properties
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.ProductNo });  		
            
            this.Property(t => t.OrderID).HasColumnName("OrderID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.HasKey(t => t.ProductNo);   		
            
            this.Property(t => t.ProductNo).HasColumnName("ProductNo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

