using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using MyBookShop.BusinessLogicLayer;

namespace MyBookShop
{
    /// <summary>
    /// BookDetail 的摘要说明。
    /// </summary>
    public partial class BookDetail : System.Web.UI.Page
    {

        /// <summary>
        /// 加载图书详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
                InitData();
        }

        /// <summary>
        /// 加载图书详细信息
        /// </summary>
        private void InitData()
        {
            int bookId = Convert.ToInt32(Request.QueryString["book_id"]);
            Book book = new Book();
            book.LoadData(bookId);

            Category category = new Category();
            category.LoadData(book.CategoryID);
            LabelBookInfo.Text = "【类别】" + category.CategoryName
                                + "<hr>【书名】" + book.BookName
                                + "<hr>【作者】" + book.Author
                                + "<hr>【出版社】" + book.Publisher
                                + "<hr>【出版日期】" + book.PublishDate.ToLongDateString()
                                + "<hr>【价格】￥" + book.Price.ToString()
                                + "<hr>【页数】" + book.PageNum.ToString()
                                + "<hr>【简介】" + book.Description
                                + "<hr>【销量】" + book.SaleCount.ToString() + "册";
            ImageBook.ImageUrl = "BookPics\\" + book.PictureUrl;
        }

        /// <summary>
        /// 返回按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonBack_Click(object sender, System.EventArgs e)
        {
            Response.Write("<Script Language=JavaScript>history.go(-2);</Script>");
        }
    }
}
