<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="MyBookShop.CartView" %>

<%@ Register TagPrefix="MyBookShop" TagName="HeaderMenu" Src="UserControls/HeaderMenu.ascx" %>
<%@ Register TagPrefix="MyBookShop" TagName="UserCheck" Src="UserControls/UserCheck.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浏览购物篮</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="z-index: 101; left: 8px; width: 504px; position: absolute;
            top: 8px; height: 136px" cellspacing="0" cellpadding="0" width="504" border="0">
            <tr>
                <td align="center">
                    <MyBookShop:HeaderMenu ID="headerMenu" runat="server"></MyBookShop:HeaderMenu>
                    <MyBookShop:UserCheck ID="userCheck1" runat="server"></MyBookShop:UserCheck>
                </td>
            </tr>
            <tr>
                <td>
                    &gt;&gt;购买图书&gt;&gt;我的购物篮</td>
            </tr>
            <tr>
                <td valign="top" align="center">
                    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GV_RowCancelingEdit"
                        OnRowCommand="GV_RowCommand" OnRowDeleting="GV_RowDeleting" OnRowEditing="GV_RowEditing"
                        OnRowUpdating="GV_RowUpdating" Width="90%">
                        <Columns>
                            <asp:BoundField DataField="CartId" ReadOnly="True" HeaderText="购物篮编号" />
                            <asp:BoundField DataField="BookName" ReadOnly="True" HeaderText="图书名" />
                            <asp:BoundField DataField="Amount" HeaderText="数量" />
                            <asp:CommandField ShowEditButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" style="background-color:aqua; height: 20px;">
                    <asp:Button ID="ButtonBack" runat="server" Text="继续选购" Width="65px" OnClick="ButtonBack_Click">
                    </asp:Button>&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:Button ID="ButtonBuy" runat="server" Text="去结算中心" Width="77px" OnClick="ButtonBuy_Click">
                    </asp:Button></td>
            </tr>
        </table>
    </form>
</body>
</html>
