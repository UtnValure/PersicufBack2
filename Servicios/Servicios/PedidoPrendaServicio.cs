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
    public class PedidoPrendaServicio : IPedidoPrendaServicio
    {
        private readonly PersicufContext _context;
        public PedidoPrendaServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<PedidoPrenda>> DeletePedidoPrenda(int ID)
        {

            var respuesta = new Confirmacion<PedidoPrenda>();
            respuesta.Datos = null;

            try
            {
                var pedidoPrendaDB = await _context.PedidosPrenda.FindAsync(ID);
                if (pedidoPrendaDB != null)
                {
                    _context.PedidosPrenda.Remove(pedidoPrendaDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = pedidoPrendaDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El PedidoPrenda con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro el PedidoPrenda con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }




        public async Task<Confirmacion<ICollection<PedidoPrendaDTOconID>>> GetPedidoPrenda()
        {
            var respuesta = new Confirmacion<ICollection<PedidoPrendaDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var pedidosPrendaDB = await _context.PedidosPrenda.ToListAsync();
                if (pedidosPrendaDB.Count() != 0)
                {
                    respuesta.Datos = new List<PedidoPrendaDTOconID>();
                    foreach (var pedidoPrenda in pedidosPrendaDB)
                    {
                        respuesta.Datos.Add(new PedidoPrendaDTOconID()
                        {
                            ID = pedidoPrenda.PPID,
                            Cantidad = pedidoPrenda.Cantidad,
                            PrendaID = pedidoPrenda.PrendaID,
                            PedidoID = pedidoPrenda.PedidoID,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos los PedidosPrenda";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen PedidosPrenda";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }



        public async Task<Confirmacion<PedidoPrendaDTO>> PostPedidoPrenda(PedidoPrendaDTO pedidoPrendaDTO)
        {
            var respuesta = new Confirmacion<PedidoPrendaDTO>();
            respuesta.Datos = null;

            try
            {
                var pedidoPrendaDB = await _context.PedidosPrenda.AsNoTracking().FirstOrDefaultAsync(x => x.PedidoID == pedidoPrendaDTO.PedidoID && x.PrendaID == pedidoPrendaDTO.PrendaID);
                if (pedidoPrendaDB == null)
                {
                    var pedidoPrendaNuevo = pedidoPrendaDTO.Adapt<PedidoPrenda>();
                    await _context.PedidosPrenda.AddAsync(pedidoPrendaNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El PedidoPrenda se creó correctamente.";
                    respuesta.Datos = pedidoPrendaDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "El PedidoPrenda ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<PedidoPrendaDTO>> PutPedidoPrenda(int ID, PedidoPrendaDTO pedidoprendaDTO)
        {
            var respuesta = new Confirmacion<PedidoPrendaDTO>();
            respuesta.Datos = null;

            try
            {
                var pedidoprendaBD = await _context.PedidosPrenda.FindAsync(ID);
                if (pedidoprendaBD != null)
                {
                    pedidoprendaBD.Cantidad = pedidoprendaDTO.Cantidad;
                    pedidoprendaBD.PrendaID = pedidoprendaDTO.PrendaID;
                    pedidoprendaBD.PedidoID = pedidoprendaDTO.PedidoID;



                    await _context.SaveChangesAsync();
                    respuesta.Datos = pedidoprendaBD.Adapt<PedidoPrendaDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El PedidoPrenda fue modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El PedidoPrenda no existe.";
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