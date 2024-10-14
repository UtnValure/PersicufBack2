using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class PrendaEstampado
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PEID { get; set; }

        [Required]
        public int PrendaID { get; set; }

        [ForeignKey("PrendaID")]
        public virtual Prenda Prenda { get; set; }

        [Required]
        public int ImagenID { get; set; }

        [ForeignKey("ImagenID")]
        public virtual Imagen Imagen { get; set; }

        [Required]
        public int UbicacionID { get; set; }

        [ForeignKey("UbicacionID")]
        public virtual Ubicacion Ubicacion { get; set; }
    }
}
