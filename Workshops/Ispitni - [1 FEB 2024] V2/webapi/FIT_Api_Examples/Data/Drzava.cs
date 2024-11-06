using System.ComponentModel.DataAnnotations;

namespace FIT_Api_Examples.Data
{
    public class Drzava
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
