using CORE.DTOs;
using DB.Data;
using DB.Models;
using Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persicuf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoPrendaController : ControllerBase
    {
        private readonly IPedidoPrendaServicio _servicio;

        public PedidoPrendaController(IPedidoPrendaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarPedidoPrenda")]
        public async Task<ActionResult<Confirmacion<PedidoPrendaDTO>>> modificarPedidoPrenda(int ID, PedidoPrendaDTO pedidoPrendaDTO)
        {
            var respuesta = await _servicio.PutPedidoPrenda(ID, pedidoPrendaDTO);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        [HttpPost("crearPedidoPrenda")]
        public async Task<ActionResult<Confirmacion<PedidoPrendaDTO>>> crearPedidoPrenda(PedidoPrendaDTO pedidoPrendaDTO)
        {
            var respuesta = await _servicio.PostPedidoPrenda(pedidoPrendaDTO);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return StatusCode(StatusCodes.Status201Created, respuesta);
        }


        [HttpGet("obtenerPedidosPrenda")]
        public async Task<ActionResult<Confirmacion<ICollection<PedidoPrendaDTOconID>>>> obtenerPedidosPrenda()
        {
            var respuesta = await _servicio.GetPedidoPrenda();
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        [HttpDelete("eliminarPedidoPrenda")]
        public async Task<ActionResult<Confirmacion<PedidoPrenda>>> eliminarPedidoPrenda(int ID)
        {
            var respuesta = await _servicio.DeletePedidoPrenda(ID);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return NotFound(respuesta);
            }
            return Ok(respuesta);
        }

    }

}