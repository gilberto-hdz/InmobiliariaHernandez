using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Models
{
    public class PropietarioRepositorio
    {
        private readonly string stringConnection;

        public PropietarioRepositorio()
        {
            this.stringConnection = "Server=(localdb)\\MSSQLLocalDB;Database=BDInmobiliaria;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public List<Propietario> ObtenerTodos()
        {
            var listaPropietarios = new List<Propietario>();

            return listaPropietarios;
        }
    }
}
