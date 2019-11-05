<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AsesoriasWEB.Inicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Próximas aserorías como asesor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:GridView ID="gvAsesor" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            Próximas asesorías como asesorado:<asp:GridView ID="gvAsesorado" runat="server">
            </asp:GridView>
            <br />
            <br />
&nbsp;
            <asp:Button ID="btPide" runat="server" Text="Pedir asesoría" OnClick="btPide_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btPeticiones" runat="server" Text="Peticiones de asesoría pendiente" OnClick="btPeticiones_Click" />
&nbsp;<br />
            <br />
&nbsp;
            <asp:Button ID="btApuntes" runat="server" OnClick="btApuntes_Click" style="margin-left: 0px" Text="Apuntes" Width="197px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btModificaciones" runat="server" style="margin-left: 0px" Text="Modificaciones de asesoría" Width="437px" OnClick="btModificaciones_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Modificar mi información" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Dar de alta una materia" Width="327px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Reseñas de asesorías dadas:"></asp:Label>
            <asp:GridView ID="gvRAsesor" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Reseñas de asesorías tomadas:"></asp:Label>
            <asp:GridView ID="gvRAsesorado" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
