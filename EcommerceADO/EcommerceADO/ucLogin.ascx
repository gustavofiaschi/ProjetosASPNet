<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLogin.ascx.cs" Inherits="EcommerceADO.ucLogin" %>
<asp:Label ID="Label1" runat="server" Text="Usuário:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="#006600"></asp:Label>
<br />
<asp:LinkButton ID="lkbLogin" runat="server" onclick="lkbLogin_Click">Logar</asp:LinkButton>
&nbsp;<asp:LinkButton ID="lkbSair" runat="server" onclick="lkbSair_Click" 
    Visible="False">Sair</asp:LinkButton>

