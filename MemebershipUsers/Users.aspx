<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="MemebershipUsers.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:sqldatasource ID="Sqldatasource1" runat="server" ConnectionString="<%$ ConnectionStrings:aspnetdbConnectionString %>" SelectCommand="SELECT [ApplicationName], [LoweredApplicationName], [ApplicationId], [Description] FROM [vw_aspnet_Applications]"></asp:sqldatasource>
    </div>
    </form>
</body>
</html>

