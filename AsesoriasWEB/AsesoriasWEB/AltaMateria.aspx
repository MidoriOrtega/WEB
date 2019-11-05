<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMateria.aspx.cs" Inherits="AsesoriasWEB.AltaMateria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <h4>La clave de la materia se puede encontrar en tu plan de estudios o en tu horario de GRACE</h4>
        <p>
            Departamento:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </p>
        <p>
            Clave de la materia:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txClave" runat="server"></asp:TextBox>
        </p>
        <p>
            Nombre de la materia:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txNombre" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lbResp" runat="server" Text=""></asp:Label>
            &nbsp;<p>
            <asp:Button ID="btAlta" runat="server" Text="Dar de alta" OnClick="btAlta_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btRegresar" runat="server" Text="Regresar" OnClick="btRegresar_Click" />
            &nbsp;</p>
    </form>
</body>
</html>
