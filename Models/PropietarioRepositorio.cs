using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Models
{
    public class PropietarioRepositorio
    {
        private readonly IConfiguration configuration;
        private readonly string stringConnection;

        public PropietarioRepositorio(IConfiguration configuration)
        {
            this.configuration = configuration;
            stringConnection = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<Propietario> ObtenerTodos()
        {
            var listaPropietarios = new List<Propietario>();
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "SELECT Id, Dni, Apellido, Nombre, Direccion " +
                    "FROM Propietarios;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var cursor = command.ExecuteReader();
                    while (cursor.Read())
                    {
                        listaPropietarios.Add(new Propietario
                        {
                            Id = cursor.GetInt32(0),
                            Dni = cursor.GetString(1),
                            Apellido = cursor.GetString(2),
                            Nombre = cursor.GetString(3),
                            Direccion = cursor.GetString(4),
                        });
                    }
                    connection.Close();
                }
            }
            return listaPropietarios;
        }

        public Propietario BuscarPropietario(int id)
        {
            Propietario propietario = null;
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "SELECT Id, Dni, Apellido, Nombre, Direccion " +
                    "FROM Propietarios " +
                    "WHERE Id = @id;";
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var cursor = command.ExecuteReader();
                    while (cursor.Read())
                    {
                        propietario = new Propietario
                        {
                            Id = cursor.GetInt32(0),
                            Dni = cursor.GetString(1),
                            Apellido = cursor.GetString(2),
                            Nombre = cursor.GetString(3),
                            Direccion = cursor.GetString(4)
                        };
                    }
                    
                    connection.Close();
                    
                }
            }
            return propietario;
        }

        public int Alta(Propietario propietario)
        {
            int resultado = -1;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "INSERT INTO Propietarios (Nombre, Apellido, Dni, Direccion) " +
                    "VALUES (@nombre, @apellido, @dni, @direccion);" +
                    "SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", propietario.Nombre);
                    command.Parameters.AddWithValue("@apellido", propietario.Apellido);
                    command.Parameters.AddWithValue("@dni", propietario.Dni);
                    command.Parameters.AddWithValue("@direccion", propietario.Direccion);
                    connection.Open();
                    resultado = Convert.ToInt32(command.ExecuteScalar());
                    propietario.Id = resultado;
                    connection.Close();
                }
            }
            return resultado;
        }

        public int Baja(int id)
        {
            int resultado = -1;
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "DELETE FROM Propietarios " +
                    "WHERE Id = @id;";
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    resultado = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return resultado;
        }

        public int Modificacion(Propietario propietario)
        {
            int resultado = -1;
            using(SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "UPDATE Propietarios " +
                    "SET Nombre = @nombre, Dni = @dni, Apellido = @apellido, Direccion = @direccion " +
                    "WHERE Id = @id;";
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", propietario.Nombre);
                    command.Parameters.AddWithValue("@dni", propietario.Dni);
                    command.Parameters.AddWithValue("@apellido", propietario.Apellido);
                    command.Parameters.AddWithValue("@direccion", propietario.Direccion);
                    command.Parameters.AddWithValue("@id", propietario.Id);
                    connection.Open();
                    resultado = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return resultado;
        }
    }
}
