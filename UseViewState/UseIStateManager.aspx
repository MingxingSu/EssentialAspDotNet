<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseIStateManager.aspx.cs" Inherits="UseViewState.UseIStateManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="false">
    <div>    
        UserName<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Email<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Get" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    
    </div>
    </form>
</body>
</html>
