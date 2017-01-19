//------------------------------------------------------------------------------
// <copyright file="Rela_contact_locationService.cs">
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
using Ecomm.Site.Models.EpSnell.Rela_contact_location;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_contact_locationService
    /// </summary>
    [Export(typeof(IRela_contact_locationService))]
    public class Rela_contact_locationService : CoreServiceBase, IRela_contact_locationService
    {
        #region 属性

        [Import]
        public IRela_contact_locationRepository Rela_contact_locationRepository { get; set; }

        public IQueryable<Rela_contact_location> Rela_contact_locationList
        {
            get { return Rela_contact_locationRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_contact_locationModel model)
        {
            var entity = new Rela_contact_location
            {
                Account_no = model.Account_no,
                Contact_id = model.Contact_id,
                Address_no = model.Address_no,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Cretuser = model.Cretuser,
                Modiuser = model.Modiuser,
                Display_order = model.Display_order,
                Row_id = model.Row_id,
                Status = model.Status,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                Item5 = model.Item5,
                Item6 = model.Item6,
            };
            Rela_contact_locationRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_contact_locationModel model)
        {
			var entity = Rela_contact_locationList.First(t => t.Account_no == model.Account_no && t.Contact_id == model.Contact_id && t.Address_no == model.Address_no);
            entity.Account_no = model.Account_no;
            entity.Contact_id = model.Contact_id;
            entity.Address_no = model.Address_no;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Cretuser = model.Cretuser;
            entity.Modiuser = model.Modiuser;
            entity.Display_order = model.Display_order;
            entity.Row_id = model.Row_id;
            entity.Status = model.Status;
            entity.Item1 = model.Item1;
            entity.Item2 = model.Item2;
            entity.Item3 = model.Item3;
            entity.Item4 = model.Item4;
            entity.Item5 = model.Item5;
            entity.Item6 = model.Item6;

            Rela_contact_locationRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Account_no,string  Contact_id,string  Address_no)
        {
            var model = Rela_contact_locationList.FirstOrDefault(t => t.Account_no == Account_no && t.Contact_id == Contact_id && t.Address_no == Address_no);

            Rela_contact_locationRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

