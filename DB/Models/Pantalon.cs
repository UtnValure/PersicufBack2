using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Pantalon
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PantalonID { get; set; }

        [Required]
        public int PrendaID { get; set; }

        [ForeignKey("PrendaID")]
        public virtual Prenda Prenda { get; set; }


        [Required]
        public int LargoID { get; set; }

        [ForeignKey("LargoID")]
        public virtual Largo Largo { get; set; }

        [Required]
        public int TAID { get; set; }

        [ForeignKey("TAID")]
        public virtual TalleAlfabetico TalleAlfabetico { get; set; }

    }
}
