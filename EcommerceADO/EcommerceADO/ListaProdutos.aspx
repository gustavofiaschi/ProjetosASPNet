<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaProdutos.aspx.cs" Inherits="EcommerceADO.ListaProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Categorias:
    <asp:DropDownList ID="ddlCategorias" runat="server" AutoPostBack="true">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <table style="width: 50%; text-align: center; vertical-align: middle;">
                <tr>
                    <td colspan="3">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Foto", "Imagens/Produtos/{0}") %>'
                            Width="80" Height="80" />
                    </td>
                    <td>
                        <b><strong style="font-size: 26;">
                            <%#Eval("Nome") %></strong></b>
                        <br />
                        <br />
                        <i>
                            <%#Eval("Descricao") %></i>
                        <br />
                        <br />
                        <%#Eval("Preco","{0:c}") %>
                    </td>
                    <td style="text-align: right;">
                        <asp:Button runat="server" ID="btnEditar" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("Id") %>' />
                        <br />
                        <asp:Button runat="server" ID="btnComprar" Text="Comprar" CommandName="Comprar" CommandArgument='<%#Eval("Id") %>' />
                        <br />
                        <asp:Button runat="server" ID="btnAddCarrinho" Text="Add ao Carrinho" CommandName="AddCarrinho"
                            CommandArgument='<%#Eval("Id") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <tr style="border: medium dotted #000000; width: 100%; background-color: Black; height: 2%">
                <br />
            </tr>
        </SeparatorTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="RetornaProdutos"
        TypeName="Business.ProdutoBusiness">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlCategorias" Name="categoria" PropertyName="SelectedValue"
                Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
