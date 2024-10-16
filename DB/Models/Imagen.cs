using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Imagen
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagenID { get; set; }

        [Required]
        public string ImgPath { get; set; } = string.Empty;
    }
}
