<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webAppDatasets.WebForm1" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
    
    <div>
         <asp:Literal ID="literalTable" runat="server"></asp:Literal>
        <p></p>
    </div>
   
      
    <form id="form1" runat="server">
        Nombre :
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <br />
        Direccion :
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
        <br />
        Telefono :
        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" />
        <br />
        <br />
    </form>

    </body>
</html>
