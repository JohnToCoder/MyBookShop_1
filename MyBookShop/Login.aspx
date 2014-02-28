<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyBookShop.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>用户登录</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 32px; WIDTH: 240px; POSITION: absolute; TOP: 8px; HEIGHT: 158px"
					cellSpacing="0" cellPadding="0" width="240" border="0">
					<TR>
						<TD style="WIDTH: 69px"></TD>
						<TD style="WIDTH: 164px" align="center"><FONT face="宋体"><IMG alt="" src="Images/logo.JPG" width="130"></FONT></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 69px">&nbsp;<asp:label id="Label1" runat="server">登录名*</asp:label></TD>
						<TD style="WIDTH: 164px"><asp:textbox id="TextBoxLoginName" runat="server" Width="160px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 69px">&nbsp;<asp:label id="Label2" runat="server">密码*</asp:label></TD>
						<TD style="WIDTH: 164px"><asp:textbox id="TextBoxPassword" runat="server" Width="160px" TextMode="Password"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><asp:button id="ButtonLogin" runat="server" Width="56px" Text="登录" onclick="ButtonLogin_Click"></asp:button>&nbsp;&nbsp;
							<asp:hyperlink id="HyperLinkRegister" runat="server" NavigateUrl="Register.aspx">注册</asp:hyperlink></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>

