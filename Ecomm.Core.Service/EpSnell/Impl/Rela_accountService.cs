//------------------------------------------------------------------------------
// <copyright file="Rela_accountService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/16 17:42:26
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
using Ecomm.Site.Models.EpSnell.Rela_account;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_accountService
    /// </summary>
    [Export(typeof(IRela_accountService))]
    public class Rela_accountService : CoreServiceBase, IRela_accountService
    {
        #region 属性

        [Import]
        public IRela_accountRepository Rela_accountRepository { get; set; }

        public IQueryable<Rela_account> Rela_accountList
        {
            get { return Rela_accountRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_accountModel model)
        {
            var entity = new Rela_account
            {
                Id = model.Id,
                Account_type = model.Account_type,
                Account_no = model.Account_no,
                Pid = model.Pid,
                Name = model.Name,
                Description = model.Description,
                Contact_id = model.Contact_id,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                Country = model.Country,
                Zip = model.Zip,
                P_address1 = model.P_address1,
                P_address2 = model.P_address2,
                P_city = model.P_city,
                P_state = model.P_state,
                P_country = model.P_country,
                P_zip = model.P_zip,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Fax = model.Fax,
                Email = model.Email,
                Www = model.Www,
                Territory_id = model.Territory_id,
                Region_id = model.Region_id,
                Rating = model.Rating,
                Employees = model.Employees,
                Industry = model.Industry,
                Ownership = model.Ownership,
                Onhold = model.Onhold,
                Payment_term = model.Payment_term,
                Currency_id = model.Currency_id,
                Revenue = model.Revenue,
                Ticker_symbol = model.Ticker_symbol,
                Sic_code = model.Sic_code,
                Isort = model.Isort,
                Pic_s = model.Pic_s,
                Pic_b = model.Pic_b,
                Detail = model.Detail,
                Rep_id = model.Rep_id,
                Open_date = model.Open_date,
                Ship_method = model.Ship_method,
                Account_class = model.Account_class,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                Item5 = model.Item5,
                Item6 = model.Item6,
                Class1 = model.Class1,
                Class2 = model.Class2,
                Class3 = model.Class3,
                Class4 = model.Class4,
                Class5 = model.Class5,
                Class6 = model.Class6,
                MinOrderValue = model.MinOrderValue,
                MinOrderSize = model.MinOrderSize,
                MinOrderFreight = model.MinOrderFreight,
                MinOrderMisc = model.MinOrderMisc,
                Status = model.Status,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
                Row_id = model.Row_id,
                Isprivate = model.Isprivate,
                Owner = model.Owner,
                Rn_id = model.Rn_id,
                EcomRecommend = model.EcomRecommend,
            };
            Rela_accountRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_accountModel model)
        {
			var entity = Rela_accountList.First(t => t.Id == model.Id);
            entity.Id = model.Id;
            entity.Account_type = model.Account_type;
            entity.Account_no = model.Account_no;
            entity.Pid = model.Pid;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Contact_id = model.Contact_id;
            entity.Address1 = model.Address1;
            entity.Address2 = model.Address2;
            entity.City = model.City;
            entity.State = model.State;
            entity.Country = model.Country;
            entity.Zip = model.Zip;
            entity.P_address1 = model.P_address1;
            entity.P_address2 = model.P_address2;
            entity.P_city = model.P_city;
            entity.P_state = model.P_state;
            entity.P_country = model.P_country;
            entity.P_zip = model.P_zip;
            entity.Phone1 = model.Phone1;
            entity.Phone2 = model.Phone2;
            entity.Fax = model.Fax;
            entity.Email = model.Email;
            entity.Www = model.Www;
            entity.Territory_id = model.Territory_id;
            entity.Region_id = model.Region_id;
            entity.Rating = model.Rating;
            entity.Employees = model.Employees;
            entity.Industry = model.Industry;
            entity.Ownership = model.Ownership;
            entity.Onhold = model.Onhold;
            entity.Payment_term = model.Payment_term;
            entity.Currency_id = model.Currency_id;
            entity.Revenue = model.Revenue;
            entity.Ticker_symbol = model.Ticker_symbol;
            entity.Sic_code = model.Sic_code;
            entity.Isort = model.Isort;
            entity.Pic_s = model.Pic_s;
            entity.Pic_b = model.Pic_b;
            entity.Detail = model.Detail;
            entity.Rep_id = model.Rep_id;
            entity.Open_date = model.Open_date;
            entity.Ship_method = model.Ship_method;
            entity.Account_class = model.Account_class;
            entity.Item1 = model.Item1;
            entity.Item2 = model.Item2;
            entity.Item3 = model.Item3;
            entity.Item4 = model.Item4;
            entity.Item5 = model.Item5;
            entity.Item6 = model.Item6;
            entity.Class1 = model.Class1;
            entity.Class2 = model.Class2;
            entity.Class3 = model.Class3;
            entity.Class4 = model.Class4;
            entity.Class5 = model.Class5;
            entity.Class6 = model.Class6;
            entity.MinOrderValue = model.MinOrderValue;
            entity.MinOrderSize = model.MinOrderSize;
            entity.MinOrderFreight = model.MinOrderFreight;
            entity.MinOrderMisc = model.MinOrderMisc;
            entity.Status = model.Status;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;
            entity.Row_id = model.Row_id;
            entity.Isprivate = model.Isprivate;
            entity.Owner = model.Owner;
            entity.Rn_id = model.Rn_id;
            entity.EcomRecommend = model.EcomRecommend;

            Rela_accountRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Id)
        {
            var model = Rela_accountList.FirstOrDefault(t => t.Id == Id);

            Rela_accountRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

