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
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InitData();
        }
        /// <summary>
        /// 查询当前用户的购物篮,初始化页面数据
        /// </summary>
        private void InitData()
        {
            int userId = 0;
            if (Session["user_id"] != null)
                userId = Convert.ToInt32(Session["user_id"].ToString());
            DataTable dt = Cart.Query(userId);
            GV.DataSource = dt;
            GV.DataBind();
        }

        /// <summary>
        /// 返回按钮的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonBack_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("BookList.aspx");
        }

        /// <summary>
        /// DataGrid编辑按钮列单击事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void DG_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            //设置当前修改项的索引
            GV.EditIndex = (int)e.Item.ItemIndex;
            InitData();
        }

        /// <summary>
        /// DataGrid取消按钮列单击事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void DG_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            //设置修改项的索引为-1，即没有行处于被修改状态
            GV.EditIndex = -1;
            InitData();
        }

        /// <summary>
        /// 去结算中心按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonBuy_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Bill.aspx");
        }

        protected void DG_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// 按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument); //待处理的行下标
            int cartId = -1;
            Cart cart = new Cart();

            switch (e.CommandName)
            {
                //编辑
                case "Edit":
                    GV.EditIndex = index;
                    break;

                //修改
                case "Update":
                    cartId = Convert.ToInt32(GV.Rows[index].Cells[0].Text);
                    Hashtable ht = new Hashtable();
                    ht.Add("Amount", ((TextBox)GV.Rows[index].Cells[2].Controls[0]).Text.ToString());
                    cart.Update(ht, cartId);
                    GV.EditIndex = -1;
                    break;

                //取消
                case "Cancel":
                    GV.EditIndex = -1;
                    break;

                //删除
                case "Delete":
                    cartId = Convert.ToInt32(GV.Rows[index].Cells[0].Text);
                    cart.RemoveBook(cartId);	//利用Cart的Remove方法,删除某种图书
                    break;
                default:
                    break;
            }
            InitData();
        }

        protected void GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void GV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}