using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Data
{
    [Table("Nastavnik")]
    public class Nastavnik : KorisnickiNalog
    {
        public string ime { get; set; }
        public string prezime { get; set; }

    }
}
