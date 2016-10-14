<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UsePageOutCache.Default" %>
<%@ OutputCache Duration="5" VaryByParam="None" %>
<head runat="server">
    <title></title>
</head>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form id="form1" runat="server">
    <div>
    
        OutCacheDuration:
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
    &nbsp;s<br />
        <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Refresh" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
