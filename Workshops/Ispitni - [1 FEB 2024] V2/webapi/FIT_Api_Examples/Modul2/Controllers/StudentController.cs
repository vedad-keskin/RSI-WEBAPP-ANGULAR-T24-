using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

      

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => (x.isDeleted == false || x.isDeleted == null) && ( ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime)) )
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

        // dodaj i edit
        // 

        [HttpPost]
        [Route("/DodajStudent")]
        public ActionResult DodajStudent([FromBody] DodajStudentVM x)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            Student novi;

            if (x.id == 0)
            {
                novi = new Student();
                _dbContext.Student.Add(novi);
            }
            else
            {
                novi = _dbContext.Student.Find(x.id);
            }

            novi.ime = x.ime;
            novi.prezime = x.prezime;
            novi.opstina_rodjenja_id = x.opstina_rodjenja_id;
            novi.isDeleted = false;

            _dbContext.SaveChanges();


            return Ok();
        }


        // obrisi
        [HttpPost]
        [Route("/ObrisiStudent")]
        public ActionResult ObrisiStudent([FromBody] int studentid)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");


            var student = _dbContext.Student.Find(studentid);

            student.isDeleted = true;

            //_dbContext.Student.Remove(student);

            _dbContext.SaveChanges();


            return Ok();
        }


        // get student

        [HttpGet]
        [Route("/GetStudent")]
        public ActionResult<Student> GetStudent([FromQuery] int studentid)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            var student = _dbContext.Student.Find(studentid);



            return Ok(student);
        }


    }


}
