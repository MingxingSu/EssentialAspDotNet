<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UseSqlCacheDependency.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" />
                <asp:BoundField DataField="UserName" />
                <asp:BoundField DataField="Age" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
