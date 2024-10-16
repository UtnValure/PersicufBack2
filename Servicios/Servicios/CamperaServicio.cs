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
    public class CamperaServicio : ICamperaServicio
    {
        private readonly PersicufContext _context;
        public CamperaServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Campera>> DeleteCampera(int ID)
        {

            var respuesta = new Confirmacion<Campera>();
            respuesta.Datos = null;

            try
            {
                var camperaDB = await _context.Camperas.FindAsync(ID);
                if (camperaDB != null)
                {
                    _context.Camperas.Remove(camperaDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = camperaDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La campera con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro la campera con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


        public async Task<Confirmacion<ICollection<CamperaDTOconID>>> GetCampera()
        {
            var respuesta = new Confirmacion<ICollection<CamperaDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var camperaDB = await _context.Camperas.ToListAsync();
                if (camperaDB.Count() != 0)
                {
                    respuesta.Datos = new List<CamperaDTOconID>();
                    foreach (var Campera in camperaDB)
                    {
                        respuesta.Datos.Add(new CamperaDTOconID()
                        {
                            ID = Campera.CamperaID,
                            TalleAlfabeticoID = Campera.TAID,
                            Precio = Campera.Prenda.Precio,
                            ColorID = Campera.Prenda.ColorID,
                            MaterialID = Campera.Prenda.MaterialID,
                            UsuarioID = Campera.Prenda.UsuarioID,
                            RubroID = Campera.Prenda.RubroID,
                            ImagenID = Campera.Prenda.ImagenID,
                            Nombre = Campera.Prenda.Nombre,
                            PrendaID = Campera.PrendaID,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos las Camperas";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen Camperas";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }
        public async Task<Confirmacion<CamperaDTO>> PostCampera(CamperaDTO camperaDTO)
        {
            var respuesta = new Confirmacion<CamperaDTO>();
            respuesta.Datos = null;

            try
            {
                var camperaDB = await _context.Camperas.AsNoTracking().FirstOrDefaultAsync(x => x.Prenda.Nombre == camperaDTO.Nombre);
                if (camperaDB == null)
                {
                    var camperaNuevo = camperaDTO.Adapt<Campera>();
                    await _context.Camperas.AddAsync(camperaNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El campera se creó correctamente.";
                    respuesta.Datos = camperaDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "La campera con nombre: " + camperaDTO.Nombre + " ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                if (ex.InnerException != null)
                {
                    respuesta.Mensaje += "/n Inner Exception: " + ex.InnerException.Message;
                }
                return (respuesta);
            }
        }
        public async Task<Confirmacion<CamperaDTO>> PutCampera(int ID, CamperaDTO camperaDTO)
        {
            var respuesta = new Confirmacion<CamperaDTO>();
            respuesta.Datos = null;

            try
            {
                var camperaBD = await _context.Camperas.FindAsync(ID);
                if (camperaBD != null)
                {
                    camperaBD.TAID = camperaDTO.TalleAlfabeticoID;
                    camperaBD.Prenda.ColorID = camperaDTO.ColorID;
                    camperaBD.Prenda.MaterialID = camperaDTO.MaterialID;
                    camperaBD.Prenda.UsuarioID = camperaDTO.UsuarioID;
                    camperaBD.Prenda.ImagenID = camperaDTO.ImagenID;
                    camperaBD.Prenda.RubroID = camperaDTO.RubroID;
                    camperaBD.Prenda.Precio = camperaDTO.Precio;
                    camperaBD.Prenda.Nombre = camperaDTO.Nombre;
                    camperaBD.PrendaID = camperaDTO.PrendaID;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = camperaBD.Adapt<CamperaDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El campera fué modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El campera no existe.";
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