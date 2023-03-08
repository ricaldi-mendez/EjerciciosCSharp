<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CrudWebApp.WebForm1" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <table >
            <tr>
                <th>  ID  </th>
                <th>  nombre  </th>
                <th>  direccion  </th>
                <th>  telefono  </th>
            </tr>
            <asp:Literal ID="tablaContactos" runat="server"></asp:Literal>
        </table>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" />

        <br />
        <br />
        Nombre :<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        Direccion :
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />
        Telefono:
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <br />

    </form>

    </body>
</html>
