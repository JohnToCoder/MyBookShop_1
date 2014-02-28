<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookStatistics.aspx.cs" Inherits="MyBookShop.BookStatistics" %>

<%@ Register TagPrefix="MyBookShop" TagName="HeaderMenu" Src="UserControls/HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浏览图书</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; left: 8px; width: 504px; position: absolute;
            top: 8px; height: 120px" cellspacing="0" cellpadding="0" width="504" border="0">
            <tr>
                <td align="center" colspan="4">
                    <MyBookShop:HeaderMenu ID="headerMenu" runat="server"></MyBookShop:HeaderMenu>
                </td>
            </tr>
            <tr>
                <td style="width: 99px" colspan="4">
                    &gt;&gt;统计信息</td>
            </tr>
            <tr style="background-color: aqua">
                <td style="height: 2px" colspan="1" rowspan="1">
                </td>
                <td style="height: 2px" colspan="1" rowspan="1" align="right">
                    ※统计方式：
                    <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListType_SelectedIndexChanged">
                        <asp:ListItem Value="图书类别">图书类别</asp:ListItem>
                        <asp:ListItem Value="出版社">出版社</asp:ListItem>
                        <asp:ListItem Value="价格">价格</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="height: 2px">
                </td>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Image ID="Image" runat="server"></asp:Image><br />
                </td>
            </tr>
            <tr style="background-color: aqua">
                <td align="left" style="background-color: aqua" colspan="4" rowspan="1">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
