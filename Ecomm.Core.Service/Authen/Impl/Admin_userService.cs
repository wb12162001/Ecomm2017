//------------------------------------------------------------------------------
// <copyright file="Admin_userService.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Service
//		生成时间：2016/12/23 14:34:48
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;

using Quick.Framework.Tool;
using Ecomm.Domain.Models.Authen;
using Ecomm.Core.Repository.Authen;
using Ecomm.Site.Models;
using Ecomm.Site.Models.Authen.Admin_user;
using Quick.Framework.Common.SecurityHelper;



namespace Ecomm.Core.Service.Authen.Impl
{
	/// <summary>
    /// 服务层实现 —— Admin_userService
    /// </summary>
    [Export(typeof(IAdmin_userService))]
    public class Admin_userService : CoreServiceBase, IAdmin_userService
    {
        #region 属性

        [Import]
        public IAdmin_userRepository Admin_userRepository { get; set; }

        public IQueryable<Admin_user> Admin_userList
        {
            get { return Admin_userRepository.Entities; }
        }

        #endregion

        #region 公共方法

        public OperationResult Insert(Admin_userModel model)
        {
            var entity = new Admin_user
            {
                Id = model.Id,
                Name = model.Name,
                Userid = model.Userid,
                Passid = model.Passid,
                Usertype = model.Usertype,
                Fname = model.Fname,
                Lname = model.Lname,
                Mname = model.Mname,
                Gender = model.Gender,
                Title = model.Title,
                Email = model.Email,
                Description = model.Description,
                Status = model.Status,
                Sessionid = model.Sessionid,
                Ip = model.Ip,
                Lastdate = model.Lastdate,
                Cretuser = model.Cretuser,
                Cretdate = model.Cretdate,
                Modidate = model.Modidate,
                Modiuser = model.Modiuser,
                Row_id = model.Row_id,
                Phoneid = model.Phoneid,
                Temp01 = model.Temp01,
            };
            Admin_userRepository.Insert(entity);
            return new OperationResult(OperationResultType.Success, "Added successfully");
        }

        public OperationResult Update(Admin_user model)
        {
            Admin_userRepository.Update(model);
            return new OperationResult(OperationResultType.Success);
        }

        public OperationResult Update(UpdateAdmin_userModel model)
        {
			var entity = Admin_userList.First(t => t.Id == model.Id );
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Userid = model.Userid;
            entity.Passid = model.Passid;
            entity.Usertype = model.Usertype;
            entity.Fname = model.Fname;
            entity.Lname = model.Lname;
            entity.Mname = model.Mname;
            entity.Gender = model.Gender;
            entity.Title = model.Title;
            entity.Email = model.Email;
            entity.Description = model.Description;
            entity.Status = model.Status;
            entity.Sessionid = model.Sessionid;
            entity.Ip = model.Ip;
            entity.Lastdate = model.Lastdate;
            entity.Cretuser = model.Cretuser;
            entity.Cretdate = model.Cretdate;
            entity.Modidate = model.Modidate;
            entity.Modiuser = model.Modiuser;
            entity.Row_id = model.Row_id;
            entity.Phoneid = model.Phoneid;
            entity.Temp01 = model.Temp01;

            Admin_userRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "update completed");
        }

        public OperationResult Delete(string Id)
        {
            var model = Admin_userList.FirstOrDefault(t => t.Id == Id );

            Admin_userRepository.Delete(model);
            return new OperationResult(OperationResultType.Success, "successfully deleted");
        }

        /// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public OperationResult Update(ChangePwdModel model)
        {
            var entity = Admin_userList.FirstOrDefault(t => t.Id == model.Id);
            //entity.Passid = DESProvider.EncryptString(model.NewLoginPwd);
            entity.Passid = model.NewLoginPwd;

            Admin_userRepository.Update(entity);
            return new OperationResult(OperationResultType.Success, "修改密码成功");
        }

        #endregion
    }
}

