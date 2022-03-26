using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenIIParcial.Entidades
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }
        public string Clave { get; set; }

        public Usuario()
        {

        }

        public Usuario(string idUsuario, string nombre, string cargo, bool estado, string clave)
        {
            IdUsuario=idUsuario;
            Nombre=nombre;
            Cargo=cargo;
            Estado=estado;
            Clave=clave;
        }
    }

}
