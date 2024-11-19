using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Data
{
    [Table("Student")]
    public class Student : KorisnickiNalog
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string broj_indeksa { get; set; }
        [ForeignKey(nameof(opstina_rodjenja))]
        public int? opstina_rodjenja_id { get; set; }
        public Opstina opstina_rodjenja { get; set; }
        public DateTime created_time { get; set; }
        public DateTime datum_rodjenja { get; set; }

        public bool? Obrisan { get; set; }

    }
}
