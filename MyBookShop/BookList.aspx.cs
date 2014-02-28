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
    /// BookList 的摘要说明。
    /// </summary>
    public partial class BookList : System.Web.UI.Page
    {

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitData();
                Query();
            }
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        private void InitData()
        {
            //初始化：类别下拉框中的数据，用Category表中的数据进行绑定
            DataTable dt = Category.Query(new Hashtable());
            DropDownListCategory.Items.Clear();
            DropDownListCategory.Items.Add(new ListItem("全部", ""));
            foreach (DataRow dr in dt.Rows)
            {
                DropDownListCategory.Items.Add(new ListItem(dr["CategoryName"].ToString(), dr["CategoryId"].ToString()));
            }
        }

        /// <summary>
        /// 根据页面上用户输入的查询条件，查询图书数据
        /// </summary>
        private void Query()
        {
            //初始化：GridView的数据源
            Hashtable queryItems = new Hashtable();
            queryItems.Add("BookName", TextBoxBookName.Text);
            queryItems.Add("CategoryId", DropDownListCategory.SelectedValue);
            DataTable dt = Book.QueryBooks(queryItems, DropDownListSortColumn.SelectedValue, DropDownListSortType.SelectedValue);

            GV.DataSource = dt;
            GV.DataBind();

            //保存下拉框的选择项到ViewState数组对象
            ViewState.Add("DropDownListCategory", DropDownListCategory.SelectedValue);
            ViewState.Add("DropDownListSortColumn", DropDownListSortColumn.SelectedValue);
            ViewState.Add("DropDownListSortType", DropDownListSortType.SelectedValue);

            LabelPageInfo.Text = "查询结果（第" + (GV.PageIndex + 1).ToString() + "页 共" + GV.PageCount.ToString() + "页）";
        }

        /// <summary>
        /// “查询”按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonQuery_Click(object sender, System.EventArgs e)
        {
            Query();			//查询图书数据
            ResetQueryValue();	//恢复下拉框选择项
        }

        /// <summary>
        /// 保持页面上所有下拉框的选项
        /// </summary>
        private void ResetQueryValue()
        {
            //类别
            foreach (ListItem Item in DropDownListCategory.Items)
            {
                if (Item.Value == ViewState["DropDownListCategory"].ToString())
                    Item.Selected = true;
                else
                    Item.Selected = false;
            }
            //排序列
            foreach (ListItem Item in DropDownListSortColumn.Items)
            {
                if (Item.Value == ViewState["DropDownListSortColumn"].ToString())
                    Item.Selected = true;
                else
                    Item.Selected = false;
            }
            //排序方式
            foreach (ListItem Item in DropDownListSortType.Items)
            {
                if (Item.Value == ViewState["DropDownListSortType"].ToString())
                    Item.Selected = true;
                else
                    Item.Selected = false;
            }
        }

        /// <summary>
        /// 得到用户的选择
        /// </summary>
        /// <returns>用户选择图书的编号集合</returns>
        private ArrayList GetSelected()
        {
            ArrayList selectedItems = new ArrayList();
            foreach (GridViewRow row in GV.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    selectedItems.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
            return selectedItems;
        }

        /// <summary>
        /// "放入购物车"按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAdd2Cart_Click(object sender, System.EventArgs e)
        {
            if (Session["user_id"] == null)
                Page.Response.Redirect("Login.aspx?in=1");

            Cart cart = new Cart();
            Hashtable ht = new Hashtable();
            ArrayList selectedBooks = this.GetSelected();

            //如果用户没有选择,就单击该按钮,则给出警告
            if (selectedBooks.Count == 0)
            {
                Response.Write("<Script Language=JavaScript>alert('请选择图书!');</Script>");
                return;
            }

            //循环将选择的图书加入到购物篮中
            foreach (int bookId in selectedBooks)
            {
                ht.Clear();
                ht.Add("UserId", Session["user_id"].ToString());
                ht.Add("BookId", bookId);
                ht.Add("Amount", TextBoxAmount.Text.Trim());
                cart.Add(ht);
            }
            Response.Redirect("CartView.aspx");
        }

        /// <summary>
        /// “删除”按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ArrayList selectedBooks = this.GetSelected();
            Book book = new Book();

            //如果用户没有选择,就单击该按钮,则给出警告
            if (selectedBooks.Count == 0)
            {
                Response.Write("<Script Language=JavaScript>alert('请首先选择图书!');</Script>");
                return;
            }

            //循环将选择的图书删除
            foreach (int bookId in selectedBooks)
            {
                book.LoadData(bookId);
                book.Delete();
            }
            Query();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV.PageIndex = e.NewPageIndex;
            InitData();
            Query();
        }
    }
}