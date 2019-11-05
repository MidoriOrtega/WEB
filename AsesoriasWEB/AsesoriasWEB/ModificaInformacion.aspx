<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificaInformacion.aspx.cs" Inherits="AsesoriasWEB.ModificaInformacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Cambiar&nbsp;&nbsp;
        <asp:DropDownList ID="dlCambia" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Nuevo:
        <asp:TextBox ID="txCambia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btCambia" runat="server" OnClick="btCambia_Click" Text="Realizar el cambio" />
        <br />
        <br />
        Agregar una materia (dar asesorías):<br />
        Departamento:<asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Materia: <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btAgregar" runat="server" Text="Agregar" />
        <br />
        <br />
        Modificar horario actual<br />
        <br />
        Horario:
        <asp:DropDownList ID="dlHorario" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btQuita" runat="server" Text="Quitar" />
        <br />
        <br />
        Agregar horario:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btAgrega" runat="server" Text="Agregar" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="Regresar" OnClick="Button6_Click" />
    </form>
</body>
</html>
