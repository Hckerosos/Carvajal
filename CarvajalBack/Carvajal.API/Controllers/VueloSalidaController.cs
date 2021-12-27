using Carvajal.Datos.Models;
using Carvajal.Interface.IServicioVuelo_Salida;
using DigitalWare.Servicios.ServicioCliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carvajal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VueloSalidaController : ControllerBase
    {
        private readonly IServicioVuelo_Salida _servicioVuelo_Salida;

        public VueloSalidaController(IServicioVuelo_Salida servicioVuelo_Salida)
        {
            _servicioVuelo_Salida = servicioVuelo_Salida;

        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respuesta = await _servicioVuelo_Salida.ObtenerTodos();
            return Ok(respuesta);
        }

        [HttpGet("ObtenerPorId/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var respuesta = await _servicioVuelo_Salida.ObtenerPorId(id);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar([FromBody] VueloSalida vueloSalida)
        {
            var respuesta = await _servicioVuelo_Salida.Actualizar(vueloSalida);
            return Ok(respuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = await _servicioVuelo_Salida.Eliminar(id);
            return Ok(respuesta);
        }



    }
}
