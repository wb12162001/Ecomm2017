//------------------------------------------------------------------------------
// <copyright file="SYS_DICTIONARYMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/1/5
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.SysConfig;


namespace Ecomm.Domain.Data.Mapping.SysConfig
{
    /// <summary>
    /// 数据表映射 —— SYS_DICTIONARY 
    /// </summary>    
	partial class SYS_DICTIONARYMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SYS_DICTIONARYMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SYS_DICTIONARY");
            // Properties
            // Primary Key
            this.HasKey(t => t.DictionaryValue);   		
            
            this.Property(t => t.DictionaryValue).HasColumnName("DictionaryValue").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

