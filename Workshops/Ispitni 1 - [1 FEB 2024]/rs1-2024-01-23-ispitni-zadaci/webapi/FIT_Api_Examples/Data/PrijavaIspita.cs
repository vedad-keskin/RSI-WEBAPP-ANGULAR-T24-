using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Data
{
    public class PrijavaIspita
    {
        public int ID { get; set; }
        public DateTime DatumPrijave { get; set; }


        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public int StudentID { get; set; }


        [ForeignKey(nameof(IspitID))]
        public Ispit Ispit { get; set; }
        public int IspitID { get; set; }


    }
}
