<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrar.aspx.cs" Inherits="AsesoriasWEB.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Usuario:<asp:TextBox ID="txUsuario" runat="server"></asp:TextBox>
        <br />
        <br />
        Contraseña:<asp:TextBox ID="txContra" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btRegistra" runat="server" Text="Iniciar sesión" />
        <br />
        <br />
        ¿No tienes una cuenta?
        <asp:Button ID="btRegristra" runat="server" Text="Regístrate" />
    </form>
</body>
</html>
