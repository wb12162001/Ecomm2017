//------------------------------------------------------------------------------
// <copyright file="EOrderMap.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Domain.Data.Mapping
//		生成时间：2017/3/22
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.InetApp;


namespace Ecomm.Domain.Data.Mapping.InetApp
{
    /// <summary>
    /// 数据表映射 —— EOrder 
    /// </summary>    
	partial class EOrderMap
    {
        /// <summary>
		/// 映射配置
		/// </summary>
        partial void EOrderMapAppend()
        {
            // Table & Column Mappings
            this.ToTable("EOrders");
            // Properties
            // Primary Key
            this.HasKey(t => t.OrderID);   		
            
            this.Property(t => t.OrderID).HasColumnName("OrderID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Relation
            /*
             * 出现错误: 当 IDENTITY_INSERT 设置为 OFF 时，不能为表 'EOrders' 中的标识列插入显式值。
             * 是因为EOrders表的主键是: OrderID 为int; (Domain.Models 下的EOrder.cs的基类要修改为int) 这里需要把它设为: DatabaseGeneratedOption.Identity 自动递增,在insert 
             * 语句中就不会出现它;
             */
        }


    }
}

