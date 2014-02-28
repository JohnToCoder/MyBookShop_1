<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyBookShop.Register" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>注册</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table id="Table1" style="background-color: lightblue; left: 8px; width: 440px; position: absolute;
            top: 8px; height: 168px" cellspacing="1" cellpadding="0" width="440" border="0">
            <tbody>
                <tr>
                    <td colspan="2">
                        &gt;&gt;用户注册
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        登录名*</td>
                    <td style="width: 232px">
                        <asp:TextBox ID="TextBoxLoginName" runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:Button
                            ID="ButtonCheck" runat="server" Width="64px" Text="是否存在？" OnClick="ButtonCheck_Click">
                        </asp:Button></td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        姓名*</td>
                    <td style="width: 232px">
                        <asp:TextBox ID="TextBoxUserName" runat="server" Width="120px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        密码*</td>
                    <td style="width: 232px">
                        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        重复密码*</td>
                    <td style="width: 232px">
                        <asp:TextBox ID="TextBoxPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        联系地址</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxAddress" runat="server" Width="368px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 90px">
                        邮编</td>
                    <td style="width: 232px">
                        <asp:TextBox ID="TextBoxZip" runat="server" Width="224px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <hr />
                        <asp:Button ID="ButtonOK" runat="server" Width="56px" Text="提交" OnClick="ButtonOK_Click">
                        </asp:Button></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
