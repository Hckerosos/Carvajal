using System;
using System.Collections.Generic;

#nullable disable

namespace Carvajal.Datos.Models
{
    public partial class VueloSalida
    {
        public int IdSalida { get; set; }
        public int IdEstado { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; }
        public string Salida { get; set; }

        public virtual VueloEstado IdEstadoNavigation { get; set; }
    }
}
