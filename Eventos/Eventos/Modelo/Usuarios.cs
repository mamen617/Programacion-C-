using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelo
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public String NombreUsuario { get; set; }
        //Constructor Completo Actualización y Eliminación
        public Usuarios(int UsuarioID, string NombreUsuario)
        {
            this.UsuarioID = UsuarioID;
            this.NombreUsuario = NombreUsuario;
        }
        //Constructor de Selección
        public Usuarios(string NombreUsuario)
        {
            this.NombreUsuario = NombreUsuario;
        }

    }
}
