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
                var sql = "INSERT INTO Clientes (nombre, nacimiento, estado, maneja, lentes, diabetico, enfermedades, dni, idGenero) " +
                      "VALUES (@nombre, @nacimiento, @estado, @maneja, @lentes, @diabetico, @enfermedades, @dni, @idGenero)";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@nacimiento", cliente.Nacimiento);
                cmd.Parameters.AddWithValue("@idGenero", cliente.IdGenero);
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
                var sql = "UPDATE Clientes SET nombre=@nombre, nacimiento=@nacimiento, estado=@estado, maneja=@maneja, lentes=@lentes, diabetico=@diabetico, enfermedades=@enfermedades, dni=@dni, idGenero=@idGenero " +
                      "WHERE idCliente=@idCliente";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@nacimiento", cliente.Nacimiento);
                cmd.Parameters.AddWithValue("@idGenero", cliente.IdGenero);
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

        public VMCliente BuscarCliente(int idCliente)
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
                cliente.IdGenero = (int)dr["idGenero"];
                cliente.Estado = (bool)dr["estado"];
                cliente.Maneja = (bool)dr["maneja"];
                cliente.Lentes = (bool)dr["lentes"];
                cliente.Diabetico = (bool)dr["diabetico"];
                cliente.Enfermedades = (string)dr["enfermedades"];

                dr.Close();
                con.Close();

                VMCliente vm = new VMCliente();
                vm.ClienteModel = cliente;
                return vm;
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

        public List<DTOCliente> ListadoClientes()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var lista = new List<DTOCliente>();
                var sql = @"SELECT idCliente, nombre, dni, nacimiento, estado, maneja, lentes, diabetico, descripcion
                            FROM Clientes c
                            JOIN Generos g ON c.idGenero = g.idGenero";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DTOCliente cliente = new DTOCliente();
                    cliente.Id = (int)dr["idCliente"];
                    cliente.Nombre = (string)dr["nombre"];
                    cliente.DNI = (int)dr["dni"];
                    cliente.Nacimiento = (DateTime)dr["nacimiento"];
                    cliente.Descripcion = (string)dr["descripcion"];
                    cliente.Estado = (bool)dr["estado"];
                    cliente.Maneja = (bool)dr["maneja"];
                    cliente.Lentes = (bool)dr["lentes"];
                    cliente.Diabetico = (bool)dr["diabetico"];

                    lista.Add(cliente);
                }

                dr.Close();
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

        public List<Genero> ListadoGeneros()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var lista = new List<Genero>();
                var sql = "SELECT * FROM Generos";

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Genero genero = new Genero();
                    genero.Id = (int)dr["idGenero"];
                    genero.Descripcion = (string)dr["descripcion"];
                    
                    lista.Add(genero);
                }

                dr.Close();
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
    }
}