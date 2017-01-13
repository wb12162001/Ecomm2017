//------------------------------------------------------------------------------
// <copyright file="SYS_PROPERTYMap.cs">
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
    /// 数据表映射 —— SYS_PROPERTY 
    /// </summary>    
	partial class SYS_PROPERTYMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SYS_PROPERTYMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SYS_PROPERTY");
            // Properties
            // Primary Key
            this.HasKey(t => t.PropertyID);   		
            
            this.Property(t => t.PropertyID).HasColumnName("PropertyID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

