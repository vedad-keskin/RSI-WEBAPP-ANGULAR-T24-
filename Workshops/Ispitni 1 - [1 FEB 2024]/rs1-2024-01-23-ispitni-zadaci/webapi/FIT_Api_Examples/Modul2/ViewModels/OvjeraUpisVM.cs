using FIT_Api_Examples.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace FIT_Api_Examples.Modul2.ViewModels
{
    public class OvjeraUpisVM
    {
        public int id { get; set; }
        public DateTime? datumOvjera { get; set; }
        public string? napomena { get; set; }
 
    }
}
