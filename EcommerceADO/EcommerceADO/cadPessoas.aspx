<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadPessoas.aspx.cs" Inherits="EcommerceADO.cadPessoas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome" 
    Text="Nome"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
<br />
<asp:Label ID="lblDataNasc" runat="server" AssociatedControlID="txtDataNasc" 
    Text="Data Nascimento"></asp:Label>
&nbsp;
<asp:TextBox ID="txtDataNasc" runat="server"></asp:TextBox>
<br />
<asp:Label ID="lblCPF" runat="server" AssociatedControlID="txtCPF" Text="CPF"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
<br />
<br />
<asp:FileUpload ID="uploadFoto" runat="server" />
<br />
<br />
<br />
<asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" />
<br />
<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
<br />
<br />
<br />
<br />
</asp:Content>
