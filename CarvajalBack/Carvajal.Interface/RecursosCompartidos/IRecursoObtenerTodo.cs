using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Carvajal.Interface.RecursosCompartidos
{
    public interface IRecursoObtenerTodo<Clase>
    {
        Task<List<Clase>> ObtenerTodos();
    }
}
