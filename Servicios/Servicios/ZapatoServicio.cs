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
                            ID = Zapato.PrendaID,
                            PuntaMetal = Zapato.PuntaMetalica,
                            TalleNumericoID = Zapato.TNID,
                            Precio = Zapato.Precio,
                            ColorID = Zapato.ColorID,
                            MaterialID = Zapato.MaterialID,
                            UsuarioID = Zapato.UsuarioID,
                            RubroID = Zapato.RubroID,
                            Nombre = Zapato.Nombre,
                            ImagenID = Zapato.ImagenID ?? 0
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

        public async Task<Confirmacion<ICollection<ZapatoDTOconID>>> BuscarZapatos(string busqueda)
        {
            var respuesta = new Confirmacion<ICollection<ZapatoDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var zapatoDB = await _context.Zapatos
                .Where(p => p.Nombre.ToLower().Contains(busqueda.ToLower()))
                .OrderByDescending(p => p.Nombre.ToLower().StartsWith(busqueda.ToLower()))
                .ThenBy(p => p.Nombre)
                .ToListAsync();



                if (zapatoDB.Count() != 0)
                {
                    respuesta.Datos = new List<ZapatoDTOconID>();
                    foreach (var Zapato in zapatoDB)
                    {
                        respuesta.Datos.Add(new ZapatoDTOconID()
                        {
                            ID = Zapato.PrendaID,
                            Precio = Zapato.Precio,
                            ColorID = Zapato.ColorID,
                            MaterialID = Zapato.MaterialID,
                            UsuarioID = Zapato.UsuarioID,
                            RubroID = Zapato.RubroID,
                            ImagenID = Zapato.ImagenID,
                            Nombre = Zapato.Nombre,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todas los Zapatos que coiciden con la busqueda";
                    return respuesta;
                }

                respuesta.Mensaje = "No se encontraron zapatos con ese nombre";
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
                var zapatoDB = await _context.Zapatos.AsNoTracking().FirstOrDefaultAsync(x => x.Nombre == zapatoDTO.Nombre);
                if (zapatoDB == null)
                {
                    var zapatoNuevo = zapatoDTO.Adapt<Zapato>();
                    zapatoNuevo.TNID = zapatoDTO.TalleNumericoID;
                    zapatoNuevo.PuntaMetalica = zapatoDTO.PuntaMetal;
                    zapatoNuevo.ImagenID = null;
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
                if (ex.InnerException != null)
                {
                    respuesta.Mensaje += " Inner Exception: " + ex.InnerException.Message;
                }
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
                    zapatoBD.ColorID = zapatoDTO.ColorID;
                    zapatoBD.MaterialID = zapatoDTO.MaterialID;
                    zapatoBD.UsuarioID = zapatoDTO.UsuarioID;
                    zapatoBD.RubroID = zapatoDTO.RubroID;
                    zapatoBD.Precio = zapatoDTO.Precio;
                    zapatoBD.Nombre = zapatoDTO.Nombre;

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
