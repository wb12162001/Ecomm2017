﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
//	   如存在本生成代码外的新需求，请在相同命名空间下创建同名分部类进行实现。
// </auto-generated>
//
// <copyright file="OperateLogRepository.cs">
//		Copyright(c)2013 QuickFramework.All rights reserved.
//		开发组织：QuickFramework
//		公司网站：QuickFramework
//		所属工程：QuickRMS.Core.Repository
//		生成时间：2014-03-10 11:23
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using System.Linq;

using Quick.Framework.EFData;
using Ecomm.Domain.Models.SysConfig;


namespace Ecomm.Core.Repository.SysConfig.Impl
{
	/// <summary>
    /// 仓储操作层实现 —— OperateLog
    /// </summary>
    [Export(typeof(IOperateLogRepository))]
    public class OperateLogRepository : EFRepositoryBase<OperateLog>, IOperateLogRepository
    {
        public OperateLogRepository() : base("") { }
    }
}
