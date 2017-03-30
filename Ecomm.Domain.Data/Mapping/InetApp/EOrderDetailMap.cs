//------------------------------------------------------------------------------
// <copyright file="EOrderDetailMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/3/22
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.InetApp;


namespace Ecomm.Domain.Data.Mapping.InetApp
{
    /// <summary>
    /// 数据表映射 —— EOrderDetail 
    /// </summary>    
	partial class EOrderDetailMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void EOrderDetailMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("EOrderDetails");
            // Properties
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.Sku });	
            
            this.Property(t => t.OrderID).HasColumnName("OrderID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.HasKey(t => t.Sku);   		
            
            this.Property(t => t.Sku).HasColumnName("Sku").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

