<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionesDeAsesorias.aspx.cs" Inherits="AsesoriasWEB.ModificacionesDeAsesorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Materia:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlMateria_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Asesor:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="dlAsesorado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlAsesorado_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Correo del asesor:&nbsp;&nbsp;&nbsp; <asp:Label ID="lbCorreo" runat="server" Text=" "></asp:Label>
            <br />
            <br />
            Fecha pedida:&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbFechaPedida" runat="server" Text=" "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Fecha a proponer:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlDia" runat="server" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;&nbsp; /&nbsp;&nbsp;
            <asp:DropDownList ID="dlMes" runat="server" AutoPostBack="True" >
            </asp:DropDownList>
            <br />
            <br />
            Hora propuesta:&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbHoraProp" runat="server" Text=" "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Hora a proponer:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txHora" runat="server"></asp:TextBox>
            <br />
            <br />
            Lugar propuesto:&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbLugarProp" runat="server" Text=" "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lugar a proponer:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txLugar" runat="server"></asp:TextBox>
            <br />
            <br />
            Modalidad pedida:&nbsp;&nbsp;&nbsp; <asp:Label ID="lbModalidad" runat="server" Text=" "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Modalidad propuesta:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlModalidad" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Modificar" OnClick="Button1_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Aceptar" OnClick="Button2_Click1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Rechazar" OnClick="Button3_Click1" />
            <br />
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
            <br />
            <br />
            <asp:Button ID="btRegresa" runat="server" Text="Regresar" OnClick="btRegresa_Click1" />
        </div>
    </form>
</body>
</html>
