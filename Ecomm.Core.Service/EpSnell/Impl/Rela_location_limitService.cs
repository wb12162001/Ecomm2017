//------------------------------------------------------------------------------
// <copyright file="Rela_location_limitService.cs">
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
using Ecomm.Site.Models.EpSnell.Rela_location_limit;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.EpSnell.Impl
{
	/// <summary>
    /// 服务层实现 —— Rela_location_limitService
    /// </summary>
    [Export(typeof(IRela_location_limitService))]
    public class Rela_location_limitService : CoreServiceBase, IRela_location_limitService
    {
        #region 属性

        [Import]
        public IRela_location_limitRepository Rela_location_limitRepository { get; set; }

        public IQueryable<Rela_location_limit> Rela_location_limitList
        {
            get { return Rela_location_limitRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Rela_location_limitModel model)
        {
            var entity = new Rela_location_limit
            {
                Account_no = model.Account_no,
                Address_id = model.Address_id,
                Month_quota = model.Month_quota,
                Month_sales = model.Month_sales,
            };
            Rela_location_limitRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateRela_location_limitModel model)
        {
			var entity = Rela_location_limitList.First(t => t.Account_no == model.Account_no && t.Address_id == model.Address_id);
            entity.Account_no = model.Account_no;
            entity.Address_id = model.Address_id;
            entity.Month_quota = model.Month_quota;
            entity.Month_sales = model.Month_sales;

            Rela_location_limitRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  Account_no,string  Address_id)
        {
            var model = Rela_location_limitList.FirstOrDefault(t => t.Account_no == Account_no && t.Address_id == Address_id);

            Rela_location_limitRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        #endregion
    }
}

