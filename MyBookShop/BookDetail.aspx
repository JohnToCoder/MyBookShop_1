<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="MyBookShop.BookDetail" %>

<%@ Register TagPrefix="MyBookShop" TagName="HeaderMenu" Src="UserControls/HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图书详细信息</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; left: 8px; width: 504px; position: absolute;
            top: 8px; height: 193px" cellspacing="0" cellpadding="0" width="504" border="0">
            <tr>
                <td colspan="2" align="center">
                    <MyBookShop:HeaderMenu ID="Headermenu1" runat="server"></MyBookShop:HeaderMenu>
                </td>
            </tr>
            <tr>
                <td style="width: 254px; height: 48px;">
                    <asp:Label ID="LabelBookInfo" runat="server" Height="206px" Width="272px"></asp:Label></td>
                <td valign="top" style="height: 48px">
                    <asp:Image ID="ImageBook" runat="server" Width=150></asp:Image></td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="ButtonBack" runat="server" Text="返回" Width="62px" OnClick="ButtonBack_Click">
                    </asp:Button></td>
            </tr>
        </table>
    </form>
</body>
</html>
