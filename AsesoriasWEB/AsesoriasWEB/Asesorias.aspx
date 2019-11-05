<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asesorias.aspx.cs" Inherits="AsesoriasWEB.Asesorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Departamento:
        <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Materia:
        <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlMateria_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Asesor:<asp:DropDownList ID="dlAsesor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlAsesor_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Calificaciones del asesor:<asp:GridView ID="gvCalif" runat="server">
        </asp:GridView>
        <br />
        Reseñas del asesor:<asp:GridView ID="gvResenias" runat="server">
        </asp:GridView>
        <br />
        <br />
        Fecha:<asp:DropDownList ID="dlDia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDia_SelectedIndexChanged">
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
        <asp:TextBox ID="txDescripcion" runat="server" Height="181px" Width="553px"></asp:TextBox>
        <br />
        <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btAsesoria" runat="server" Text="Pedir asesoría" OnClick="btAsesoria_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btRegresa" runat="server" Text="Regresar" OnClick="btRegresa_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
