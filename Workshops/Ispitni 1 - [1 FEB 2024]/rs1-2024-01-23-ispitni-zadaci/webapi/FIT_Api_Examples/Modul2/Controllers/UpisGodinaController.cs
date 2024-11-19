using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FIT_Api_Examples.Modul2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpisGodinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UpisGodinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // get upisi studenta
        // dodaj upis
        // ovjeri upis

        [HttpGet]
        [Route("/GetUpisi")]
        public ActionResult<List<UpisGodina>> GetUpisi([FromQuery] int studentid)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var upisi = _dbContext.UpisGodina.Include("student").Include("akademskaGodina").Include("evidentirao").Where(x => x.studentid == studentid).ToList();


            return Ok(upisi);
        }


        [HttpPost]
        [Route("/DodajUpis")]
        public ActionResult DodajUpis([FromBody] DodajUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            if (_dbContext.UpisGodina.ToList().Exists(u => u.studentid == x.studentid && u.godinaStudija == x.godinaStudija))
            {
                if (x.obnova)
                {
                    var noviUpis = new UpisGodina()
                    {
                        datumUpis = x.datumUpis,
                        studentid = x.studentid,
                        akademskaGodinaid = x.akademskaGodinaid,
                        evidentiraoid = x.evidentiraoid,
                        cijenaSkolarine = x.cijenaSkolarine,
                        obnova = x.obnova,
                        godinaStudija = x.godinaStudija
                    };

                    _dbContext.UpisGodina.Add(noviUpis);
                    _dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }


            }
            else
            {
                var noviUpis = new UpisGodina()
                {
                    datumUpis = x.datumUpis,
                    studentid = x.studentid,
                    akademskaGodinaid = x.akademskaGodinaid,
                    evidentiraoid = x.evidentiraoid,
                    cijenaSkolarine = x.cijenaSkolarine,
                    obnova = x.obnova,
                    godinaStudija = x.godinaStudija
                };

                _dbContext.UpisGodina.Add(noviUpis);
                _dbContext.SaveChanges();

                return Ok();
            }

        }


        [HttpPost]
        [Route("/OvjeriUpis")]
        public ActionResult OvjeriUpis([FromBody] OvjeraUpisVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var postojeciUpis = _dbContext.UpisGodina.Find(x.id);


            postojeciUpis.datumOvjera = x.datumOvjera;
            postojeciUpis.napomena = x.napomena;

            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
