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
    public class RemeraServicio : IRemeraServicio
    {
        private readonly PersicufContext _context;
        public RemeraServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Remera>> DeleteRemera(int ID)
        {

            var respuesta = new Confirmacion<Remera>();
            respuesta.Datos = null;

            try
            {
                var remeraDB = await _context.Remeras.FindAsync(ID);
                if (remeraDB != null)
                {
                    _context.Remeras.Remove(remeraDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = remeraDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La remera con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro la remera con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


        public async Task<Confirmacion<ICollection<RemeraDTOconID>>> GetRemera()
        {
            var respuesta = new Confirmacion<ICollection<RemeraDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var remeraDB = await _context.Remeras.ToListAsync();
                if (remeraDB.Count() != 0)
                {
                    respuesta.Datos = new List<RemeraDTOconID>();
                    foreach (var Remera in remeraDB)
                    {
                        respuesta.Datos.Add(new RemeraDTOconID()
                        {
                            ID = Remera.RemeraID,
                            CorteCuelloID = Remera.CorteCuello.CCID,
                            TalleAlfabeticoID = Remera.TAID,
                            MangaID = Remera.MangaID,
                            Precio = Remera.Prenda.Precio,
                            ColorID = Remera.Prenda.ColorID,
                            MaterialID = Remera.Prenda.MaterialID,
                            UsuarioID = Remera.Prenda.UsuarioID,
                            RubroID = Remera.Prenda.RubroID,
                            ImagenID = Remera.Prenda.ImagenID,
                            Nombre = Remera.Prenda.Nombre,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todas las Remeras";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen Remeras";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }
        public async Task<Confirmacion<RemeraDTO>> PostRemera(RemeraDTO remeraDTO)
        {
            var respuesta = new Confirmacion<RemeraDTO>();
            respuesta.Datos = null;

            try
            {
                var remeraDB = await _context.Remeras.AsNoTracking().FirstOrDefaultAsync(x => x.Prenda.Nombre == remeraDTO.Nombre);
                if (remeraDB == null)
                {
                    var remeraNuevo = remeraDTO.Adapt<Remera>();
                    await _context.Remeras.AddAsync(remeraNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El remera se creó correctamente.";
                    respuesta.Datos = remeraDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "La remera con nombre: " + remeraDTO.Nombre + " ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<RemeraDTO>> PutRemera(int ID, RemeraDTO remeraDTO)
        {
            var respuesta = new Confirmacion<RemeraDTO>();
            respuesta.Datos = null;

            try
            {
                var remeraBD = await _context.Remeras.FindAsync(ID);
                if (remeraBD != null)
                {
                    remeraBD.CorteCuello.CCID = remeraDTO.CorteCuelloID;
                    remeraBD.TAID = remeraDTO.TalleAlfabeticoID;
                    remeraBD.Manga.MangaID = remeraDTO.MangaID;
                    remeraBD.Prenda.ColorID = remeraDTO.ColorID;
                    remeraBD.Prenda.MaterialID = remeraDTO.MaterialID;
                    remeraBD.Prenda.UsuarioID = remeraDTO.UsuarioID;
                    remeraBD.Prenda.ImagenID = remeraDTO.ImagenID;
                    remeraBD.Prenda.RubroID = remeraDTO.RubroID;
                    remeraBD.Prenda.Precio = remeraDTO.Precio;
                    remeraBD.Prenda.Nombre = remeraDTO.Nombre;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = remeraBD.Adapt<RemeraDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El remera fué modificada correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El remera no existe.";
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
