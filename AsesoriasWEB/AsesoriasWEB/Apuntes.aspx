<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apuntes.aspx.cs" Inherits="AsesoriasWEB.Apuntes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Departamento:
        <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Materia:
        <asp:DropDownList ID="dlMateria" runat="server">
        </asp:DropDownList>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir apunte" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Escribir reseña" />
        <br />
        Para escribir la reseña inserte el link del apunte aquí:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
