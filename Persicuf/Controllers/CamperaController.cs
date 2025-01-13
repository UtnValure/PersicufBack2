using CORE.DTOs;
using DB.Data;
using DB.Models;
using Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Persicuf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamperaController : ControllerBase
    {
        private readonly ICamperaServicio _servicio;

        public CamperaController(ICamperaServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarCampera")]
        public async Task<ActionResult<Confirmacion<CamperaDTO>>> modificarCampera(int ID, CamperaDTO camperaDTO)
        {
            var respuesta = await _servicio.PutCampera(ID, camperaDTO);
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

        [HttpPost("crearCampera")]
        public async Task<ActionResult<Confirmacion<CamperaDTO>>> crearCampera(CamperaDTO camperaDTO)
        {
            var respuesta = await _servicio.PostCampera(camperaDTO);
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


        [HttpGet("obtenerCamperas")]
        public async Task<ActionResult<Confirmacion<ICollection<CamperaDTOconID>>>> obtenerCamperas()
        {
            var respuesta = await _servicio.GetCampera();
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

        [HttpGet("buscarCamperas")]
        public async Task<ActionResult<Confirmacion<ICollection<CamperaDTOconID>>>> buscarCamperas([FromQuery] string busqueda)
        {
            var respuesta = await _servicio.BuscarCamperas(busqueda);
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


        [HttpDelete("eliminarCampera")]
        public async Task<ActionResult<Confirmacion<Campera>>> eliminarCampera(int ID)
        {
            var respuesta = await _servicio.DeleteCampera(ID);
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