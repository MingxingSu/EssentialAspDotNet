<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookie.aspx.cs" Inherits="Cookies.Cookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="textUsername" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save UserName to Cookie" />
        <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="GetFromCookie" />
           <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
