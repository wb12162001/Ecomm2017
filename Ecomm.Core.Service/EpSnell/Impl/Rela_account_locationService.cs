//------------------------------------------------------------------------------
// <copyright file="Rela_account_locationService.cs">
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
using Ecomm.Site.Models.EpSnell.Rela_account_location;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_account_locationService
    /// </summary>
    [Export(typeof(IRela_account_locationService))]
    public class Rela_account_locationService : CoreServiceBase, IRela_account_locationService
    {
        #region 属性

        [Import]
        public IRela_account_locationRepository Rela_account_locationRepository { get; set; }

        public IQueryable<Rela_account_location> Rela_account_locationList
        {
            get { return Rela_account_locationRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_account_locationModel model)
        {
            var entity = new Rela_account_location
            {
                Account_no = model.Account_no,
                Address_id = model.Address_id,
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
                Isort = model.Isort,
                Pic_s = model.Pic_s,
                Pic_b = model.Pic_b,
                Detail = model.Detail,
                Status = model.Status,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
                Row_id = model.Row_id,
            };
            Rela_account_locationRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_account_locationModel model)
        {
			var entity = Rela_account_locationList.First(t => t.Account_no == model.Account_no && t.Address_id == model.Address_id);
            entity.Account_no = model.Account_no;
            entity.Address_id = model.Address_id;
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
            entity.Isort = model.Isort;
            entity.Pic_s = model.Pic_s;
            entity.Pic_b = model.Pic_b;
            entity.Detail = model.Detail;
            entity.Status = model.Status;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;
            entity.Row_id = model.Row_id;

            Rela_account_locationRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Account_no,string  Address_id)
        {
            var model = Rela_account_locationList.FirstOrDefault(t => t.Account_no == Account_no && t.Address_id == Address_id);

            Rela_account_locationRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

