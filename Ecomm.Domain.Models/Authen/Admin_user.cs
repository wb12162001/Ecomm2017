// ===================================================================
// File: Admin_user.cs
// 2016/12/23: Ben Wang    Original Version
// ===================================================================
using System;
using System.Linq;
using System.Text;
using Quick.Framework.Tool.Entity;

namespace Ecomm.Domain.Models.Authen
{
    public class Admin_user : EntityBase<string>
    {
        public Admin_user()
        {
        }
		public string Id  { get; set; }


		public string Name  { get; set; }


		public string Userid  { get; set; }


		public string Passid  { get; set; }


		public string Usertype  { get; set; }


		public string Fname  { get; set; }


		public string Lname  { get; set; }


		public string Mname  { get; set; }


		public string Gender  { get; set; }


		public string Title  { get; set; }


		public string Email  { get; set; }


		public string Description  { get; set; }


		public byte? Status  { get; set; }


		public string Sessionid  { get; set; }


		public string Ip  { get; set; }


		public DateTime? Lastdate  { get; set; }


		public string Cretuser  { get; set; }


		public DateTime? Cretdate  { get; set; }


		public DateTime? Modidate  { get; set; }


		public string Modiuser  { get; set; }


		public int Row_id  { get; set; }


		public string Phoneid  { get; set; }


		public string Temp01  { get; set; }

    }
}

