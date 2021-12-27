using Carvajal.Datos.Models;
using Carvajal.Interface.RecursosCompartidos;

namespace Carvajal.Interface.IServicioVuelo_Salida
{
    public interface IServicioVuelo_Salida : IRecursoObtenerTodo<VueloSalida>, IRecursoObtenerPorId<VueloSalida, int>, IRecursoActualizar<VueloSalida>, IRecursoBorrar
    {
    }
}
