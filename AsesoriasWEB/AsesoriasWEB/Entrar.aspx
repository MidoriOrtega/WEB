<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrar.aspx.cs" Inherits="AsesoriasWEB.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Clave única:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        Contraseña:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txContra"  TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btRegistra" runat="server" Text="Iniciar sesión" OnClick="btRegistra_Click" />
        <br />
        <br />
        <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        ¿No tienes una cuenta?&nbsp;&nbsp;&nbsp; <asp:Button ID="btRegristra" runat="server" Text="Regístrate" OnClick="btRegristra_Click" />
    </form>
</body>
</html>
