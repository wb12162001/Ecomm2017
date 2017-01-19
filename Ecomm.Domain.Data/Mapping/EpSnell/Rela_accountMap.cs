//------------------------------------------------------------------------------
// <copyright file="Rela_accountMap.cs">
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
    /// 数据表映射 —— Rela_account 
    /// </summary>    
	partial class Rela_accountMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void Rela_accountMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("rela_account");
            // Properties
            // Primary Key
            this.HasKey(t => t.Id);   		
            
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

