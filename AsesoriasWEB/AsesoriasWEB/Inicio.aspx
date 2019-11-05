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
            <h3>Próximas aserorías como asesor:</h3>
            <asp:GridView ID="gvAsesor" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <h3>Próximas asesorías como asesorado:</h3>
            <asp:GridView ID="gvAsesorado" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btPide" runat="server" Text="Pedir asesoría" OnClick="btPide_Click" Width="100px"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btPeticiones" runat="server" Text="Peticiones de asesoría pendiente" OnClick="btPeticiones_Click" Width="210px"/>
&nbsp;<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btApuntes" runat="server" OnClick="btApuntes_Click" style="margin-left: 0px" Text="Apuntes" Width="65px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btModificaciones" runat="server" style="margin-left: 0px" Text="Modificaciones de asesoría" Width="175px" OnClick="btModificaciones_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Modificar mi información" OnClick="Button1_Click" Width="155px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Dar de alta una materia" Width="155px" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <h3>Reseñas de asesorías dadas:</h3>
            <asp:GridView ID="gvRAsesor" runat="server"></asp:GridView>
            <br />
            <h3>Reseñas de asesorías tomadas:</h3>
            <asp:GridView ID="gvRAsesorado" runat="server"></asp:GridView>
            <br />
            <br />
            <br />
            <asp:Button ID="btnCerrar" runat="server" Text="Cerrar sesión" OnClick="btnCerrar_Click" />
        </div>
    </form>
</body>
</html>
