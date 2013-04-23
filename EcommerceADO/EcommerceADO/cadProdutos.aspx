<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cadProdutos.aspx.cs" Inherits="EcommerceADO.cadProdutos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 50%;">
        <tr>
            <td>
                <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescricao" runat="server" Text="Descrição"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPreco" runat="server" Text="Preço"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtPreco_MaskedEditExtender" runat="server" 
                    Mask="999.99" MaskType="Number" TargetControlID="txtPreco">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblQtdEstoque" runat="server" Text="Qtd. Estoque"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtQtdEstoque" runat="server"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtQtdEstoque_MaskedEditExtender" runat="server" 
                    MaskType="Number" TargetControlID="txtQtdEstoque" Mask="99999">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFoto" runat="server" Text="Foto"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" 
                    Text="Salvar" />
            </td>
            <td>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>
