<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="AsesoriasWEB.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Clave única:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Nombre:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Teléfono:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Correo:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            Contraseña:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            ¿Qué preieres compartir con otros usuarios?<br />
            <asp:RadioButton ID="Correo" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
            <br />
            <asp:RadioButton ID="Teléfono" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Darse de alta" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Regresar a iniciar sesión" />
            <br />
        </div>
    </form>
</body>
</html>
