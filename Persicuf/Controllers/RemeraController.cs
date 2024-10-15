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
    public class RemeraController : ControllerBase
    {
        private readonly IRemeraServicio _servicio;

        public RemeraController(IRemeraServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarRemera")]
        public async Task<ActionResult<Confirmacion<RemeraDTO>>> modificarRemera(int ID, RemeraDTO remeraDTO)
        {
            var respuesta = await _servicio.PutRemera(ID, remeraDTO);
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

        [HttpPost("crearRemera")]
        public async Task<ActionResult<Confirmacion<RemeraDTO>>> crearRemera(RemeraDTO remeraDTO)
        {
            var respuesta = await _servicio.PostRemera(remeraDTO);
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


        [HttpGet("obtenerRemeras")]
        public async Task<ActionResult<Confirmacion<ICollection<RemeraDTOconID>>>> obtenerRemeras()
        {
            var respuesta = await _servicio.GetRemera();
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

        [HttpDelete("eliminarRemera")]
        public async Task<ActionResult<Confirmacion<Remera>>> eliminarRemera(int ID)
        {
            var respuesta = await _servicio.DeleteRemera(ID);
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