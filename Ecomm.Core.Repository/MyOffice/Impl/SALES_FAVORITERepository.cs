//------------------------------------------------------------------------------
// <copyright file="SALES_FAVORITERepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_FAVORITE 
    /// </summary>
    [Export(typeof(ISALES_FAVORITERepository))]
    public class SALES_FAVORITERepository : EFRepositoryBase<SALES_FAVORITE>, ISALES_FAVORITERepository
    {
        public SALES_FAVORITERepository() : base("default")
        {
        }

        public IEnumerable<SALES_FAVORITE_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            System.Data.SqlClient.SqlParameter[] parameters = {
               new System.Data.SqlClient.SqlParameter("@count",count),
               new System.Data.SqlClient.SqlParameter("@strWhere", strWhere),
               new System.Data.SqlClient.SqlParameter("@strOrder",strOrder)
            };
            return base.ExecuteProc<SALES_FAVORITE_MASTER>("USP_SALES_FAVORITE_Query", parameters);
        }

        public string GetFavFolderFirstImg(string favFolderID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select top 1 f0.SmallPic FROM [dbo].[SALES_FAVORITE] a ");
            sb.AppendLine("left join dbo.PROD_MASTER f0 on a.[ProductNo] = f0.[ProductNo] ");
            sb.AppendFormat("where f0.SmallPic<>'' and a.FavFolderID='{0}'", favFolderID);
            object obj = base.ExecuteScalar<string>(sb.ToString());
            if (obj != DBNull.Value && obj != null)
            {
                return obj.ToString();
            }
            else if (!IsFavFolderFirstImg(favFolderID))
            {
                return "ProductImg/Small/no_photo_favourite.png";
            }
            return string.Empty;
        }

        public bool IsFavFolderFirstImg(string favFolderID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(1) as num FROM [dbo].[SALES_FAVORITE] a ");
            sb.AppendFormat("where a.FavFolderID='{0}'", favFolderID);
            object obj = base.ExecuteScalar<int>(sb.ToString());
            return Convert.ToInt32(obj) > 0;
        }
    }
}

