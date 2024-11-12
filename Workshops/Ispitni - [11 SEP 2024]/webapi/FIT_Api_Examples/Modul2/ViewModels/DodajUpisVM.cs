using FIT_Api_Examples.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class DodajUpisVM
    {

        public DateTime datumUpis { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }
        public int? studentid { get; set; }
        public int? akademskaGodinaid { get; set; }
        public int? evidentiraoid { get; set; }


    }
}
