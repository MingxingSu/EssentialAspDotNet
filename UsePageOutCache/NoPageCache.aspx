<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPageCache.aspx.cs" Inherits="UsePageOutCache.NoPageCache" %>
<%@ Register Src="~/WebClock.ascx" TagName="WelClock" TagPrefix="UUC" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
        <UUC:WelClock id="ccWebClock" runat="server"></UUC:WelClock>
    </form>
    <div>
    
    </div>
    </body>
</html>
