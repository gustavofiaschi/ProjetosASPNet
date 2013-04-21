<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProdutos.aspx.cs" Inherits="EcommerceADO.ListaProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
        <ItemTemplate>
            <table style="width:100%;" >
                <tr>
                    <td>
                      Nome:
                    </td>
                    <td>
                    <%#Eval("Nome") %>
                    </td>
                    <td>
                      Descrição:
                    </td>
                    <td>
                    <%#Eval("Descricao") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr style="width:100%;" />
        </SeparatorTemplate>
    </asp:Repeater>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="RetornaProdutos" TypeName="Business.ProdutoBusiness">
        <SelectParameters>
            <asp:Parameter Name="categoria" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
