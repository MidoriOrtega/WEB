<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificaInformacion.aspx.cs" Inherits="AsesoriasWEB.ModificaInformacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Cambiar&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dlCambia" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Nuevo:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txCambia" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btCambia" runat="server" OnClick="btCambia_Click" Text="Realizar el cambio" />
        <br />
        <asp:Label ID="lbRespM" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <h3>Agregar una materia (dar asesorías):</h3>
        Departamento:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Materia:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btAgregar" runat="server" Text="Agregar" OnClick="btAgregar_Click" />
        <br />
        <br />
        <br />
        Mis materias:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dlMisMaterias" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btQuitaMat" runat="server" OnClick="btQuitaMat_Click" Text="Quitar" />
        <br />
        <asp:Label ID="lbRespMat" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <h3>Modificar horario actual</h3><br />
        Horario:&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="dlHorario" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btQuita" runat="server" Text="Quitar" OnClick="btQuita_Click" />
        <br />
        <br />
        <br />
        <h3>Agregar horario</h3><br />
        Día:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txDia" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hora:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txHora" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btAgrega" runat="server" Text="Agregar" OnClick="btAgrega_Click" />
        <br />
        <br />
        <asp:Label ID="lbRespH" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="Regresar" OnClick="Button6_Click" />
    </form>
</body>
</html>
