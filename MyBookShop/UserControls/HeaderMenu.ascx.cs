using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBookShop.BusinessLogicLayer;

namespace MyBookShop.UserControls
{
    public partial class HeaderMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                User user = new User();
                user.LoadData(Convert.ToInt32(Session["user_id"]));
                LabelHello.Text = "您好,<font color=red><b>" + user.LoginName + "</font></b>";
                LinkButtonLogin.Text = "离开";
            }
            else {
                LinkButtonLogin.Text = "登录";
            }
        }
        #region Web 窗体设计器生成代码

        override protected void OnInit(EventArgs e) 
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }
        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        /// <summary>
        /// 登录或者离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButtonLogin_Click(object sender, System.EventArgs e)
        {
            if (LinkButtonLogin.Text == "登录")
            {
                Page.Response.Redirect("Login.aspx?in=1");
            }
            else
            {
                Session["user_id"] = null;
                Page.Response.Write("<Script Language=JavaScript>window.close();</Script>");
            }
        }
    }
}