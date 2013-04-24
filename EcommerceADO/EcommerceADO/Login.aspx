<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EcommerceADO.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Login:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label2" runat="server" Text="Senha:"></asp:Label>
            &nbsp;<asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogar" runat="server" onclick="btnLogar_Click" 
                Text="Logar" />
            <br />
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
