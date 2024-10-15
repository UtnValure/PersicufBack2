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
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly PersicufContext _context;
        public UsuarioServicio(PersicufContext context)
        {
            _context = context;
        }
        public async Task<Confirmacion<Usuario>> DeleteUsuario(int ID)
        {

            var respuesta = new Confirmacion<Usuario>();
            respuesta.Datos = null;

            try
            {
                var usuarioDB = await _context.Usuarios.FindAsync(ID);
                if (usuarioDB != null)
                {
                    _context.Usuarios.Remove(usuarioDB);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = usuarioDB;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El usuario con ID: " + ID + "se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "No se encontro el usuario con ID:" + ID;
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error:" + ex.Message;
                return respuesta;
            }
        }


    

        public async Task<Confirmacion<ICollection<UsuarioDTOconID>>> GetUsuario()
        {
            var respuesta = new Confirmacion<ICollection<UsuarioDTOconID>>();
            respuesta.Datos = null;

            try
            {
                var usuariosDB = await _context.Usuarios.ToListAsync();
                if (usuariosDB.Count() != 0)
                {
                    respuesta.Datos = new List<UsuarioDTOconID>();
                    foreach (var usuario in usuariosDB)
                    {
                        respuesta.Datos.Add(new UsuarioDTOconID()
                        {
                            ID = usuario.UsuarioID,
                            NombreUsuario = usuario.NombreUsuario,
                            Contrasenia = usuario.Contrasenia,
                            PermisoID = usuario.PermisoID,
                            Correo = usuario.Correo,
                        });
                    }
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron todos los usuarios";
                    return respuesta;
                }

                respuesta.Mensaje = "No existen usuarios";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }


        public async Task<Confirmacion<UsuarioDTOconID>> PatchUsuarioPermiso(int ID, int PermID)
        {
            var respuesta = new Confirmacion<UsuarioDTOconID>();
            respuesta.Datos = null;

            try
            {
                var usuarioDB = await _context.Usuarios.FirstOrDefaultAsync(x => x.PermisoID == ID);
                if (usuarioDB != null)
                {
                    usuarioDB.PermisoID = PermID;
                    await _context.SaveChangesAsync();
                    respuesta.Datos = usuarioDB.Adapt<UsuarioDTOconID>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El permiso del usuario fue actualizado.";
                    return respuesta;
                }
                respuesta.Mensaje = "No se ha encontrado al usuario";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }



        public async Task<Confirmacion<UsuarioDTO>> PostUsuario(UsuarioDTO usuarioDTO)
        {
            var respuesta = new Confirmacion<UsuarioDTO>();
            respuesta.Datos = null;

            try
            {
                var usuarioDB = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.NombreUsuario == usuarioDTO.NombreUsuario);
                if (usuarioDB == null)
                {
                    var usuarioNuevo = usuarioDTO.Adapt<Usuario>(); 
                    await _context.Usuarios.AddAsync(usuarioNuevo);
                    await _context.SaveChangesAsync();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El usuario se creó correctamente.";
                    respuesta.Datos = usuarioDTO;
                    return (respuesta);
                }
                respuesta.Mensaje = "El usuario ya existe.";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error: " + ex.Message;
                return (respuesta);
            }
        }

        public async Task<Confirmacion<UsuarioDTO>> PutUsuario(int ID, UsuarioDTO usuarioDTO)
        {
            var respuesta = new Confirmacion<UsuarioDTO>();
            respuesta.Datos = null;

            try
            {
                var usuarioBD = await _context.Usuarios.FindAsync(ID);
                if (usuarioBD != null)
                {
                    usuarioBD.NombreUsuario = usuarioDTO.NombreUsuario;
                    usuarioBD.Contrasenia = usuarioDTO.Contrasenia;
                    usuarioBD.PermisoID = usuarioDTO.PermisoID;
                    usuarioBD.Correo = usuarioDTO.Correo;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = usuarioBD.Adapt<UsuarioDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El usuario fué modificado correctamente.";
                    return respuesta;
                }
                respuesta.Mensaje = "El usuario no existe.";
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
