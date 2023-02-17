using System.Data.SqlClient;
// See https://aka.ms/new-console-template for more information


SqlConnection con= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\jhordan\source\repos\ConexionBD\Database1.mdf;
Integrated Security=True");

con.Open();
Console.WriteLine(con.State);

String query = "SELECT * FROM Pokemones";
SqlCommand comand = new SqlCommand(query,con);
var resultado = comand.ExecuteReader();
while (resultado.Read()) {
    Console.WriteLine(resultado["nombre"]);
}


Console.WriteLine("Holaaa");
con.Close();