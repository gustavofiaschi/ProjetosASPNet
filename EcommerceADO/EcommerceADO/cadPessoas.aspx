<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadPessoas.aspx.cs" Inherits="EcommerceADO.cadPessoas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    <asp:Label ID="lblNome" runat="server" AssociatedControlID="txtNome" 
    Text="Nome"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rqfNome" runat="server" 
        ControlToValidate="txtNome" ErrorMessage="Campo Nome é obrigatório" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
<asp:Label ID="lblDataNasc" runat="server" AssociatedControlID="txtDataNasc" 
    Text="Data Nascimento"></asp:Label>
&nbsp;
<asp:TextBox ID="txtDataNasc" runat="server">
</asp:TextBox>
    <asp:CalendarExtender ID="txtDataNasc_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtDataNasc">
    </asp:CalendarExtender>
    <asp:CustomValidator ID="cvDataNascimento" runat="server" 
        ControlToValidate="txtDataNasc" ErrorMessage="Idade deve ser maior que 18 anos" 
        ForeColor="Red" onservervalidate="cvDataNascimento_ServerValidate">*</asp:CustomValidator>
<br />
<asp:Label ID="lblCPF" runat="server" AssociatedControlID="txtCPF" Text="CPF"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revCPF" runat="server" 
        ControlToValidate="txtCPF" ErrorMessage="CPF Inválido" ForeColor="Red" 
        ValidationExpression="(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)">*</asp:RegularExpressionValidator>
<br />
<br />
<asp:FileUpload ID="uploadFoto" runat="server" />
<br />
<br />
<br />
<asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" />
    <asp:Button ID="btnValidar" runat="server" onclick="btnValidar_Click" 
        Text="Validar" />
<br />
<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
<br />
<br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<br />
</asp:Content>
