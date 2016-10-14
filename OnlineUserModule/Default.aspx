<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineUserModule.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="textbookUsername" runat="server"></asp:TextBox>
        <br />
        Password&nbsp;
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    
        <asp:Label ID="lblTotalUserCount" runat="server" Text="Total User Account"></asp:Label>
    </div>
    </form>
</body>
</html>
