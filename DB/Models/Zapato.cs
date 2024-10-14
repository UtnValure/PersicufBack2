using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Zapato
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZapatoID { get; set; }

        [Required]
        public int PrendaID { get; set; }

        [ForeignKey("PrendaID")]
        public virtual Prenda Prenda { get; set; }

        [Required]
        public bool PuntaMetalica { get; set; }

        [Required]
        public int TNID { get; set; }

        [ForeignKey("TNID")]
        public virtual TalleNumerico TalleNumerico { get; set; }

    }
}
