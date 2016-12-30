using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Site.Models.AdminCommon
{
    public class BreadCrumbModelArray<T>
    {
        private SortedList<string,T> array;
        public BreadCrumbModelArray()
        {
            array = new SortedList<string, T>();
        }
        public T getItem(string index)
        {
            if (array.ContainsKey(index)) { return array[index]; }
            return default(T);

        }
        public void setItem(string index, T value)
        {
            array.Add(index, value);
        }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
    public class BreadCrumbNavModel
	{
		public BreadCrumbNavModel()
		{
			BreadCrumbList = new List<BreadCrumbModel>();
		}

		public bool IsOnlyIndex { get; set; }
		public string CurrentName { get; set; }

		public List<BreadCrumbModel> BreadCrumbList { get; set; }
	}

	public class BreadCrumbModel
	{
		public bool IsIndex { get; set; }
		public bool IsParent { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
	}
}
