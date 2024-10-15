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
    public class PrendaServicio : IPrendaServicio
    {
        private readonly PersicufContext _context;
        public PrendaServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Prenda>> DeletePrenda(int ID)
        {

            var respuesta = new Confirmacion<Prenda>();
            respuesta.Datos = null;

            try
            {
                var prendaDB = await _context.Prendas.FindAsync(ID);
                if (prendaDB != null)
                {
                    _context.Prendas.Remove(prendaDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = prendaDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La prenda con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro la prenda con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


        public async Task<Confirmacion<ICollection<PrendaDTOconID>>> GetPrenda()
        {
            var respuesta = new Confirmacion<ICollection<PrendaDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var prendaDB = await _context.Prendas.ToListAsync();
                if (prendaDB.Count() != 0)
                {
                    respuesta.Datos = new List<PrendaDTOconID>();
                    foreach (var Prenda in prendaDB)
                    {
                        respuesta.Datos.Add(new PrendaDTOconID()
                        {
                            ID = Prenda.PrendaID,
                            Precio = Prenda.Precio,
                            ColorID = Prenda.ColorID,
                            MaterialID = Prenda.MaterialID,
                            UsuarioID = Prenda.UsuarioID,
                            RubroID = Prenda.RubroID,
                            ImagenID = Prenda.ImagenID,
                            Nombre = Prenda.Nombre,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todas las Prendas";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen Prendas";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }
        public async Task<Confirmacion<PrendaDTO>> PostPrenda(PrendaDTO prendaDTO)
        {
            var respuesta = new Confirmacion<PrendaDTO>();
            respuesta.Datos = null;

            try
            {
                var prendaDB = await _context.Prendas.AsNoTracking().FirstOrDefaultAsync(x => x.Nombre == prendaDTO.Nombre);
                if (prendaDB == null)
                {
                    var prendaNuevo = prendaDTO.Adapt<Prenda>();
                    await _context.Prendas.AddAsync(prendaNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El prenda se creó correctamente.";
                    respuesta.Datos = prendaDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "La prenda con nombre: " + prendaDTO.Nombre + " ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<PrendaDTO>> PutPrenda(int ID, PrendaDTO prendaDTO)
        {
            var respuesta = new Confirmacion<PrendaDTO>();
            respuesta.Datos = null;

            try
            {
                var prendaBD = await _context.Prendas.FindAsync(ID);
                if (prendaBD != null)
                {
                    prendaBD.ColorID = prendaDTO.ColorID;
                    prendaBD.MaterialID = prendaDTO.MaterialID;
                    prendaBD.UsuarioID = prendaDTO.UsuarioID;
                    prendaBD.ImagenID = prendaDTO.ImagenID;
                    prendaBD.RubroID = prendaDTO.RubroID;
                    prendaBD.Precio = prendaDTO.Precio;
                    prendaBD.Nombre = prendaDTO.Nombre; 

                    await _context.SaveChangesAsync();
                    respuesta.Datos = prendaBD.Adapt<PrendaDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El prenda fué modificada correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El prenda no existe.";
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
