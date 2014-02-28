using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyBookShop.BusinessLogicLayer;

namespace MyBookShop.UserControls
{
    public partial class UserCheck : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUser();
        }
        #region Web 窗体设计器生成的代码
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
        /// 用户身份验证方法
        /// </summary>
        private void CheckUser()
        {
            if (Session["user_id"] == null)
            {
                Page.Response.Redirect("Login.aspx?in=1");
            }
        }
    }
}