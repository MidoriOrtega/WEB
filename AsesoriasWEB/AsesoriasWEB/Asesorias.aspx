<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asesorias.aspx.cs" Inherits="AsesoriasWEB.Asesorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Departamento:
        <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Materia:
        <asp:DropDownList ID="dlMateria" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Asesor:<asp:DropDownList ID="dlAsesor" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Calificaciones del asesor:<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        Reseñas del asesor:<asp:GridView ID="gvResenias" runat="server">
        </asp:GridView>
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
        Descripción:<br />
        <asp:TextBox ID="TextBox1" runat="server" Height="181px" Width="553px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="btAsesoria" runat="server" Text="Pedir asesoría" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btRegresa" runat="server" Text="Regresar" />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
