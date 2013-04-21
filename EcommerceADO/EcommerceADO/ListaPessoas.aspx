<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaPessoas.aspx.cs" Inherits="EcommerceADO.ListaPessoas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" 
        GridLines="None" DataKeyNames="Id" onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" NullDisplayText="---" 
                SortExpression="Nome" />
            <asp:BoundField DataField="CPF" HeaderText="CPF" SortExpression="CPF" />
            <asp:BoundField DataField="DataNascimento" DataFormatString="{0:d}" 
                HeaderText="DataNascimento" SortExpression="DataNascimento" />
            <asp:ImageField DataImageUrlField="NomeFoto" 
                DataImageUrlFormatString="~/Imagens/Fotos/{0}" HeaderText="Foto">
            </asp:ImageField>
            <asp:CommandField ButtonType="Button" ShowCancelButton="False" 
                ShowEditButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>--%>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"> 
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("button").mouseenter(fadeOut);
            $("button").click(fadeIn);
            //$("button").mouseleave(fadeOut);
            //fadeOut();
        });

        function fadeOut() {
            $("img").fadeOut();
            $("button").css("background-color", "Lime");
        }

        function fadeIn() {
            $("img").fadeIn();
            $("button").css("background-color", "White");
        }

        function slide() {
            $("img").slideDown();
            $("button").css("background-color", "Red");
        }          
    </script>
    <button type="button">Mostrar Imagens</button>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" 
        onitemcommand="Repeater1_ItemCommand"          
        onprerender="Repeater1_PreRender">
        <ItemTemplate>
            <table>
                <tr>
                    <td class="tdDescricao">
                        Nome:
                    </td>
                    <td>
                        <%#Eval("Nome") %>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl='<%#Eval("NomeFoto", "Imagens/Fotos/{0}") %>'
                            Width="60" Height="60" />
                    </td>
                </tr>
                <tr>
                    <td class="tdDescricao">
                        Data Nascimento:
                    </td>
                    <td>
                        <%#Eval("DataNascimento", "{0:d}") %>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="tdDescricao">
                        CPF:
                    </td>
                    <td>
                        <%#Eval("CPF") %>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <asp:Button runat="server" Text="Editar" CommandName="Edit" CommandArgument='<%#Eval("Id") %>' />
                </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>        
    </asp:Repeater>
    
    <asp:GridView ID="GridView1" runat="server">
        <EmptyDataTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server">Não há itens</asp:HyperLink>
        </EmptyDataTemplate>
    </asp:GridView>
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="RetornaPessoas"
        TypeName="Business.PessoaBusiness" onselected="ObjectDataSource1_Selected"></asp:ObjectDataSource>
</asp:Content>
