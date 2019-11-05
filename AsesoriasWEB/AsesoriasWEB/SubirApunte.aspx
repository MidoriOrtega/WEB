<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubirApunte.aspx.cs" Inherits="AsesoriasWEB.SubirApunte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            URL:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txURL" runat="server"></asp:TextBox>
            <br />
            <br />
            Departamento:&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Materia:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            Profesor:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txProfesor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
            <br />
            <asp:Button ID="btSubir" runat="server" OnClick="btSubir_Click" Text="Subir" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
