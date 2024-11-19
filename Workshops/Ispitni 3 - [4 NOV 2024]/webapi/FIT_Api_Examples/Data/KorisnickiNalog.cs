using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace FIT_Api_Examples.Data
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int id { get; set; }
        public string korisnickoIme { get; set; }
        [JsonIgnore]
        public string lozinka { get; set; }
        public string slika_korisnika { get; set; }

        [JsonIgnore]
        public Student student => this as Student;

        [JsonIgnore]
        public Nastavnik nastavnik => this as Nastavnik;
        public bool isNastavnik => nastavnik != null;
        public bool isStudent => student != null;
        public bool isAdmin { get; set; }
        public bool isProdekan { get; set; }
        public bool isDekan { get; set; }
        public bool isStudentskaSluzba { get; set; }



        [ForeignKey(nameof(DefaultOpstina))]
        public int? DefaultOpstinaId { get; set; }
        public Opstina DefaultOpstina { get; set; }


    }
}
