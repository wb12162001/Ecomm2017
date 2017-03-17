//------------------------------------------------------------------------------
// <copyright file="Rela_contactService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/3 15:51:19
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
using Ecomm.Site.Models.EpSnell.Rela_contact;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_contactService
    /// </summary>
    [Export(typeof(IRela_contactService))]
    public class Rela_contactService : CoreServiceBase, IRela_contactService
    {
        #region 属性

        [Import]
        public IRela_contactRepository Rela_contactRepository { get; set; }

        [Import]
        protected Ecomm.Core.Repository.GPSPS.IDBRepository GPSPDBRepository { get; set; }

        public IQueryable<Rela_contact> Rela_contactList
        {
            get { return Rela_contactRepository.Entities; }
        }

        #endregion

        #region 公共方法
        public void GetFreightByCust(string cust, out float freight, out float admincost)
        {
            GPSPDBRepository.GetFreightByCust(cust, out freight, out admincost);
        }

        public OperationResult Insert(Rela_contactModel model)
        {
            var entity = new Rela_contact
            {
                Id = model.Id,
                Name = model.Name,
                Title = model.Title,
                Job_title = model.Job_title,
                Fname = model.Fname,
                Lname = model.Lname,
                Mname = model.Mname,
                Gender = model.Gender,
                Account_id = model.Account_id,
                Iskey = model.Iskey,
                Description = model.Description,
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
                Territory_id = model.Territory_id,
                Home_phone = model.Home_phone,
                Mobile = model.Mobile,
                Department = model.Department,
                Birthday = model.Birthday,
                Assistant = model.Assistant,
                Assistant_phone = model.Assistant_phone,
                Report_to = model.Report_to,
                Lead_source = model.Lead_source,
                Personal_details = model.Personal_details,
                Background = model.Background,
                Family = model.Family,
                Qualifications = model.Qualifications,
                Memberships = model.Memberships,
                Projects = model.Projects,
                Interests = model.Interests,
                Quote = model.Quote,
                Skills = model.Skills,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
                Row_id = model.Row_id,
                Isprivate = model.Isprivate,
                Owner = model.Owner,
                Rn_id = model.Rn_id,
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
                IsManager = model.IsManager,
                UserName = model.UserName,
                Password = model.Password,
                QtyLimit = model.QtyLimit,
                AmountLimit = model.AmountLimit,
                ItemQtyLimit = model.ItemQtyLimit,
                ItemAmountLimit = model.ItemAmountLimit,
                AccountRole = model.AccountRole,
                IsContractLimit = model.IsContractLimit,
                HomePage = model.HomePage,
                Report_To_Email = model.Report_To_Email,
            };
            Rela_contactRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_contactModel model)
        {
			var entity = Rela_contactList.First(t => t.Id == model.Id);
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Title = model.Title;
            entity.Job_title = model.Job_title;
            entity.Fname = model.Fname;
            entity.Lname = model.Lname;
            entity.Mname = model.Mname;
            entity.Gender = model.Gender;
            entity.Account_id = model.Account_id;
            entity.Iskey = model.Iskey;
            entity.Description = model.Description;
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
            entity.Territory_id = model.Territory_id;
            entity.Home_phone = model.Home_phone;
            entity.Mobile = model.Mobile;
            entity.Department = model.Department;
            entity.Birthday = model.Birthday;
            entity.Assistant = model.Assistant;
            entity.Assistant_phone = model.Assistant_phone;
            entity.Report_to = model.Report_to;
            entity.Lead_source = model.Lead_source;
            entity.Personal_details = model.Personal_details;
            entity.Background = model.Background;
            entity.Family = model.Family;
            entity.Qualifications = model.Qualifications;
            entity.Memberships = model.Memberships;
            entity.Projects = model.Projects;
            entity.Interests = model.Interests;
            entity.Quote = model.Quote;
            entity.Skills = model.Skills;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;
            entity.Row_id = model.Row_id;
            entity.Isprivate = model.Isprivate;
            entity.Owner = model.Owner;
            entity.Rn_id = model.Rn_id;
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
            entity.IsManager = model.IsManager;
            entity.UserName = model.UserName;
            entity.Password = model.Password;
            entity.QtyLimit = model.QtyLimit;
            entity.AmountLimit = model.AmountLimit;
            entity.ItemQtyLimit = model.ItemQtyLimit;
            entity.ItemAmountLimit = model.ItemAmountLimit;
            entity.AccountRole = model.AccountRole;
            entity.IsContractLimit = model.IsContractLimit;
            entity.HomePage = model.HomePage;
            entity.Report_To_Email = model.Report_To_Email;

            Rela_contactRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Id)
        {
            var model = Rela_contactList.FirstOrDefault(t => t.Id == Id);

            Rela_contactRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

