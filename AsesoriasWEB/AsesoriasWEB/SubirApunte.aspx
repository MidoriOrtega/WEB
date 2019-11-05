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
            URL:
            <asp:TextBox ID="txURL" runat="server"></asp:TextBox>
            <br />
            <br />
            Departamento:
            <asp:DropDownList ID="dlDepto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlDepto_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Materia:<asp:DropDownList ID="dlMateria" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            Profesor:
            <asp:TextBox ID="txProfesor" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbResp" runat="server" Text=" "></asp:Label>
            <br />
            <br />
            <asp:Button ID="btSubir" runat="server" OnClick="btSubir_Click" Text="Subir" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Regresar" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
