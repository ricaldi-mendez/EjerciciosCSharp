using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CrudWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostratTabla();          
        }

        public void mostratTabla() {
            string stringConection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhordan-temporal2\source\repos\CrudWebApp\App_Data\Database1.mdf;Integrated Security=True";
            string query = "SELECT * FROM Contactos";

            SqlConnection conection = new SqlConnection(stringConection);
            SqlCommand comand = new SqlCommand(query, conection);

            SqlDataAdapter adaptador = new SqlDataAdapter(comand);

            DataSet dataset = new DataSet();
            adaptador.Fill(dataset,"Contactos");

            DataTable dt = dataset.Tables["Contactos"];

            StringBuilder stringhtml = new StringBuilder();
            foreach (DataRow row in dt.Rows )
            {
                stringhtml.Append("<tr>");
                stringhtml.Append($"<td>{row["Id"]}</td>");
                stringhtml.Append($"<td>{row["nombre"]}</td>");
                stringhtml.Append($"<td>{row["direccion"]}</td>");
                stringhtml.Append($"<td>{row["telefono"]}</td>");
                stringhtml.Append("</tr>");
            }
            tablaContactos.Text = stringhtml.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string stringConection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhordan-temporal2\source\repos\CrudWebApp\App_Data\Database1.mdf;Integrated Security=True";
            string query = "SELECT * FROM Contactos";

            SqlConnection conection = new SqlConnection(stringConection);
            SqlCommand comand = new SqlCommand(query, conection);

            SqlDataAdapter adaptador = new SqlDataAdapter(comand);

            SqlCommandBuilder builder = new SqlCommandBuilder(adaptador);

            adaptador.InsertCommand = builder.GetInsertCommand();
            adaptador.UpdateCommand = builder.GetUpdateCommand();
            adaptador.DeleteCommand = builder.GetDeleteCommand();

            DataSet dataset = new DataSet();
            adaptador.Fill(dataset, "Contactos");

            DataTable dt = dataset.Tables["Contactos"];
            DataRow newRow = dt.NewRow();
        
            newRow["nombre"] = txtNombre.Text;
            newRow["direccion"] = txtDireccion.Text;
            newRow["telefono"] = txtTelefono.Text;
            dt.Rows.Add(newRow);

            adaptador.Update(dataset,"Contactos");

            mostratTabla();

        }
    }
}