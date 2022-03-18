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
        public void CrearCliente(Cliente cliente)
        {
            var sql = "INSERT INTO Clientes (nombre, nacimiento, genero, estado, maneja, lentes, diabetico, enfermedades, dni) " +
                      "VALUES (@nombre, @nacimiento, @genero, @estado, @maneja, @lentes, @diabetico, @enfermedades, @dni)";

            SqlConnection con = new SqlConnection("Data Source=JARADEV\\SQLEXPRESS;Initial Catalog=Ficticia;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@nacimiento", cliente.Nacimiento);
            cmd.Parameters.AddWithValue("@genero", cliente.Genero);
            cmd.Parameters.AddWithValue("@estado", cliente.Estado);
            cmd.Parameters.AddWithValue("@maneja", cliente.Maneja);
            cmd.Parameters.AddWithValue("@lentes", cliente.Lentes);
            cmd.Parameters.AddWithValue("@diabetico", cliente.Diabetico);
            cmd.Parameters.AddWithValue("@enfermedades", cliente.Enfermedades);
            cmd.Parameters.AddWithValue("@dni", cliente.DNI);

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
                cliente.DNI = (int)dr["dni"];
                cliente.Nacimiento = (DateTime)dr["nacimiento"];
                cliente.Genero = (string)dr["genero"];
                cliente.Estado = (bool)dr["estado"];
                cliente.Maneja = (bool)dr["maneja"];
                cliente.Lentes = (bool)dr["lentes"];
                cliente.Diabetico = (bool)dr["diabetico"];
                if (dr["enfermedades"] != null)
                {
                    cliente.Enfermedades = (string)dr["enfermedades"];
                }
                
                lista.Add(cliente);
            }

            con.Close();
            return lista;
        }
    }
}