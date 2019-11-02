<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionesDeAsesorias.aspx.cs" Inherits="AsesoriasWEB.ModificacionesDeAsesorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Materia:<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Asesorado:"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            Correo/teléfono del asesor:<asp:Label ID="lbCorreo" runat="server" Text=" "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="correo"></asp:Label>
            <br />
            <br />
            Fecha:<asp:DropDownList ID="dlDia" runat="server" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;/
            <asp:DropDownList ID="dlMes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Hora:<asp:TextBox ID="txHora" runat="server"></asp:TextBox>
            <br />
            <br />
            Lugar:<asp:TextBox ID="txLugar" runat="server"></asp:TextBox>
            <br />
            <br />
            Modalidad:<asp:DropDownList ID="dlModalidad" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Modificar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Aceptar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Rechazar" />
            <br />
            <br />
            <asp:Button ID="btRegresa" runat="server" Text="Regresar" />
        </div>
    </form>
</body>
</html>
