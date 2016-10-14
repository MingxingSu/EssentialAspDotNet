<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenField.aspx.cs" Inherits="UseHiddenField.WebForm1" %>

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
        <asp:HiddenField  ID="StateContainer" runat="server"/>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save UserName to HiddenField" />
        <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="GetFromSever" />
           <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
