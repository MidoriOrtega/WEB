﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="AsesoriasWEB.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Clave única:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txCU" runat="server"></asp:TextBox>
            <br />
            <br />
            Nombre:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            Teléfono:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txTel" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            Contraseña:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txContra" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btAlta" runat="server" Text="Darse de alta" OnClick="btAlta_Click" />
            <br />
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
            <br />
            <br />
            <asp:Button ID="btRegresa" runat="server" Text="Regresar a inicio de sesión" OnClick="btRegresa_Click" />
            <br />
        </div>
    </form>
</body>
</html>
