<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apuntes.aspx.cs" Inherits="AsesoriasWEB.Apuntes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Departamento:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Materia:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlMateria_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvNotas" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir apunte" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Escribir reseña" OnClick="Button2_Click1" />
        <br />
        <br />
        Para escribir la reseña inserte el link del apunte aquí:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txLink" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbResp" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Regresar" OnClick="Button3_Click" />
    </form>
</body>
</html>
