using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Campera
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CamperaID { get; set; }

        [Required]
        public int PrendaID { get; set; }

        [ForeignKey("PrendaID")]
        public virtual Prenda Prenda { get; set; }

        [Required]
        public int TAID { get; set; }

        [ForeignKey("TAID")]
        public virtual TalleAlfabetico TalleAlfabetico { get; set; }

    }
}
