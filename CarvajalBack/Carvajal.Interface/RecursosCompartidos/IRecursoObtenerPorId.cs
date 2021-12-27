using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carvajal.Interface.RecursosCompartidos
{
    public interface IRecursoObtenerPorId<Clase,Id>
    {
        Task<Clase> ObtenerPorId(Id id);
    }
}
