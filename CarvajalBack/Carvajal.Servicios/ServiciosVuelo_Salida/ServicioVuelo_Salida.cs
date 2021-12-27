using Carvajal.Datos.Models;
using Carvajal.Interface.IServicioVuelo_Salida;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalWare.Servicios.ServicioCliente
{
    public class ServicioVueloSalida : IServicioVuelo_Salida
    {
        public readonly DbVuelosContext carvajalDbContext = null;

        public ServicioVueloSalida()
        {
            if (carvajalDbContext == null)
                carvajalDbContext = new DbVuelosContext();
        }

        public async Task<bool> Actualizar(VueloSalida cliente)
        {
            VueloSalida data = new();
            if (cliente.IdSalida > 0)
            {
                data = await carvajalDbContext.VueloSalida.FirstOrDefaultAsync(x => x.IdSalida == cliente.IdSalida);
                if (data != null)
                {
                    data.IdEstado = cliente.IdEstado;
                    data.Origen = cliente.Origen;
                    data.Destino = cliente.Destino;
                    data.Fecha = cliente.Fecha;
                    data.Salida = cliente.Salida;
                    var response = await carvajalDbContext.SaveChangesAsync();
                    if (response >= 1)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            else
            {
                if (cliente != null)
                {
                    var lastShowPieceId = await carvajalDbContext.VueloSalida.MaxAsync(x => x.IdSalida);
                    data = new()
                    {
                        IdEstado = cliente.IdEstado,
                        Destino = cliente.Destino,
                        Origen = cliente.Origen,
                        Fecha = cliente.Fecha,
                        Salida = cliente.Salida
                    };
                    await carvajalDbContext.VueloSalida.AddAsync(data);
                    var response = await carvajalDbContext.SaveChangesAsync();
                    if (response >= 1)
                        return true;
                    else
                        return false;
                }
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            VueloSalida data = new();
            try
            {
                data = await carvajalDbContext.VueloSalida.FirstOrDefaultAsync(x => x.IdSalida == id);
            }
            catch
            {
                data = null;
            }
            if (data != null)
            {
                carvajalDbContext.VueloSalida.Remove(data);
                var response = await carvajalDbContext.SaveChangesAsync();
                if (response >= 1)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }

        public async Task<VueloSalida> ObtenerPorId(int id)
        {
            return await carvajalDbContext.VueloSalida.SingleOrDefaultAsync(x => x.IdSalida.Equals(id));
        }

        public async Task<List<VueloSalida>> ObtenerTodos()
        {
            return await carvajalDbContext.VueloSalida.ToListAsync();
        }

    }
}
