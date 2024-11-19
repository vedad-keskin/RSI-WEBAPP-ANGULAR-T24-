using FIT_Api_Examples.Migrations;
using Microsoft.AspNetCore.Routing.Patterns;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Data
{
    public class UpisGodina
    {
        //- godina studija: int
        //- datum upisa u zimski semestar: DateTime
        //- datum ovjere: DateTime
        //- napomena za ovjeru: text
        //- obnova: bool
        //- cijena školarine: float

        //- akademska godina: FK na tabelu AkademskaGodina(prikazati unutar
        //combobox-a)


        public int id { get; set; }
        public int godinaStudija { get; set; }
        public DateTime datumUpis { get; set; }
        public DateTime? datumOvjera { get; set; }
        public string? napomena { get; set; }
        public float cijenaSkolarine { get; set; }
        public bool obnova { get; set; }


        // fk 
        // student, akademska, evidentirao

        [ForeignKey(nameof(studentid))]
        public int studentid { get; set; }
        public Student student { get; set; }


        [ForeignKey(nameof(akademskaGodinaid))]
        public int akademskaGodinaid { get; set; }
        public AkademskaGodina akademskaGodina { get; set; }



        [ForeignKey(nameof(evidentiraoid))]
        public int evidentiraoid { get; set; }
        public KorisnickiNalog evidentirao { get; set; }
    }
}
