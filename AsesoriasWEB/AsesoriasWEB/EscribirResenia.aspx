<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EscribirResenia.aspx.cs" Inherits="AsesoriasWEB.EscribirResenia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Calificación:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Descripción:<br />
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Height="240px" Width="619px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btHecho" runat="server" Text="Hecho" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Regresar" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
