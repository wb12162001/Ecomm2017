//------------------------------------------------------------------------------
// <copyright file="Admin_userRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2016/12/23
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.Authen;


namespace Ecomm.Core.Repository.Authen
{
	/// <summary>
    /// 仓储操作层接口 —— Admin_user 
    /// </summary>
    [Export(typeof(IAdmin_userRepository))]
    public class Admin_userRepository : EFRepositoryBase<Admin_user>, IAdmin_userRepository
    {
        public Admin_userRepository() : base("ep_snell")
        {
        }
    }
}

