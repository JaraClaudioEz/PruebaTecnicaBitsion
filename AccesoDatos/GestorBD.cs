using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PruebaTecnicaBitsion.Models;

namespace PruebaTecnicaBitsion.AccesoDatos
{
    public class GestorBD
    {
        public void CrearCliente(string nombre, DateTime nacimiento, string genero, bool estado, bool maneja, bool lentes, bool diabetico, string enfermedades)
        {
            var sql = "INSERT INTO Clientes (nombre, nacimiento, genero, estado, maneja, lentes, diabetico, enfermedades) " +
                      "VALUES (@nombre, @nacimiento, @genero, @estado, @maneja, @lentes, @diabetico, @enfermedades)";

            SqlConnection con = new SqlConnection("Data Source=JARADEV\\SQLEXPRESS;Initial Catalog=Ficticia;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@nacimiento", nacimiento);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@maneja", maneja);
            cmd.Parameters.AddWithValue("@lentes", lentes);
            cmd.Parameters.AddWithValue("@diabetico", diabetico);
            cmd.Parameters.AddWithValue("@enfermedades", enfermedades);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Cliente> ListadoClientes()
        {
            var lista = new List<Cliente>();
            var sql = "SELECT * FROM Clientes";
                      
            SqlConnection con = new SqlConnection("Data Source=JARADEV\\SQLEXPRESS;Initial Catalog=Ficticia;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = (int)dr["IdCliente"];
                cliente.Nombre = (string)dr["nombre"];
                cliente.Nacimiento = (DateTime)dr["nacimiento"];
                cliente.Genero = (string)dr["genero"];
                cliente.Estado = (bool)dr["estado"];
                cliente.Maneja = (bool)dr["maneja"];
                cliente.Lentes = (bool)dr["lentes"];
                cliente.Diabetico = (bool)dr["diabetico"];
                cliente.Enfermedades = (string)dr["enfermedades"];
                lista.Add(cliente);
            }

            con.Close();
            return lista;
        }
    }
}