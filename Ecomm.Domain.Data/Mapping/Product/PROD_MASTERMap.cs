//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2016/12/20
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Domain.Data.Mapping.Product
{
    /// <summary>
    /// 数据表映射 —— PROD_MASTER 
    /// </summary>    
	partial class PROD_MASTERMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void PROD_MASTERMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("PROD_MASTER");
            // Properties
            // Primary Key
            // Relation
        }

        //public DbSet<PROD_MASTER> Products { get; set; }

    }
}

