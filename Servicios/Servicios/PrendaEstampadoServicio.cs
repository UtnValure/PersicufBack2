using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using DB.Models;
using DB.Data;
using CORE.DTOs;
using Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Servicios.Servicios
{
    public class PrendaEstampadoServicio : IPrendaEstampadoServicio
    {
        private readonly PersicufContext _context;
        public PrendaEstampadoServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<PrendaEstampado>> DeletePrendaEstampado(int ID)
        {

            var respuesta = new Confirmacion<PrendaEstampado>();
            respuesta.Datos = null;

            try
            {
                var prendaEstampadoDB = await _context.PrendaEstampados.FindAsync(ID);
                if (prendaEstampadoDB != null)
                {
                    _context.PrendaEstampados.Remove(prendaEstampadoDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = prendaEstampadoDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La PrendaEstampado con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro la prendaEstampado con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }




        public async Task<Confirmacion<ICollection<PrendaEstampadoDTOconID>>> GetPrendaEstampado()
        {
            var respuesta = new Confirmacion<ICollection<PrendaEstampadoDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var prendasEstampadoDB = await _context.PrendaEstampados.ToListAsync();
                if (prendasEstampadoDB.Count() != 0)
                {
                    respuesta.Datos = new List<PrendaEstampadoDTOconID>();
                    foreach (var prendaEstampado in prendasEstampadoDB)
                    {
                        respuesta.Datos.Add(new PrendaEstampadoDTOconID()
                        {
                            ID = prendaEstampado.PEID,
                            PrendaID = prendaEstampado.PrendaID,
                            UbicacionID = prendaEstampado.UbicacionID,
                            ImagenID = prendaEstampado.ImagenID,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos las PrendaEstampado";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen PrendasEstampado";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }



        public async Task<Confirmacion<PrendaEstampadoDTO>> PostPrendaEstampado(PrendaEstampadoDTO prendaEstampadoDTO)
        {
            var respuesta = new Confirmacion<PrendaEstampadoDTO>();
            respuesta.Datos = null;

            try
            {
                var prendaEstampadoDB = await _context.PrendaEstampados.FirstOrDefaultAsync(x => x.UbicacionID == prendaEstampadoDTO.UbicacionID && x.ImagenID == prendaEstampadoDTO.ImagenID);
                if (prendaEstampadoDB == null)
                {
                    var prendaEstampadoNuevo = prendaEstampadoDTO.Adapt<PrendaEstampado>();
                    await _context.PrendaEstampados.AddAsync(prendaEstampadoNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La PrendaEstampado se creó correctamente.";
                    respuesta.Datos = prendaEstampadoDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "La PrendaEstampado ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<PrendaEstampadoDTO>> PutPrendaEstampado(int ID, PrendaEstampadoDTO prendaEstampadoDTO)
        {
            var respuesta = new Confirmacion<PrendaEstampadoDTO>();
            respuesta.Datos = null;

            try
            {
                var prendaEstampadoBD = await _context.PrendaEstampados.FindAsync(ID);
                if (prendaEstampadoBD != null)
                {
                    prendaEstampadoBD.PrendaID = prendaEstampadoDTO.PrendaID;
                    prendaEstampadoBD.ImagenID = prendaEstampadoDTO.ImagenID;
                    prendaEstampadoBD.UbicacionID = prendaEstampadoDTO.UbicacionID;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = prendaEstampadoBD.Adapt<PrendaEstampadoDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La PrendaEstampado fue modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "La PrendaEstampado no existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return respuesta;
            }
        }
    }
}
