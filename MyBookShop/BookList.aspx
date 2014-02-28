<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="MyBookShop.BookList" %>
<%@ Register TagPrefix="MyBookShop" TagName="HeaderMenu" Src="UserControls/HeaderMenu.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浏览图书</title>
    <link href="Styles/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; left: 8px; width: 504px; position: absolute;
            top: 8px; height: 208px" cellspacing="0" cellpadding="0" width="504" border="0">
            <tr>
                <td align="center" colspan="4">
                    <MyBookShop:HeaderMenu ID="headerMenu" runat="server"></MyBookShop:HeaderMenu>
                </td>
            </tr>
            <tr>
                <td style="width: 99px">
                    &gt;&gt;浏览图书</td>
                <td>
                </td>
                <td>
                </td>
                <td style="width: 45px">
                </td>
            </tr>
            <tr style="background-color: aqua">
                <td colspan="1" rowspan="1">
                    ※书名：
                    <asp:TextBox ID="TextBoxBookName" runat="server" Width="66px"></asp:TextBox></td>
                <td style="height: 4px" colspan="1" rowspan="1">
                    ※类别：
                    <asp:DropDownList ID="DropDownListCategory" runat="server">
                    </asp:DropDownList></td>
                <td style="height: 4px">
                    ※排序：
                    <asp:DropDownList ID="DropDownListSortColumn" runat="server">
                        <asp:ListItem Value="SaleCount">销量</asp:ListItem>
                        <asp:ListItem Value="PublishDate">出版日期</asp:ListItem>
                        <asp:ListItem Value="Price">价格</asp:ListItem>
                    </asp:DropDownList><asp:DropDownList ID="DropDownListSortType" runat="server">
                        <asp:ListItem Value="Desc">递减</asp:ListItem>
                        <asp:ListItem Value="Asc">递增</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="ButtonQuery" runat="server" Text="查询" Width="48px" OnClick="ButtonQuery_Click">
                    </asp:Button></td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br>
                    &nbsp;<asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="5" OnPageIndexChanging="GV_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" Checked="False" Visible="True" GroupName="chk" runat="server">
                                    </asp:CheckBox></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BookId" HeaderText="编号" />
                            <asp:BoundField DataField="BookName" HeaderText="图书名" />
                            <asp:BoundField DataField="Author" HeaderText="作者" />
                            <asp:BoundField DataField="Publisher" HeaderText="出版社" />
                            <asp:BoundField DataField="PublishDate" HeaderText="出版日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="Price" HeaderText="价格" DataFormatString="{0:C}" />
                            <asp:HyperLinkField HeaderText="详细信息" DataTextFormatString="详细信息" Text="详细信息" DataNavigateUrlFormatString="BookDetail.aspx?book_id={0}"
                                DataNavigateUrlFields="BookId" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="LabelPageInfo" runat="server"></asp:Label></td>
            </tr>
            <tr style="background-color: aqua">
                <td align="left" style="background-color: aqua" colspan="2" rowspan="1">
                    <asp:Button ID="ButtonDelete" runat="server" Text="删除" Width="48px" OnClick="ButtonDelete_Click">
                    </asp:Button></td>
                <td align="right" style="background-color: aqua" colspan="2" rowspan="1">
                    把
                    <asp:TextBox ID="TextBoxAmount" runat="server" Width="26px">1</asp:TextBox>本选中的图书<asp:Button
                        ID="ButtonAdd2Cart" runat="server" Text="放入购物篮" OnClick="ButtonAdd2Cart_Click"></asp:Button></td>
            </tr>
        </table>
    </form>
</body>
</html>
