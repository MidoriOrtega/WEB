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
            Próximas aserorías:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
&nbsp;
            <asp:Button ID="btPide" runat="server" Text="Pedir asesoría" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btPeticiones" runat="server" Text="Peticiones de asesoría pendiente" />
&nbsp;<br />
            <br />
&nbsp;
            <asp:Button ID="btApuntes" runat="server" OnClick="btApuntes_Click" style="margin-left: 0px" Text="Apuntes" Width="197px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btModificaciones" runat="server" style="margin-left: 0px" Text="Modificaciones de asesoría" Width="437px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Modificar mi información" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Reseñas de asesorías dadas:"></asp:Label>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Reseñas de asesorías tomadas:"></asp:Label>
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
