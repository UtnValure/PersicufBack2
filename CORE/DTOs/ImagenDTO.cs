using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CORE.DTOs
{
    public class ImagenDTO
    {
        public byte[] Imagen { get; set; }
    }

    public class ImagenDTOconID : ImagenDTO
    {
        public int ID { get; set; }
    }
}

