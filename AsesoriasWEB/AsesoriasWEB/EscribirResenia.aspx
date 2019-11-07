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
            Calificación:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txCalif" runat="server"></asp:TextBox>
            <br />
            <br />
            Descripción:&nbsp;&nbsp;&nbsp; <br />
&nbsp;<asp:TextBox ID="txDescripcion" runat="server" Height="240px" Width="619px"></asp:TextBox>
            <br />
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
            <br />
            <asp:Button ID="btHecho" runat="server" Text="Hecho" OnClick="btHecho_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
            <br />
            <asp:Label runat="server" Text=" "></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
