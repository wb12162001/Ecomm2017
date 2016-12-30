//------------------------------------------------------------------------------
// <copyright file="Admin_userMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2016/12/23
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Authen;


namespace Ecomm.Domain.Data.Mapping.Authen
{
    /// <summary>
    /// 数据表映射 —— Admin_user 
    /// </summary>    
	partial class Admin_userMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void Admin_userMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("admin_users");
            // Properties
            // Primary Key
            this.HasKey(t => t.Id);   		
            
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
        }

		
    }
}

