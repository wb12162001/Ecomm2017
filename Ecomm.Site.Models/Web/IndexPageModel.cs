using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecomm.Site.Models;

namespace Ecomm.Site.Models.Web
{
    public class IndexPageModel
    {
        public IndexPageModel()
        {
            Slides = new List<SysConfig.INFOR_MASTER.INFOR_MASTERModel>();
        }
        //banners
        public List<SysConfig.INFOR_MASTER.INFOR_MASTERModel> Slides { get; set; }
        //Ads
        public List<Product.PROD_GROUP_ITEM.PROD_GROUP_ITEMModel> Mid_Ads { get; set; }
        //TODAY DEALS
        public Product.PROD_GROUP_ITEM.PROD_GROUP_ITEMModel TodayDeals { get; set; }
        //热门产品
        public List<Product.PROD_MASTER.PROD_MASTERModel> PopularProducts { get; set; }
        //Best sellars
        public List<Product.PROD_MASTER.PROD_MASTERModel> BestProducts { get; set; }
        //推荐系列之一
        public List<Product.PROD_GROUP_INDEX.PROD_GROUP_INDEXModel> RecommendedSeries_1 { get; set; }
        //推荐系列之二
        public List<Product.PROD_GROUP_INDEX.PROD_GROUP_INDEXModel> RecommendedSeries_2 { get; set; }
    }
}
