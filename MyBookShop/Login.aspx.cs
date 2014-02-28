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
    /// WebForm1 的摘要说明。
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
        }

        /// <summary>
        /// 用户单击“登录”按钮事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonLogin_Click(object sender, System.EventArgs e)
        {
            //获取用户在页面上的输入
            string userLoginName = TextBoxLoginName.Text;		//用户登录名
            string password = TextBoxPassword.Text;			//密码

            User user = new User();					//实例化User类
            user.LoadData(userLoginName);			//利用User类的LoadData方法，获取用户信息
            Session.Add("user_id", user.UserID);		//使用Session来保存用户ID信息

            if (user.Exist)	//如果用户存在
            {
                if (user.Password == password)	//如果密码，转入留言列表页面
                {
                    if (Request.QueryString["in"] == null)	//不是从系统内部跳转而来
                    {
                        Response.Redirect("BookList.aspx");
                    }
                    else//是从系统内部跳转而来
                    {
                        Response.Write("<Script Language=JavaScript>history.go(-2);</Script>");
                    }
                }
                else		//如果密码错误，给出提示，光标停留在密码框中
                {
                    Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                }
            }
            else			//如果用户不存在
            {
                Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
            }
        }
    }
}
