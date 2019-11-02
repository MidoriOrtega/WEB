<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMateria.aspx.cs" Inherits="AsesoriasWEB.AltaMateria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Departamento:
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Clave de la materia:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Nombre de la materia:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btAlta" runat="server" Text="Dar de alta" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btRegresar" runat="server" Text="Regresar" />
        </p>
        <p>
            <asp:Label ID="lbResultado" runat="server" Text=" "></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
