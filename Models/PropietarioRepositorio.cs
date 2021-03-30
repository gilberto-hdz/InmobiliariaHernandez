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
        private readonly string stringConnection;

        public PropietarioRepositorio()
        {
            stringConnection = "Server=(localdb)\\MSSQLLocalDB;Database=InmobiliariaHernandez;Trusted_Connection=True;MultipleActiveResultSets=true";
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
    }
}
