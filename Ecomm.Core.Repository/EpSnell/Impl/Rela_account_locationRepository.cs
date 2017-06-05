//------------------------------------------------------------------------------
// <copyright file="Rela_account_locationRepository.cs">
//		开发：Ben Wang  
//		所属工程：Ecomm.Core.Repository
//		生成时间：2017/1/16
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using Quick.Framework.EFData;
using Ecomm.Domain.Models.EpSnell;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Core.Repository.EpSnell
{
	/// <summary>
    /// 仓储操作层接口 —— Rela_account_location 
    /// </summary>
    [Export(typeof(IRela_account_locationRepository))]
    public class Rela_account_locationRepository : EFRepositoryBase<Rela_account_location>, IRela_account_locationRepository
    {
        public Rela_account_locationRepository() : base("default")
        {

        }
        public IEnumerable<Rela_account_location_shipto> Query_SHIPTO(string account_no, string contact_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("a.address1, ");
            sb.AppendLine("a.address2, ");
            sb.AppendLine("--a.address1  as description, ");
            sb.AppendLine("a.address_id , ");
            sb.AppendLine("a.description, ");
            sb.AppendLine("a.contact_id, ");
            sb.AppendLine("(case when b.c>0 then 1 else 0 end) as isSel ");
            sb.AppendLine("from dbo.rela_account_location a ");
            sb.AppendFormat("left join (select count(1) as c,account_no,address_no from [dbo].[rela_contact_location] where account_no='{0}' and contact_id='{1}' group by account_no,address_no) ", account_no, contact_id).AppendLine();
            sb.AppendLine("b on a.account_no=b.account_no and a.address_id=b.address_no ");
            sb.AppendFormat("where a.[account_no]='{0}' and (a.address_id like 'SHIPTO%' and a.address_id <>'SHIPTONEW') ", account_no).AppendLine();

            return base.ExcuteQuery<Rela_account_location_shipto>(sb.ToString());
        }

        public IEnumerable<Rela_account_location_shipto_item> QueryDropList(string account_no)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select address_id as [ID], address_id as [NAME] from dbo.rela_account_location a  where a.address_id <> 'SHIPTONEW' and a.address_id like 'SHIPTO%' and a.[account_no] = '{0}'", account_no).AppendLine();
            return base.ExcuteQuery<Rela_account_location_shipto_item>(sb.ToString());
        }
    }
}

