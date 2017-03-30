//------------------------------------------------------------------------------
// <copyright file="SALES_EORDERSService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:05
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
using Ecomm.Site.Models.MyOffice.SALES_EORDERS;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_EORDERSService
    /// </summary>
    [Export(typeof(ISALES_EORDERSService))]
    public class SALES_EORDERSService : CoreServiceBase, ISALES_EORDERSService
    {
        #region 属性

        [Import]
        public ISALES_EORDERSRepository SALES_EORDERSRepository { get; set; }

        public IQueryable<SALES_EORDERS> SALES_EORDERSList
        {
            get { return SALES_EORDERSRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public int Insert2(SALES_EORDERSModel model)
        {
            var entity = new SALES_EORDERS
            {
                ID = model.ID,
                RowID = model.RowID,
                OrderType = model.OrderType,
                CustomerID = model.CustomerID,
                ShipID = model.ShipID,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipZip = model.ShipZip,
                ShipCountry = model.ShipCountry,
                ShipState = model.ShipState,
                ShipPhone = model.ShipPhone,
                AuthCode = model.AuthCode,
                BillTitle = model.BillTitle,
                BillName = model.BillName,
                BillAddress = model.BillAddress,
                BillCity = model.BillCity,
                BillState = model.BillState,
                BillZip = model.BillZip,
                BillCountry = model.BillCountry,
                BillPhone = model.BillPhone,
                CommText = model.CommText,
                CreditCard = model.CreditCard,
                CcName = model.CcName,
                CcExpMonth = model.CcExpMonth,
                CcExpYear = model.CcExpYear,
                CcNumber = model.CcNumber,
                CcType = model.CcType,
                VerifyWith = model.VerifyWith,
                PurchaseNo = model.PurchaseNo,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                IsPrint = model.IsPrint,
                ProcStatus = model.ProcStatus,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
                ContactID = model.ContactID,
                Miscellaneous = model.Miscellaneous,
            };
            return SALES_EORDERSRepository.Insert(entity);
        }

        public OperationResult Insert(SALES_EORDERSModel model)
        {
            var entity = new SALES_EORDERS
            {
                ID = model.ID,
                RowID = model.RowID,
                OrderType = model.OrderType,
                CustomerID = model.CustomerID,
                ShipID = model.ShipID,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipZip = model.ShipZip,
                ShipCountry = model.ShipCountry,
                ShipState = model.ShipState,
                ShipPhone = model.ShipPhone,
                AuthCode = model.AuthCode,
                BillTitle = model.BillTitle,
                BillName = model.BillName,
                BillAddress = model.BillAddress,
                BillCity = model.BillCity,
                BillState = model.BillState,
                BillZip = model.BillZip,
                BillCountry = model.BillCountry,
                BillPhone = model.BillPhone,
                CommText = model.CommText,
                CreditCard = model.CreditCard,
                CcName = model.CcName,
                CcExpMonth = model.CcExpMonth,
                CcExpYear = model.CcExpYear,
                CcNumber = model.CcNumber,
                CcType = model.CcType,
                VerifyWith = model.VerifyWith,
                PurchaseNo = model.PurchaseNo,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                Creator = model.Creator,
                Modifier = model.Modifier,
                IsPrint = model.IsPrint,
                ProcStatus = model.ProcStatus,
                Status = model.Status,
                Item01 = model.Item01,
                Item02 = model.Item02,
                Item03 = model.Item03,
                Item04 = model.Item04,
                Item05 = model.Item05,
                ContactID = model.ContactID,
                Miscellaneous = model.Miscellaneous,
            };
            SALES_EORDERSRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(SALES_EORDERSModel model)
        {
			var entity = SALES_EORDERSList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.RowID = model.RowID;
            entity.OrderType = model.OrderType;
            entity.CustomerID = model.CustomerID;
            entity.ShipID = model.ShipID;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipZip = model.ShipZip;
            entity.ShipCountry = model.ShipCountry;
            entity.ShipState = model.ShipState;
            entity.ShipPhone = model.ShipPhone;
            entity.AuthCode = model.AuthCode;
            entity.BillTitle = model.BillTitle;
            entity.BillName = model.BillName;
            entity.BillAddress = model.BillAddress;
            entity.BillCity = model.BillCity;
            entity.BillState = model.BillState;
            entity.BillZip = model.BillZip;
            entity.BillCountry = model.BillCountry;
            entity.BillPhone = model.BillPhone;
            entity.CommText = model.CommText;
            entity.CreditCard = model.CreditCard;
            entity.CcName = model.CcName;
            entity.CcExpMonth = model.CcExpMonth;
            entity.CcExpYear = model.CcExpYear;
            entity.CcNumber = model.CcNumber;
            entity.CcType = model.CcType;
            entity.VerifyWith = model.VerifyWith;
            entity.PurchaseNo = model.PurchaseNo;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.IsPrint = model.IsPrint;
            entity.ProcStatus = model.ProcStatus;
            entity.Status = model.Status;
            entity.Item01 = model.Item01;
            entity.Item02 = model.Item02;
            entity.Item03 = model.Item03;
            entity.Item04 = model.Item04;
            entity.Item05 = model.Item05;
            entity.ContactID = model.ContactID;
            entity.Miscellaneous = model.Miscellaneous;

            SALES_EORDERSRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string  ID)
        {
            var model = SALES_EORDERSList.FirstOrDefault(t => t.ID == ID);

            SALES_EORDERSRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        /// <summary>
        /// 获取custid, 当月在shipID下的订单总和
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="shipId"></param>
        /// <returns></returns>
        public double GetOrdersByCurrentMonth(string custId, string shipId)
        {
            double returnValue = 0;
            try
            {
                returnValue = SALES_EORDERSRepository.GetOrdersByCurrentMonth(custId, shipId);
            }
            catch (Exception ex)
            {
                returnValue = 0;
            }
            return returnValue;
        }
        #endregion
    }
}

