using FIT_Api_Examples.Migrations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FIT_Api_Examples.Data
{
    public class UpisGodina
    {
        //        datum upisa u zimski semestar: DateTime
        //- godina studija: int
        //- cijena školarine: float
        //- obnova: bool
        //- datum ovjere: DateTime
        //- napomena za ovjeru: text

        public int id { get; set; }
        public DateTime datumUpis { get; set; }
        public int godinaStudija { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }

        public DateTime? datumOvjera { get; set; }
        public string? napomena { get; set; }


        //- akademska godina: FK na tabelu AkademskaGodina(prikazati unutar
        //combobox-a)

        // FK -> student , akdg , korisnickiNalog

        [ForeignKey(nameof(student))]
        public int? studentid { get; set; }
        public Student student { get; set; }



        [ForeignKey(nameof(akademskaGodina))]
        public int? akademskaGodinaid { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }



        [ForeignKey(nameof(evidentirao))]
        public int? evidentiraoid { get; set; }
        public KorisnickiNalog evidentirao { get; set; }



    }
}
