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
    public class PrendaEstampadoController : ControllerBase
    {
        private readonly IPrendaEstampadoServicio _servicio;

        public PrendaEstampadoController(IPrendaEstampadoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpPut("modificarPrendaEstampado")]
        public async Task<ActionResult<Confirmacion<PrendaEstampadoDTO>>> modificarPrendaEstampado(int ID, PrendaEstampadoDTO prendaEstampadoDTO)
        {
            var respuesta = await _servicio.PutPrendaEstampado(ID, prendaEstampadoDTO);
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

        [HttpPost("crearPrendaEstampado")]
        public async Task<ActionResult<Confirmacion<PrendaEstampadoDTO>>> crearPrendaEstampado(PrendaEstampadoDTO prendaEstampadoDTO)
        {
            var respuesta = await _servicio.PostPrendaEstampado(prendaEstampadoDTO);
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


        [HttpGet("obtenerPrendasEstampado")]
        public async Task<ActionResult<Confirmacion<ICollection<PrendaEstampadoDTOconID>>>> obtenerPrendasEstampado()
        {
            var respuesta = await _servicio.GetPrendaEstampado();
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

        [HttpDelete("eliminarPrendaEstampado")]
        public async Task<ActionResult<Confirmacion<PrendaEstampado>>> eliminarPrendaEstampado(int ID)
        {
            var respuesta = await _servicio.DeletePrendaEstampado(ID);
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