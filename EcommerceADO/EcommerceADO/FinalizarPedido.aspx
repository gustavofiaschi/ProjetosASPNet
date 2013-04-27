<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FinalizarPedido.aspx.cs" Inherits="EcommerceADO.FinalizarPedido" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <table style="width: 50%; text-align: center; vertical-align: middle;">
                <tr>
                    <td colspan="3">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("Foto", "Imagens/Produtos/{0}") %>'
                            Width="80" Height="80" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hdfIdProduto" Value='<%#Eval("Id") %>' runat="server" />
                        <b><strong style="font-size: 26;">
                            <%#Eval("Nome") %></strong></b>
                        <br />
                        <br />
                        <i>
                            <%#Eval("Descricao") %></i>
                        <br />
                        <br />
                        <%#Eval("Preco", "{0:c}")%>'>
                        <asp:Label ID="lblPreco" runat="server" Text='<%#Eval("Preco")%>' Visible="false"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:TextBox ID="txtQuantidade" Text='<%#Eval("Quantidade")%>' runat="server">                   
                        </asp:TextBox>
                        <asp:MaskedEditExtender ID="txtPreco_MaskedEditExtender" runat="server" Mask="99"
                            MaskType="Number" TargetControlID="txtQuantidade">
                        </asp:MaskedEditExtender>
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
    <asp:Label ID="Label1" runat="server" Text="Valor Total: " Font-Bold="True"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    &nbsp;<br />
    <br />
    <asp:Button ID="btn" runat="server" Text="Recalcular" OnClick="btn_Click" />
    <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" OnClick="btnFinalizarCompra_Click" />
    <asp:ModalPopupExtender ID="modalFinalizarPedido" runat="server" TargetControlID="btnFinalizarCompra" PopupControlID="MsgBox" CancelControlID="btnNao">
    </asp:ModalPopupExtender>
    <div id="MsgBox" style="background-color:Gray; text-align: center; color:White; width: 20%; display: none;">
        <div>
            Deseja finalizar seu pedido? Valor Total:&nbsp;<br />
            <asp:Label ID="lblValorTotal" runat="server" Font-Bold="True" />
            <br />
            <br />
        </div>
        <div>
            <div>
                <asp:Button ID="btnSim" runat="server" Text="Sim" OnClick="btnSim_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNao" runat="server" Text="Não" />
            </div>
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
