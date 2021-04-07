using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Models
{
    public class InquilinoRepositorio
    {
        private readonly IConfiguration configuration;
        private readonly string stringConnection;

        public InquilinoRepositorio(IConfiguration configuration)
        {
            this.configuration = configuration;
            stringConnection = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<Inquilino> ObtenerTodos()
        {
            var listaInquilinos = new List<Inquilino>();
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "SELECT Id, Dni, Apellido, Nombre, DireccionTrabajo, Telefono, Email, DniGarante, NombreGarante, ApellidoGarante, TelGarante " +
                    "FROM Inquilinos;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var cursor = command.ExecuteReader();
                    while (cursor.Read())
                    {
                        listaInquilinos.Add(new Inquilino
                        {
                            Id = cursor.GetInt32(0),
                            Dni = cursor.GetString(1),
                            Apellido = cursor.GetString(2),
                            Nombre = cursor.GetString(3),
                            DireccionTrabajo = cursor.GetString(4),
                            Telefono = cursor.GetString(5),
                            Email = cursor.GetString(6),
                            DniGarante = cursor.GetString(7),
                            NombreGarante = cursor.GetString(8),
                            ApellidoGarante = cursor.GetString(9),
                            TelGarante = cursor.GetString(10),
                        });
                    }
                    connection.Close();
                }
            }
            return listaInquilinos;
        }

        public Inquilino BuscarInquilino(int id)
        {
            Inquilino inquilino = null;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "SELECT Id, Dni, Apellido, Nombre, DireccionTrabajo, Telefono, Email, DniGarante, NombreGarante, ApellidoGarante, TelGarante " +
                    "FROM Inquilinos " +
                    "WHERE Id = @id;";
                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    var cursor = command.ExecuteReader();
                    while (cursor.Read())
                    {
                        inquilino = new Inquilino
                        {
                            Id = cursor.GetInt32(0),
                            Dni = cursor.GetString(1),
                            Apellido = cursor.GetString(2),
                            Nombre = cursor.GetString(3),
                            DireccionTrabajo = cursor.GetString(4),
                            Telefono = cursor.GetString(5),
                            Email = cursor.GetString(6),
                            DniGarante = cursor.GetString(7),
                            NombreGarante = cursor.GetString(8),
                            ApellidoGarante = cursor.GetString(9),
                            TelGarante = cursor.GetString(10),
                        };
                    }

                    connection.Close();

                }
            }
            return inquilino;
        }

        public int Alta(Inquilino inquilino)
        {
            int resultado = -1;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "INSERT INTO Inquilinos (Dni, Apellido, Nombre, DireccionTrabajo, Telefono, Email, DniGarante, NombreGarante, ApellidoGarante, TelGarante) " +
                    "VALUES (@dni, @apellido, @nombre, @direccionTrabajo, @telefono, @email, @dniGarante, @nombreGarante, @apellidoGarante, @telGarante);" +
                    "SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@dni", inquilino.Dni);
                    command.Parameters.AddWithValue("@apellido", inquilino.Apellido);
                    command.Parameters.AddWithValue("@nombre", inquilino.Nombre);
                    command.Parameters.AddWithValue("@direccionTrabajo", inquilino.DireccionTrabajo);
                    command.Parameters.AddWithValue("@telefono", inquilino.Telefono);
                    command.Parameters.AddWithValue("@email", inquilino.Email);
                    command.Parameters.AddWithValue("@dniGarante", inquilino.DniGarante);
                    command.Parameters.AddWithValue("@nombreGarante", inquilino.NombreGarante);
                    command.Parameters.AddWithValue("@apellidoGarante", inquilino.ApellidoGarante);
                    command.Parameters.AddWithValue("@telGarante", inquilino.TelGarante);
                    connection.Open();
                    resultado = Convert.ToInt32(command.ExecuteScalar());
                    inquilino.Id = resultado;
                    connection.Close();
                }
            }
            return resultado;
        }

        public int Baja(int id)
        {
            int resultado = -1;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "DELETE FROM Inquilinos " +
                    "WHERE Id = @id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
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

        public int Modificacion(Inquilino inquilino)
        {
            int resultado = -1;
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                string sql = "UPDATE Inquilinos " +
                    "SET Dni = @dni, Apellido = @apellido, Nombre = @nombre, DireccionTrabajo = @direccionTrabajo, Telefono = @telefono, " +
                    "Email = @email, DniGarante = @dniGarante, NombreGarante = @nombreGarante, ApellidoGarante = @apellidoGarante, TelGarante = @telGarante " +
                    "WHERE Id = @id;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@dni", inquilino.Dni);
                    command.Parameters.AddWithValue("@apellido", inquilino.Apellido);
                    command.Parameters.AddWithValue("@nombre", inquilino.Nombre);
                    command.Parameters.AddWithValue("@direccionTrabajo", inquilino.DireccionTrabajo);
                    command.Parameters.AddWithValue("@telefono", inquilino.Telefono);
                    command.Parameters.AddWithValue("@email", inquilino.Email);
                    command.Parameters.AddWithValue("@dniGarante", inquilino.DniGarante);
                    command.Parameters.AddWithValue("@nombreGarante", inquilino.NombreGarante);
                    command.Parameters.AddWithValue("@apellidoGarante", inquilino.ApellidoGarante);
                    command.Parameters.AddWithValue("@telGarante", inquilino.TelGarante);
                    command.Parameters.AddWithValue("@id", inquilino.Id);
                    connection.Open();
                    resultado = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return resultado;
        }
    }
}
