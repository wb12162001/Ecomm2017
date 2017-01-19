//------------------------------------------------------------------------------
// <copyright file="Rela_contact_locationMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/16
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;


namespace Ecomm.Domain.Data.Mapping.EpSnell
{
    /// <summary>
    /// 数据表映射 —— Rela_contact_location 
    /// </summary>    
	partial class Rela_contact_locationMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void Rela_contact_locationMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("rela_contact_location");
            // Properties
            // Primary Key
            this.HasKey(t => t.Account_no);   		
            
            this.Property(t => t.Account_no).HasColumnName("Account_no").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.Contact_id);   		
            
            this.Property(t => t.Contact_id).HasColumnName("Contact_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.Address_no);   		
            
            this.Property(t => t.Address_no).HasColumnName("Address_no").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

