//------------------------------------------------------------------------------
// <copyright file="Rela_account_quoteService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:27
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.EpSnell;
using Ecomm.Core.Repository.EpSnell;
using Ecomm.Site.Models;
using Ecomm.Site.Models.EpSnell.Rela_account_quote;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_account_quoteService
    /// </summary>
    [Export(typeof(IRela_account_quoteService))]
    public class Rela_account_quoteService : CoreServiceBase, IRela_account_quoteService
    {
        #region 属性

        [Import]
        public IRela_account_quoteRepository Rela_account_quoteRepository { get; set; }

        public IQueryable<Rela_account_quote> Rela_account_quoteList
        {
            get { return Rela_account_quoteRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_account_quoteModel model)
        {
            var entity = new Rela_account_quote
            {
                Quote_id = model.Quote_id,
                Account_no = model.Account_no,
                Item_no = model.Item_no,
                Price = model.Price,
                Cost = model.Cost,
                Gp = model.Gp,
                Unit = model.Unit,
                Status = model.Status,
                Account_type = model.Account_type,
                Reference = model.Reference,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
            };
            Rela_account_quoteRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_account_quoteModel model)
        {
			var entity = Rela_account_quoteList.First(t => t.Quote_id == model.Quote_id && t.Account_no == model.Account_no && t.Item_no == model.Item_no);
            entity.Quote_id = model.Quote_id;
            entity.Account_no = model.Account_no;
            entity.Item_no = model.Item_no;
            entity.Price = model.Price;
            entity.Cost = model.Cost;
            entity.Gp = model.Gp;
            entity.Unit = model.Unit;
            entity.Status = model.Status;
            entity.Account_type = model.Account_type;
            entity.Reference = model.Reference;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;

            Rela_account_quoteRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Quote_id,string  Account_no,string  Item_no)
        {
            var model = Rela_account_quoteList.FirstOrDefault(t => t.Quote_id == Quote_id && t.Account_no == Account_no && t.Item_no == Item_no);

            Rela_account_quoteRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

