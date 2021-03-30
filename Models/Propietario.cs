using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return $"({Id}), {Nombre} {Apellido}";
        }
    }
}
