﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class RegisterUsuarioDTO
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
