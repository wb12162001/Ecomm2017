//------------------------------------------------------------------------------
// <copyright file="SALES_FAVFOLDERRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/17
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.MyOffice;
using System.Text;
using System.Collections.Generic;

namespace Ecomm.Core.Repository.MyOffice
{
	/// <summary>
    /// 仓储操作层接口 —— SALES_FAVFOLDER 
    /// </summary>
    [Export(typeof(ISALES_FAVFOLDERRepository))]
    public class SALES_FAVFOLDERRepository : EFRepositoryBase<SALES_FAVFOLDER>, ISALES_FAVFOLDERRepository
    {
        public SALES_FAVFOLDERRepository() : base("default")
        {
        }

        public List<MyFavFolders> GetFavFoldersAndItemCount(string custID, string contactID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select a.ID,a.FolderName,isnull(f0.itemCount,0) as itemCount from dbo.SALES_FAVFOLDER a");
            sb.AppendLine(" left join ( ");
            sb.AppendLine(" select count(1) as itemCount, FavFolderID from dbo.SALES_FAVORITE");
            sb.AppendFormat(" where CustomerID='{0}' and ContactID='{1}'", custID, contactID);
            sb.AppendLine();
            sb.AppendLine(" group by FavFolderID) f0 on a.ID=f0.FavFolderID");
            sb.AppendFormat(" where a.CustomerID='{0}' and a.ContactID='{1}'", custID, contactID);
            sb.AppendLine();
            return base.ExcuteQuery<MyFavFolders>(sb.ToString());
        }


        public int Delete(string favId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM [dbo].[SALES_FAVORITE] where FavFolderID='{0}'", favId).AppendLine();
            sb.AppendFormat("DELETE FROM dbo.SALES_FAVFOLDER where ID='{0}'", favId).AppendLine();
            return base.ExcuteNoQuery(sb.ToString(), System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction);
        }

        
    }
}

