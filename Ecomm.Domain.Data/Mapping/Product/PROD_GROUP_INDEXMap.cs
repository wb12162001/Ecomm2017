//------------------------------------------------------------------------------
// <copyright file="PROD_GROUP_INDEXMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2016/12/28
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Domain.Data.Mapping.Product
{
    /// <summary>
    /// 数据表映射 —— PROD_GROUP_INDEX 
    /// </summary>    
	partial class PROD_GROUP_INDEXMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_GROUP_INDEXMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_GROUP_INDEX");
            // Properties
            // Primary Key
            this.HasKey(t => t.ID);   		
            
            this.Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            // Relation
            this.HasOptional(t => t.ParentGroup).WithMany(t => t.ChildGroup).HasForeignKey(d => d.ParentID);
        }

		
    }
}

