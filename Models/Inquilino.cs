using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaHernandez.Models
{
    public class Inquilino
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DireccionTrabajo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DniGarante { get; set; }
        public string NombreGarante { get; set; }
        public string ApellidoGarante { get; set; }
        public string TelGarante { get; set; }

        public override string ToString()
        {
            return $"({Id}), {Nombre} {Apellido}";
        }
    }
}
