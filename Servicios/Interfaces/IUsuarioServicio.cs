﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.DTOs;
using DB.Models;

namespace Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<Confirmacion<ICollection<UsuarioDTOconID>>> GetUsuario();
        Task<Confirmacion<UsuarioDTO>> PostUsuario(UsuarioDTO UsuarioDTO);
        Task<Confirmacion<Usuario>> DeleteUsuario(int ID);
        Task<Confirmacion<UsuarioDTO>> PutUsuario(int ID, UsuarioDTO UsuarioDTO);
        Task<Confirmacion<UsuarioDTOconID>> PatchUsuarioPermiso(int ID, int PermisoID );
    }
}
