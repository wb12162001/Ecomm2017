//------------------------------------------------------------------------------
// <copyright file="PROD_MASTERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2016/12/20
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Product;


namespace Ecomm.Core.Repository.Product
{
	/// <summary>
    /// 仓储操作层接口 —— PROD_MASTER 
    /// </summary>
    [Export(typeof(IPROD_MASTERRepository))]
    public class PROD_MASTERRepository : EFRepositoryBase<PROD_MASTER>, IPROD_MASTERRepository
    {
        public PROD_MASTERRepository() : base("default")
        {
        }

        public void GetSellingPrice(string itemnmbr, string custnmbr, out double sellPrice, out string priceType)
        {
            sellPrice = 0;
            priceType = string.Empty;

            var sellprice = new System.Data.SqlClient.SqlParameter("@sellprice", System.Data.SqlDbType.Money, 5);
            sellprice.Direction = System.Data.ParameterDirection.Output;
            var ptype = new System.Data.SqlClient.SqlParameter("@ptype", System.Data.SqlDbType.Char, 1);
            ptype.Direction = System.Data.ParameterDirection.Output;

            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@itemnmbr",itemnmbr),
               new System.Data.SqlClient.SqlParameter("@custnmbr", custnmbr),
               sellprice,
               ptype,
            };
            var result = base.ExecuteProc("zx_GetSellingPrice", parameters);

            double.TryParse(result[0].ToString(), out sellPrice);
            priceType = result[1].ToString();
        }
    }
}

