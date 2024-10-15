using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CORE.DTOs
{
    public class PrendaEstampadoDTO
    {
        public int PrendaID { get; set; }
        public int ImagenID { get; set; }
        public int UbicacionID { get; set; }
    }

    public class PrendaEstampadoDTOconID : PrendaEstampadoDTO 
    { 
        public int ID { get; set; }
    }
}
