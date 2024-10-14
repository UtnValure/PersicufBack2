using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Remera
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RemeraID { get; set; }

        [Required]
        public int PrendaID { get; set; }

        [ForeignKey("PrendaID")]
        public virtual Prenda Prenda { get; set; }

        [Required]
        public int MangaID { get; set; }

        [ForeignKey("MangaID")]
        public virtual Manga Manga { get; set; }

        [Required]
        public int CCID { get; set; }

        [ForeignKey("CCID")]
        public virtual CorteCuello CorteCuello { get; set; }

        [Required]
        public int TAID { get; set; }

        [ForeignKey("TAID")]
        public virtual TalleAlfabetico TalleAlfabetico { get; set; }

    }
}
