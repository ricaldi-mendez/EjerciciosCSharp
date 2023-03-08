using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppDatasets
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // crear conexion
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhordan-temporal2\source\repos\webAppDatasets\App_Data\Database1.mdf;Integrated Security=True";
                string query = "SELECT * FROM Contactos";
                SqlConnection connection = new SqlConnection(connectionString);

                //referencia de select al adaptador
                SqlCommand comand = new SqlCommand(query, connection);
                SqlDataAdapter adaptador = new SqlDataAdapter(comand);

                //llenar el dataset con los registros de la tabla contactos
                DataSet tblProductos = new DataSet();
                adaptador.Fill(tblProductos, "Contactos");

                //dataTable

                DataTable dt = tblProductos.Tables["Contactos"];

                //mostrar datos de la primera fila de la tabla productos
                //DataRow row = tblProductos.Rows[0];
                // var resultado = row["id"]+ "\t" + row["nombre"] + "\t" + row["precio"] ;

                // Creando html para la tabla

                mostrarTabla(dt);
            }

        }
        public void mostrarTabla(DataTable dt) {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table>");
            htmlTable.Append("<tr><th>Id</th><th>Nombre</th><th>Direccion</th><th>Telefono</th></tr>");

            foreach (DataRow row in dt.Rows)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append($"<td> {row["Id"]} </td>");
                htmlTable.Append($"<td> {row["nombre"]} </td>");
                htmlTable.Append($"<td> {row["direccion"]} </td>");
                htmlTable.Append($"<td> {row["telefono"]} </td>");
                htmlTable.Append($"<asp:Button Text='ver'> ");
                htmlTable.Append("</tr>");

            }

            htmlTable.Append("</table>");
            literalTable.Text = htmlTable.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //boton agregar
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhordan-temporal2\source\repos\webAppDatasets\App_Data\Database1.mdf;Integrated Security=True";
            string query = "SELECT * FROM Contactos";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adaptador = new SqlDataAdapter(command);
            SqlCommandBuilder builder = new SqlCommandBuilder(adaptador);

            adaptador.InsertCommand = builder.GetInsertCommand();
            adaptador.UpdateCommand = builder.GetUpdateCommand();
            adaptador.DeleteCommand = builder.GetDeleteCommand();

            DataSet tblProductos = new DataSet();
            adaptador.Fill(tblProductos, "Contactos");

            //capturar texto inputs, para llenar dataTable
            DataTable datos = tblProductos.Tables["Contactos"];
            DataRow newRow = datos.NewRow();
            newRow["nombre"] = TxtNombre.Text;
            newRow["direccion"] = TxtDireccion.Text;
            newRow["telefono"] = TxtTelefono.Text;
            //agregar
            datos.Rows.Add(newRow);
            datos.AcceptChanges();
            
            //guardar cambios en la base de datos;
            adaptador.Update(tblProductos, "Contactos");

          
        }
    }
}