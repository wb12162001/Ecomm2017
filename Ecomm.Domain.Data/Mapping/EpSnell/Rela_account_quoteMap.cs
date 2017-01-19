//------------------------------------------------------------------------------
// <copyright file="Rela_account_quoteMap.cs">
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
    /// 数据表映射 —— Rela_account_quote 
    /// </summary>    
	partial class Rela_account_quoteMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void Rela_account_quoteMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("rela_account_quote");
            // Properties
            // Primary Key
            this.HasKey(t => t.Quote_id);   		
            
            this.Property(t => t.Quote_id).HasColumnName("Quote_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.Account_no);   		
            
            this.Property(t => t.Account_no).HasColumnName("Account_no").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasKey(t => t.Item_no);   		
            
            this.Property(t => t.Item_no).HasColumnName("Item_no").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

