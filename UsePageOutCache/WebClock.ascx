<%@ Control Language="C#" ClassName="WebClock" AutoEventWireup="true" CodeBehind="WebClock.ascx.cs" Inherits="UsePageOutCache.WebClock" %>
<%@ OutputCache Duration="5" VaryByParam="None" %>
<asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh" />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

