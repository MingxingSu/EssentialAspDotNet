<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageWithNavigator.aspx.cs" Inherits="UseViewState.PageWithNavigator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Url<br />
        <asp:TextBox ID="textUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnNavi" runat="server" OnClick="btnNavi_Click" Text="Enter" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text="Pre" />
        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" />
        <br />
    
    </div>
    </form>
</body>
</html>
