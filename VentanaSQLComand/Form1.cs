using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentanaSQLComand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\jhordan\source\repos\VentanaSQLComand\Tienda.mdf;
            Integrated Security=True");
            con.Open();
       
            String query = "SELECT * FROM Producto";
            SqlCommand comand = new SqlCommand(query, con);
            var resultado = comand.ExecuteReader();
            while (resultado.Read())
            {
                LoadProd.Text += resultado["nombre"].ToString()+"\r\n";
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\jhordan\source\repos\VentanaSQLComand\Tienda.mdf;
            Integrated Security=True");
            con.Open();
            String query = $"INSERT INTO Producto (nombre,precio) VALUES(@nombre,@precio)";
            SqlCommand comand = new SqlCommand(query, con);
            comand.Parameters.AddWithValue("nombre",txtNombre.Text);
            comand.Parameters.AddWithValue("precio", txtPrecio.Text);
            comand.ExecuteNonQuery();
            con.Close();

        }
    }
}
