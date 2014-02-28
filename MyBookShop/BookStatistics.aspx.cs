using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Drawing;
using MyBookShop.BusinessLogicLayer;

namespace MyBookShop
{
    public partial class BookStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DrawChartByCategory();
        }
        /// <summary>
        /// 按照图书类别统计
        /// </summary>
        private void DrawChartByCategory()
        {
            DataTable dt = Book.GetSaleCountByCategory();
            string title = "图书销售量统计";			//标题
            string subTitle = "基于图书种类";			//副标题
            string targetFile = Server.MapPath(".\\Images\\") + "Category.gif";	//图象文件
            Chart.DrawPie(title, subTitle, 300, 300, dt, targetFile, "CategoryName", "SaleCount");

            Image.ImageUrl = targetFile;
        }
        /// <summary>
        /// 按照出版社统计
        /// </summary>
        private void DrawChartByPublisher()
        {
            DataTable dt = Book.GetSaleCountByPublisher();
            string title = "图书销售量统计";			//标题
            string subTitle = "基于出版社";			//副标题
            string targetFile = Server.MapPath(".") + "\\Images\\Publiser.gif";	//图象文件

            Chart.DrawPie(title, subTitle, 300, 300, dt, targetFile, "Publisher", "SaleCount");

            Image.ImageUrl = targetFile;
        }
        /// <summary>
        /// 按照价格类别统计
        /// </summary>
        private void DrawChartByPrice()
        {
            DataTable dt = Book.GetSaleCountByPrice();
            string title = "图书销售量统计";			//标题
            string subTitle = "基于图书价格";			//副标题

            string targetFile = HttpContext.Current.Server.MapPath(".\\Images\\") + "Price.gif";	//图象文件
            Chart.DrawPie(title, subTitle, 300, 300, dt, targetFile, "PriceGrade", "SaleCount");

            Image.ImageUrl = targetFile;
        }
        /// <summary>
        /// 下拉框选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownListType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (DropDownListType.SelectedValue)
            {
                case "图书类别":
                    DrawChartByCategory();
                    break;
                case "出版社":
                    DrawChartByPublisher();
                    break;
                case "价格":
                    DrawChartByPrice();
                    break;

            }
        }
    }
}