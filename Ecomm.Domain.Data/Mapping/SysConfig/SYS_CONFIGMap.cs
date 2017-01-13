﻿//------------------------------------------------------------------------------
// <copyright file="SYS_CONFIGMap.cs">
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
    /// 数据表映射 —— SYS_CONFIG 
    /// </summary>    
	partial class SYS_CONFIGMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void SYS_CONFIGMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("SYS_CONFIG");
            // Properties
            // Primary Key
            this.HasKey(t => t.ID);   		
            
            this.Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

