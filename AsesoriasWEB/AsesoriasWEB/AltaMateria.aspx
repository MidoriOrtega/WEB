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
            <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            Clave de la materia:
            <asp:TextBox ID="txClave" runat="server"></asp:TextBox>
        </p>
        <p>
            Nombre de la materia:
            <asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="La clave de la materia se puede encontrar en tu plan de estudios"></asp:Label>
&nbsp;o en tu horario en Grace</p>
        <p>
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
        </p>
        <p>
            <asp:Button ID="btAlta" runat="server" Text="Dar de alta" OnClick="btAlta_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btRegresar" runat="server" Text="Regresar" OnClick="btRegresar_Click" />
        </p>
        <p>
            <asp:Label ID="lbResultado" runat="server" Text=" "></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
