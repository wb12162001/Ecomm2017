//------------------------------------------------------------------------------
// <copyright file="Rela_account_contractpriceService.cs">
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
using Ecomm.Site.Models.EpSnell.Rela_account_contractprice;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_account_contractpriceService
    /// </summary>
    [Export(typeof(IRela_account_contractpriceService))]
    public class Rela_account_contractpriceService : CoreServiceBase, IRela_account_contractpriceService
    {
        #region 属性

        [Import]
        public IRela_account_contractpriceRepository Rela_account_contractpriceRepository { get; set; }

        public IQueryable<Rela_account_contractprice> Rela_account_contractpriceList
        {
            get { return Rela_account_contractpriceRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_account_contractpriceModel model)
        {
            var entity = new Rela_account_contractprice
            {
                Account_no = model.Account_no,
                Item_no = model.Item_no,
                Price = model.Price,
                Cost = model.Cost,
                Gp = model.Gp,
                Unit = model.Unit,
                Status = model.Status,
                Account_type = model.Account_type,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
                Start_date = model.Start_date,
                End_date = model.End_date,
            };
            Rela_account_contractpriceRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_account_contractpriceModel model)
        {
			var entity = Rela_account_contractpriceList.First(t => t.Account_no == model.Account_no && t.Item_no == model.Item_no);
            entity.Account_no = model.Account_no;
            entity.Item_no = model.Item_no;
            entity.Price = model.Price;
            entity.Cost = model.Cost;
            entity.Gp = model.Gp;
            entity.Unit = model.Unit;
            entity.Status = model.Status;
            entity.Account_type = model.Account_type;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;
            entity.Start_date = model.Start_date;
            entity.End_date = model.End_date;

            Rela_account_contractpriceRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Account_no,string  Item_no)
        {
            var model = Rela_account_contractpriceList.FirstOrDefault(t => t.Account_no == Account_no && t.Item_no == Item_no);

            Rela_account_contractpriceRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

