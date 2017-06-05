//------------------------------------------------------------------------------
// <copyright file="SALES_FAVORITEService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/17 15:51:35
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.MyOffice;
using Ecomm.Core.Repository.MyOffice;
using Ecomm.Site.Models;
using Ecomm.Site.Models.MyOffice.SALES_FAVORITE;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_FAVORITEService
    /// </summary>
    [Export(typeof(ISALES_FAVORITEService))]
    public class SALES_FAVORITEService : CoreServiceBase, ISALES_FAVORITEService
    {
        #region 属性

        [Import]
        public ISALES_FAVORITERepository SALES_FAVORITERepository { get; set; }

        public IQueryable<SALES_FAVORITE> SALES_FAVORITEList
        {
            get { return SALES_FAVORITERepository.Entities; }
        }

        #endregion

        #region 公共方法

        public IEnumerable<SALES_FAVORITE_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            return SALES_FAVORITERepository.QueryEntities(count, strWhere, strOrder);
        }

        public IEnumerable<SALES_FAVORITE_MASTER> GetAllByCondition(string custID, string contactID,string strWhere)
        {
            List<string> condition = new List<string>();
            string sql = string.Empty;
            if (!string.IsNullOrEmpty(strWhere))
            {
                condition.Add(strWhere);
            }

            if (!string.IsNullOrEmpty(custID))
            {
                condition.Add(string.Format("a.[CustomerID]='{0}'", custID));
            }
            if (!string.IsNullOrEmpty(contactID))
            {
                condition.Add(string.Format("a.[ContactID]='{0}'", contactID));
            }
           
            if (condition.Count > 0) sql = string.Join(" and ", condition.ToArray());
            return QueryEntities(0, sql, string.Empty);
        }

        public OperationResult Insert(SALES_FAVORITEModel model)
        {
            var entity = new SALES_FAVORITE
            {
                ID = model.ID,
                FavFolderID = model.FavFolderID,
                ProductNo = model.ProductNo,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                Status = model.Status,
            };
            SALES_FAVORITERepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_FAVORITEModel model)
        {
			var entity = SALES_FAVORITEList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.FavFolderID = model.FavFolderID;
            entity.ProductNo = model.ProductNo;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.Status = model.Status;

            SALES_FAVORITERepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_FAVORITEList.FirstOrDefault(t => t.ID == ID);

            SALES_FAVORITERepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        /// <summary>
        /// 使用在FavoriteFolder.aspx页面上，每个Folder取一张图显示
        /// Ben 2016-01-21
        /// </summary>
        /// <param name="custID"></param>
        /// <param name="contactID"></param>
        /// <returns></returns>
        public string GetFavFolderFirstImg(string favFolderID)
        {
            string returnValue = string.Empty;
            returnValue = SALES_FAVORITERepository.GetFavFolderFirstImg(favFolderID);
            //if (returnValue != null && !string.IsNullOrEmpty(returnValue))
            //{
            //    returnValue = Ecomm.Site.WebApp.Common.Util.UploadFilesRootURL + returnValue;
            //}
            return returnValue;
        }

       #endregion
    }
}

