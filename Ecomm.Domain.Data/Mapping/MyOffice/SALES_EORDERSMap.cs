//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERSMap.cs">
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
    /// 数据表映射 —— SALES_EORDERS 
    /// </summary>    
	partial class SALES_EORDERSMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SALES_EORDERSMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SALES_EORDERS");
            // Properties
            // Primary Key
            this.HasKey(t => t.ID);   		
            
            this.Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

