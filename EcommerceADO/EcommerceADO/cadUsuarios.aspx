<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="cadUsuarios.aspx.cs" Inherits="EcommerceADO.cadUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblLogin" runat="server" Text="Login:" />
            </td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSenha" runat="server" Text="Senha:" />
            </td>
            <td>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status:" />
            </td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPessoa" runat="server" Text="Pessoa:" />
            </td>
            <td>
                <asp:DropDownList ID="ddlPessoa" runat="server" AutoPostBack="True" 
                    DataSourceID="ObjectDataSource1" DataTextField="Nome" DataValueField="Id" />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="RetornaPessoas" TypeName="Business.PessoaBusiness">
                </asp:ObjectDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                    onclick="btnSalvar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
