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
    public class ZapatoServicio : IZapatoServicio
    {
        private readonly PersicufContext _context;
        public ZapatoServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Zapato>> DeleteZapato(int ID)
        {

            var respuesta = new Confirmacion<Zapato>();
            respuesta.Datos = null;

            try
            {
                var zapatoDB = await _context.Zapatos.FindAsync(ID);
                if (zapatoDB != null)
                {
                    _context.Zapatos.Remove(zapatoDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = zapatoDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El zapato con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro el zapato con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


        public async Task<Confirmacion<ICollection<ZapatoDTOconID>>> GetZapato()
        {
            var respuesta = new Confirmacion<ICollection<ZapatoDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var zapatoDB = await _context.Zapatos.ToListAsync();
                if (zapatoDB.Count() != 0)
                {
                    respuesta.Datos = new List<ZapatoDTOconID>();
                    foreach (var Zapato in zapatoDB)
                    {
                        respuesta.Datos.Add(new ZapatoDTOconID()
                        {
                            ID = Zapato.ZapatoID,
                            PuntaMetal = Zapato.PuntaMetalica,
                            TalleNumericoID = Zapato.TNID,
                            Precio = Zapato.Prenda.Precio,
                            ColorID = Zapato.Prenda.ColorID,
                            MaterialID = Zapato.Prenda.MaterialID,
                            UsuarioID = Zapato.Prenda.UsuarioID,
                            RubroID = Zapato.Prenda.RubroID,
                            ImagenID = Zapato.Prenda.ImagenID,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos los Zapatos";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen Zapatos";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }
        public async Task<Confirmacion<ZapatoDTO>> PostZapato(ZapatoDTO zapatoDTO)
        {
            var respuesta = new Confirmacion<ZapatoDTO>();
            respuesta.Datos = null;

            try
            {
                var zapatoDB = await _context.Zapatos.FirstOrDefaultAsync(x => x.Nombre == zapatoDTO.Nombre);
                if (zapatoDB == null)
                {
                    var zapatoNuevo = zapatoDTO.Adapt<Zapato>();
                    await _context.Zapatos.AddAsync(zapatoNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El zapato se creó correctamente.";
                    respuesta.Datos = zapatoDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "El zapato con nombre: " + zapatoDTO.Nombre + " ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<ZapatoDTO>> PutZapato(int ID, ZapatoDTO zapatoDTO)
        {
            var respuesta = new Confirmacion<ZapatoDTO>();
            respuesta.Datos = null;

            try
            {
                var zapatoBD = await _context.Zapatos.FindAsync(ID);
                if (zapatoBD != null)
                {
                    zapatoBD.PuntaMetalica = zapatoDTO.PuntaMetal;
                    zapatoBD.TNID = zapatoDTO.TalleNumericoID;
                    zapatoBD.Prenda.ColorID = zapatoDTO.ColorID;
                    zapatoBD.Prenda.MaterialID = zapatoDTO.MaterialID;
                    zapatoBD.Prenda.UsuarioID = zapatoDTO.UsuarioID;
                    zapatoBD.Prenda.ImagenID = zapatoDTO.ImagenID;
                    zapatoBD.Prenda.RubroID = zapatoDTO.RubroID;
                    zapatoBD.Prenda.Precio = zapatoDTO.Precio;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = zapatoBD.Adapt<ZapatoDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El zapato fué modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El zapato no existe.";
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
