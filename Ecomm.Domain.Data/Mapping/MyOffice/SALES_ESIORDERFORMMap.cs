﻿//------------------------------------------------------------------------------
// <copyright file="SALES_ESIORDERFORMMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;


namespace Ecomm.Domain.Data.Mapping.MyOffice
{
    /// <summary>
    /// 数据表映射 —— SALES_ESIORDERFORM 
    /// </summary>    
	partial class SALES_ESIORDERFORMMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SALES_ESIORDERFORMMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SALES_ESIORDERFORM");
            // Properties
            // Primary Key
            this.HasKey(t => new { t.CustomerID, t.ProductNo, t.ShipTo });   		
            
            this.Property(t => t.CustomerID).HasColumnName("CustomerID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.HasKey(t => t.ProductNo);   		
            
            this.Property(t => t.ProductNo).HasColumnName("ProductNo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //this.HasKey(t => t.ShipTo);   		
            
            this.Property(t => t.ShipTo).HasColumnName("ShipTo").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

