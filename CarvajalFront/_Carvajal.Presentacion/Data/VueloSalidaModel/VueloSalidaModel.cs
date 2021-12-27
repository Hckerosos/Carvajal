using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carvajal.Presentacion.Data.VueloSalidaModel
{
    public class VueloSalidaModel
    {
            public int IdSalida { get; set; }
            public int IdEstado { get; set; }
            public string Origen { get; set; }
            public string Destino { get; set; }
            public DateTime Fecha { get; set; }
            public string Salida { get; set; }
    }
}
