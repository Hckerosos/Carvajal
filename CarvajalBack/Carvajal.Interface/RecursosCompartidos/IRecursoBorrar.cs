using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carvajal.Interface.RecursosCompartidos
{
    public interface IRecursoBorrar
    {
        Task<bool> Eliminar(int id);
    }
}
