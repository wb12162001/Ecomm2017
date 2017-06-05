//------------------------------------------------------------------------------
// <copyright file="INFOR_MASTERService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/5 15:15:54
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.SysConfig;
using Ecomm.Core.Repository.SysConfig;
using Ecomm.Site.Models;
using Ecomm.Site.Models.SysConfig.INFOR_MASTER;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.SysConfig.Impl
{
	/// <summary>
    /// 服务层实现 —— INFOR_MASTERService
    /// </summary>
    [Export(typeof(IINFOR_MASTERService))]
    public class INFOR_MASTERService : CoreServiceBase, IINFOR_MASTERService
    {
        #region 属性

        [Import]
        public IINFOR_MASTERRepository INFOR_MASTERRepository { get; set; }

        public IQueryable<INFOR_MASTER> INFOR_MASTERList
        {
            get { return INFOR_MASTERRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public IEnumerable<INFOR_MASTER_PAGE> QueryEntities(int count, string strWhere, string strOrder)
        {
            return INFOR_MASTERRepository.QueryEntities(count, strWhere, strOrder);
        }

        public OperationResult Insert(INFOR_MASTERModel model)
        {
            var entity = new INFOR_MASTER
            {
                ID = model.ID,
                InforSubject = model.InforSubject,
                InforCategoryID = model.InforCategoryID,
                Introduction = model.Introduction,
                Author = model.Author,
                ViewTimes = model.ViewTimes,
                Description = model.Description,
                Creator = model.Creator,
                CreateDate = model.CreateDate,
                Modifier = model.Modifier,
                ModiDate = model.ModiDate,
                DisplayOrder = model.DisplayOrder,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
                IsOuterLink = model.IsOuterLink,
                ActiveLink = model.ActiveLink,
                Target = model.Target,
                LinkTitle = model.LinkTitle,
                LinkText = model.LinkText,
                LinkStyle = model.LinkStyle,
                ParentID = model.ParentID,
            };
            INFOR_MASTERRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(INFOR_MASTERModel model)
        {
			var entity = INFOR_MASTERList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.InforSubject = model.InforSubject;
            entity.InforCategoryID = model.InforCategoryID;
            entity.Introduction = model.Introduction;
            entity.Author = model.Author;
            entity.ViewTimes = model.ViewTimes;
            entity.Description = model.Description;
            entity.Creator = model.Creator;
            entity.CreateDate = model.CreateDate;
            entity.Modifier = model.Modifier;
            entity.ModiDate = model.ModiDate;
            entity.DisplayOrder = model.DisplayOrder;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;
            entity.IsOuterLink = model.IsOuterLink;
            entity.ActiveLink = model.ActiveLink;
            entity.Target = model.Target;
            entity.LinkTitle = model.LinkTitle;
            entity.LinkText = model.LinkText;
            entity.LinkStyle = model.LinkStyle;
            entity.ParentID = model.ParentID;

            INFOR_MASTERRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = INFOR_MASTERList.FirstOrDefault(t => t.ID == ID);

            INFOR_MASTERRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

