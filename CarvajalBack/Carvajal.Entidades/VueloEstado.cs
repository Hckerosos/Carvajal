using System;
using System.Collections.Generic;

#nullable disable

namespace Carvajal.Datos.Models
{
    public partial class VueloEstado
    {
        public VueloEstado()
        {
            VueloSalida = new HashSet<VueloSalida>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<VueloSalida> VueloSalida { get; set; }
    }
}
