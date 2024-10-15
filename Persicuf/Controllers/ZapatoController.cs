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
    public class ZapatoController : ControllerBase
    {
        private readonly IZapatoServicio _servicio;

        public ZapatoController(IZapatoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarZapato")]
        public async Task<ActionResult<Confirmacion<ZapatoDTO>>> modificarZapato(int ID, ZapatoDTO zapatoDTO)
        {
            var respuesta = await _servicio.PutZapato(ID, zapatoDTO);
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

        [HttpPost("crearZapato")]
        public async Task<ActionResult<Confirmacion<ZapatoDTO>>> crearZapato(ZapatoDTO zapatoDTO)
        {
            var respuesta = await _servicio.PostZapato(zapatoDTO);
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


        [HttpGet("obtenerZapatos")]
        public async Task<ActionResult<Confirmacion<ICollection<ZapatoDTOconID>>>> obtenerZapatos()
        {
            var respuesta = await _servicio.GetZapato();
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

        [HttpDelete("eliminarZapato")]
        public async Task<ActionResult<Confirmacion<Zapato>>> eliminarZapato(int ID)
        {
            var respuesta = await _servicio.DeleteZapato(ID);
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
