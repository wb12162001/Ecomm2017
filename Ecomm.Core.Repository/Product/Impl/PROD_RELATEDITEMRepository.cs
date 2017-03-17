//------------------------------------------------------------------------------
// <copyright file="PROD_RELATEDITEMRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/2/6
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_RELATEDITEM 
    /// </summary>
    [Export(typeof(IPROD_RELATEDITEMRepository))]
    public class PROD_RELATEDITEMRepository : EFRepositoryBase<PROD_RELATEDITEM>, IPROD_RELATEDITEMRepository
    {
        public PROD_RELATEDITEMRepository() : base("default")
        {
        }

        public IEnumerable<PROD_RELATEDITEM_MASTER> GetEntitiesBySql()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select a.*,");
            sb.AppendLine(" b.ProductNo as RELATD_ProductNo, b.ID,b.ProductName,b.SmallPic,b.BigPic, ");
            sb.AppendLine(" b.CategoryCode, b.BaseUOFM,b.StockType, b.ListPrice,b.SpecialPrice ");
            sb.AppendLine(" from dbo.PROD_RELATEDITEM a left join dbo.PROD_MASTER b on b.ProductNo = a.RelatedID");
            return base.EFContext.DbContext.Database.SqlQuery<PROD_RELATEDITEM_MASTER>(sb.ToString());
        }
    }
}

