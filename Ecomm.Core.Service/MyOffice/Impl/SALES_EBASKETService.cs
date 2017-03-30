//------------------------------------------------------------------------------
// <copyright file="SALES_EBASKETService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2017/1/12 16:18:04
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
using Ecomm.Site.Models.MyOffice.SALES_EBASKET;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.MyOffice.Impl
{
	/// <summary>
    /// 服务层实现 —— SALES_EBASKETService
    /// </summary>
    [Export(typeof(ISALES_EBASKETService))]
    public class SALES_EBASKETService : CoreServiceBase, ISALES_EBASKETService
    {
        #region 属性

        [Import]
        public ISALES_EBASKETRepository SALES_EBASKETRepository { get; set; }

        /// <summary>
        /// SALES_EBASKETList.ToList() 后IEnumerable, 才会更新内存中的数据
        /// </summary>
        public IQueryable<SALES_EBASKET> SALES_EBASKETList
        {
            get { return SALES_EBASKETRepository.Entities; }
        }

        public IEnumerable<SALES_EBASKET> Entities
        {
            get {
                return SALES_EBASKETRepository.EntitiesAsNoTracking;
            }
        }
        public IEnumerable<SALES_EBASKET> EntitiesToList
        {
            get
            {
                return SALES_EBASKETRepository.GetEntitiesBySql("dbo.SALES_EBASKET").ToList();
            }
        }

        public IEnumerable<SALES_EBASKET_MASTER> QueryEntities(int count, string strWhere, string strOrder)
        {
            return SALES_EBASKETRepository.QueryEntities(count, strWhere, strOrder);
        }
        #endregion

        #region 公共方法

        public OperationResult Insert(SALES_EBASKETModel model)
        {
            var entity = new SALES_EBASKET
            {
                ID = model.ID,
                CustomerID = model.CustomerID,
                ContactID = model.ContactID,
                ProductNo = model.ProductNo,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Unit = model.Unit,
                Creator = model.Creator,
                Modifier = model.Modifier,
                CreateDate = model.CreateDate,
                ModiDate = model.ModiDate,
                MakeOrderID = model.MakeOrderID,
                RowID = model.RowID,
                Status = model.Status,
                UnitPType = model.UnitPType,
            };
            SALES_EBASKETRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(UpdateSALES_EBASKETModel model)
        {
			var entity = SALES_EBASKETList.First(t => t.ID == model.ID);
            entity.ID = model.ID;
            entity.CustomerID = model.CustomerID;
            entity.ContactID = model.ContactID;
            entity.ProductNo = model.ProductNo;
            entity.Quantity = model.Quantity;
            entity.UnitPrice = model.UnitPrice;
            entity.Unit = model.Unit;
            entity.Creator = model.Creator;
            entity.Modifier = model.Modifier;
            entity.CreateDate = model.CreateDate;
            entity.ModiDate = model.ModiDate;
            entity.MakeOrderID = model.MakeOrderID;
            entity.RowID = model.RowID;
            entity.Status = model.Status;
            entity.UnitPType = model.UnitPType;

            SALES_EBASKETRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public int UpdateEBasketQuantity(string custId, string contactId, string proNo, float quantity)
        {
            return SALES_EBASKETRepository.UpdateEBasketQuantity(custId, contactId, proNo, quantity);
        }
        /// <summary>
        /// 使用存储过程更新, 但不知道怎样可以同步上下文;
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModificationByProce(SALES_EBASKETModel model)
        {
            var entity = SALES_EBASKETRepository.EntitiesToList.Where(t =>
            t.CustomerID == model.CustomerID
            && t.ContactID == model.ContactID
            && t.ProductNo == model.ProductNo && t.Status == 0).FirstOrDefault();
            if (entity == null)
            {
                entity = new SALES_EBASKET
                {
                    ID = CombHelper.NewComb().ToString(),
                    CustomerID = model.CustomerID,
                    ContactID = model.ContactID,
                    ProductNo = model.ProductNo,
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Unit = model.Unit,
                    Creator = model.Creator,
                    Modifier = model.Modifier,
                    CreateDate = model.CreateDate,
                    ModiDate = model.ModiDate,
                    MakeOrderID = model.MakeOrderID,
                    //RowID = model.RowID,
                    Status = model.Status,
                    UnitPType = model.UnitPType,
                };
            }
            else
            {
                //entity.ID = model.ID;
                entity.CustomerID = model.CustomerID;
                entity.ContactID = model.ContactID;
                entity.ProductNo = model.ProductNo;
                entity.Quantity = model.Quantity;
                entity.UnitPrice = model.UnitPrice;
                entity.Unit = model.Unit;
                //entity.Creator = model.Creator;
                entity.Modifier = model.Modifier;
                //entity.CreateDate = model.CreateDate;
                entity.ModiDate = model.ModiDate;
                entity.MakeOrderID = model.MakeOrderID;
                //entity.RowID = model.RowID;
                //entity.Status = model.Status;
                entity.UnitPType = model.UnitPType;
            }

            int ret = SALES_EBASKETRepository.ModificationByProce(entity);
            //这里刷新内存中数据集;
            //-------------------------------
            ////一直有问题不可以使用
            //var entity_new = SALES_EBASKETRepository.EntitiesToList.Where(t => t.ID == entity.ID);
            //if (entity_new.Count() > 0) { SALES_EBASKETRepository.ReLoad(entity_new.FirstOrDefault()); } else
            //{
            //    SALES_EBASKETRepository.Add(entity);
            //}
            SALES_EBASKETRepository.Load();
            //---------------------------------------
            return ret;
        }

        public int ModificationCart(SALES_EBASKETModel model)
        {
            var entity = SALES_EBASKETList.ToList().Where(t =>
            t.CustomerID == model.CustomerID
            && t.ContactID == model.ContactID
            && t.ProductNo == model.ProductNo && t.Status == 0).FirstOrDefault();
            if (entity == null)
            {
                entity = new SALES_EBASKET
                {
                    ID = CombHelper.NewComb().ToString(),
                    CustomerID = model.CustomerID,
                    ContactID = model.ContactID,
                    ProductNo = model.ProductNo,
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Unit = model.Unit,
                    Creator = model.Creator,
                    Modifier = model.Modifier,
                    CreateDate = model.CreateDate,
                    ModiDate = model.ModiDate,
                    MakeOrderID = model.MakeOrderID,
                    //RowID = model.RowID,
                    Status = model.Status,
                    UnitPType = model.UnitPType,
                };
                return SALES_EBASKETRepository.Insert(entity);
            }
            else
            {
                //entity.ID = model.ID;
                //entity.CustomerID = model.CustomerID;
                //entity.ContactID = model.ContactID;
                //entity.ProductNo = model.ProductNo;
                entity.Quantity += model.Quantity;
                //entity.UnitPrice = model.UnitPrice;
                //entity.Unit = model.Unit;
                //entity.Creator = model.Creator;
                entity.Modifier = model.Modifier;
                //entity.CreateDate = model.CreateDate;
                entity.ModiDate = model.ModiDate;
                //entity.MakeOrderID = model.MakeOrderID;
                //entity.RowID = model.RowID;
                //entity.Status = model.Status;
                //entity.UnitPType = model.UnitPType;

                return SALES_EBASKETRepository.Update(entity);  //这个是可以成功; 注意entity是通过entities集成读取

                //return SALES_EBASKETRepository.Update(e => new { e.Quantity }, entity); //这个局部更新


            }
        }

        

        public OperationResult Delete(string  ID)
        {
            var model = SALES_EBASKETList.FirstOrDefault(t => t.ID == ID);

            SALES_EBASKETRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        public int DeleteItem(string ID)
        {
            var model = SALES_EBASKETList.FirstOrDefault(t => t.ID == ID);

            return SALES_EBASKETRepository.Delete(model);
        }


        public Domain.Models.EpSnell.Rela_contact GetUser()
        {
            return GetCurrentUser();
        }
        public void SetUser(object val)
        {
            SetCurrentUser(val);
        }


        public double GetUserFreight(double subtotal)
        {
            var user = GetUser();
            if (user.MinOrderSize > 0)
            {
                user.Freight = user.MinOrderFreight;
                user.Miscellaneous = 0;
                if (subtotal < user.MinOrderSize)
                {
                    user.Miscellaneous = user.MinOrderMisc;
                }
            }
            return user.Freight;
        }

        public int UpdateEBasket(string id, string orderID,string modifier)
        {
            //Ecomm.BLL.SALES_EBASKET basket = Ecomm.BLL.BLLFactory<Ecomm.BLL.SALES_EBASKET>.Instance;
            //Model.SALES_EBASKETInfo ebasketInfo = basket.Get(id);
            //ebasketInfo.MakeOrderID = orderID;
            //ebasketInfo.Status = 1;
            //ebasketInfo.ModiDate = DateTime.Now;
            //ebasketInfo.Modifier = base.UserInfo.Name;
            //basket.UpdateByProce(ebasketInfo);

            var entity = SALES_EBASKETList.First(t => t.ID == id);
            entity.Modifier = modifier;
            entity.ModiDate = DateTime.Now;
            entity.MakeOrderID = orderID;
            entity.Status = 1;
            return  SALES_EBASKETRepository.Update(entity);
        }
        #endregion
    }
}

