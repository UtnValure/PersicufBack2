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
    public class PantalonServicio : IPantalonServicio
    {
        private readonly PersicufContext _context;
        public PantalonServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Pantalon>> DeletePantalon(int ID)
        {

            var respuesta = new Confirmacion<Pantalon>();
            respuesta.Datos = null;

            try
            {
                var pantalonDB = await _context.Pantalones.FindAsync(ID);
                if (pantalonDB != null)
                {
                    _context.Pantalones.Remove(pantalonDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = pantalonDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El pantalon con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro el pantalon con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


        public async Task<Confirmacion<ICollection<PantalonDTOconID>>> GetPantalon()
        {
            var respuesta = new Confirmacion<ICollection<PantalonDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var pantalonDB = await _context.Pantalones.ToListAsync();
                if (pantalonDB.Count() != 0)
                {
                    respuesta.Datos = new List<PantalonDTOconID>();
                    foreach (var Pantalon in pantalonDB)
                    {
                        respuesta.Datos.Add(new PantalonDTOconID()
                        {
                            ID = Pantalon.PrendaID,
                            LargoID = Pantalon.LargoID,
                            TalleAlfabeticoID = Pantalon.TAID,
                            Precio = Pantalon.Precio,
                            ColorID = Pantalon.ColorID,
                            MaterialID = Pantalon.MaterialID,
                            UsuarioID = Pantalon.UsuarioID,
                            RubroID = Pantalon.RubroID,
                            ImagenID = Pantalon.ImagenID,
                            Nombre = Pantalon.Nombre,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos los Pantalones";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen Pantalones";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }
        public async Task<Confirmacion<PantalonDTO>> PostPantalon(PantalonDTO pantalonDTO)
        {
            var respuesta = new Confirmacion<PantalonDTO>();
            respuesta.Datos = null;

            try
            {
                var pantalonDB = await _context.Pantalones.AsNoTracking().FirstOrDefaultAsync(x => x.Nombre == pantalonDTO.Nombre);
                if (pantalonDB == null)
                {
                    var pantalonNuevo = pantalonDTO.Adapt<Pantalon>();
                    pantalonNuevo.TAID = pantalonDTO.TalleAlfabeticoID;
                    await _context.Pantalones.AddAsync(pantalonNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El pantalon se creó correctamente.";
                    respuesta.Datos = pantalonDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "El pantalon con nombre: " + pantalonDTO.Nombre + " ya existe.";
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

        public async Task<Confirmacion<PantalonDTO>> PutPantalon(int ID, PantalonDTO pantalonDTO)
        {
            var respuesta = new Confirmacion<PantalonDTO>();
            respuesta.Datos = null;

            try
            {
                var pantalonBD = await _context.Pantalones.FindAsync(ID);
                if (pantalonBD != null)
                {
                    pantalonBD.TAID = pantalonDTO.TalleAlfabeticoID;
                    pantalonBD.Largo.LargoID = pantalonDTO.LargoID;
                    pantalonBD.ColorID = pantalonDTO.ColorID;
                    pantalonBD.MaterialID = pantalonDTO.MaterialID;
                    pantalonBD.UsuarioID = pantalonDTO.UsuarioID;
                    pantalonBD.ImagenID = pantalonDTO.ImagenID;
                    pantalonBD.RubroID = pantalonDTO.RubroID;
                    pantalonBD.Precio = pantalonDTO.Precio;
                    pantalonBD.Nombre = pantalonDTO.Nombre;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = pantalonBD.Adapt<PantalonDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El pantalon fué modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El pantalon no existe.";
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