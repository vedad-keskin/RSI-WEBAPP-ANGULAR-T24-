using System;
using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Data
{
    public class AkademskaGodina
    {
        [Key]
        public int id { get; set; }
        public string opis { get; set; }
        public KorisnickiNalog evidentiraoKorisnik { get; internal set; }
        public DateTime? datum_update { get; set; }
        public KorisnickiNalog izmijenioKorisnik { get; set; }
        public DateTime datum_added { get; set; }
    }
}
