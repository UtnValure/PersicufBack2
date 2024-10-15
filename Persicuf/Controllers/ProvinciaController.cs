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
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaServicio _servicio;

        public ProvinciaController(IProvinciaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarProvincia")]
        public async Task<ActionResult<Confirmacion<ProvinciaDTO>>> modificarProvincia(int ID, ProvinciaDTO provinciaDTO)
        {
            var respuesta = await _servicio.PutProvincia(ID, provinciaDTO);
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

        [HttpPost("crearProvincia")]
        public async Task<ActionResult<Confirmacion<ProvinciaDTO>>> crearProvincia(ProvinciaDTO provinciaDTO)
        {
            var respuesta = await _servicio.PostProvincia(provinciaDTO);
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


        [HttpGet("obtenerProvincias")]
        public async Task<ActionResult<Confirmacion<ICollection<ProvinciaDTOconID>>>> obtenerProvincias()
        {
            var respuesta = await _servicio.GetProvincia();
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

        [HttpDelete("eliminarProvincia")]
        public async Task<ActionResult<Confirmacion<Provincia>>> eliminarProvincia(int ID)
        {
            var respuesta = await _servicio.DeleteProvincia(ID);
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