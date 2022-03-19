using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PruebaTecnicaBitsion.Models;
using System.Configuration;

namespace PruebaTecnicaBitsion.AccesoDatos
{
    public class GestorBD
    {
        public void CrearCliente(Cliente cliente)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var sql = "INSERT INTO Clientes (nombre, nacimiento, genero, estado, maneja, lentes, diabetico, enfermedades, dni) " +
                      "VALUES (@nombre, @nacimiento, @genero, @estado, @maneja, @lentes, @diabetico, @enfermedades, @dni)";

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public void EditarCliente(Cliente cliente)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var sql = "UPDATE Clientes SET nombre=@nombre, nacimiento=@nacimiento, genero=@genero, estado=@estado, maneja=@maneja, lentes=@lentes, diabetico=@diabetico, enfermedades=@enfermedades, dni=@dni " +
                      "WHERE idCliente=@idCliente";

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
                cmd.Parameters.AddWithValue("@idCliente", cliente.Id);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public Cliente BuscarCliente(int idCliente)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                Cliente cliente = new Cliente();
                var sql = "SELECT * FROM Clientes WHERE idCliente = @id";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idCliente);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                cliente.Id = (int)dr["idCliente"];
                cliente.Nombre = (string)dr["nombre"];
                cliente.DNI = (int)dr["dni"];
                cliente.Nacimiento = (DateTime)dr["nacimiento"];
                cliente.Genero = (string)dr["genero"];
                cliente.Estado = (bool)dr["estado"];
                cliente.Maneja = (bool)dr["maneja"];
                cliente.Lentes = (bool)dr["lentes"];
                cliente.Diabetico = (bool)dr["diabetico"];
                cliente.Enfermedades = (string)dr["enfermedades"];

                con.Close();
                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                con.Close();
                
            }
        }

        public List<Cliente> ListadoClientes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var lista = new List<Cliente>();
                var sql = "SELECT * FROM Clientes";

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                con.Close();
                
            }
        }

        public void EliminarCliente(Cliente cliente)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var sql = "DELETE FROM Clientes WHERE idCliente=@id";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", cliente.Id);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}