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
using MyBookShop.BusinessLogicHelper;

namespace MyBookShop
{
    /// <summary>
    /// BookAdd 的摘要说明。
    /// </summary>
    public partial class BookAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
                //InputPictureFile.Accept="image/*";
            }
        }

        private void InitData()
        {
            //初始化：类别下拉框中的数据，用Category表中的数据进行绑定
            DataTable dt = Category.Query(new Hashtable());
            foreach (DataRow dr in dt.Rows)
            {
                DropDownListCategory.Items.Add(new ListItem(dr["CategoryName"].ToString(), dr["CategoryId"].ToString()));
            }
        }

        /// <summary>
        /// 提交按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonOK_Click(object sender, System.EventArgs e)
        {
            //构造book信息哈希表
            Hashtable ht = new Hashtable();
            ht.Add("BookName", TextBoxBookName.Text.Trim());
            ht.Add("CategoryId", DropDownListCategory.SelectedValue);
            ht.Add("Price", TextBoxPrice.Text.Trim());
            ht.Add("Publisher", TextBoxPublisher.Text.Trim());
            ht.Add("PublishDate", TextBoxPublishDate.Text.Trim());
            ht.Add("Author", TextBoxAuthor.Text.Trim());
            ht.Add("PageNum", TextBoxPageNum.Text.Trim());
            ht.Add("Description", TextBoxDescription.Text.Trim());

            //图片名,以当前时间为文件名,确保文件名没有重复
            string uploadName = InputPictureFile.Value.Trim();
            string pictureName = "";
            if (uploadName != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);//文件后缀
                //Ticks属性的值为自 0001 年 1 月 1 日午夜 12:00 以来所经过时间以 100 毫微秒为间隔表示时的数字。
                pictureName = System.DateTime.Now.Ticks.ToString() + suffix;
                ht.Add("PictureUrl", pictureName);
            }

            ht.Add("SaleCount", 1);

            //添加图书,如果数据类型不正确,给出提示.
            ArrayList WarningMessageList = new ArrayList();
            LabelWarningMessage.Text = "";
            if (BookHelper.Add(ht, ref WarningMessageList) == false)
            {
                LabelWarningMessage.Text = "<font color=red>";
                foreach (string item in WarningMessageList)
                {
                    LabelWarningMessage.Text += item + "<br>";
                }
                LabelWarningMessage.Text += "</font>";
            }

            //上传图片到目录"\BookPics\"中
            else
            {
                if (uploadName != "")
                {
                    string path = Server.MapPath(".\\BookPics\\");
                    InputPictureFile.PostedFile.SaveAs(path + pictureName);
                }
                Response.Redirect("BookList.aspx");
            }

        }
    }
}
