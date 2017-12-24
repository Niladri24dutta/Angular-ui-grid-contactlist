using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SPA_MVC_StudentApp.Models;

namespace SPA_MVC_StudentApp.Controllers
{
    public class ManageStudentInfoController : ApiController
    {
       // private StudentManageEntities db = new StudentManageEntities();

        private StudentRepository _studentRepo = null;


        public ManageStudentInfoController()
        {
            _studentRepo = new StudentRepository();
        }

        public ManageStudentInfoController(StudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        // GET api/ManageStudentInfo
        public IEnumerable<student> Getstudents()
        {
            return _studentRepo.ShowAll();
        }

        // GET api/ManageStudentInfo/5
        [ResponseType(typeof(student))]
        public IHttpActionResult Getstudent(int id)
        {
            student student = _studentRepo.SeachById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT api/ManageStudentInfo/5
        public IHttpActionResult Putstudent(int id, student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

           // db.Entry(student).State = EntityState.Modified;

            try
            {
                _studentRepo.Update(student);
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ManageStudentInfo
        [ResponseType(typeof(student))]
        public IHttpActionResult Poststudent(student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _studentRepo.Add(student);

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE api/ManageStudentInfo/5
        [ResponseType(typeof(student))]
        public IHttpActionResult Deletestudent(int id)
        {
            student student = _studentRepo.SeachById(id);
            if (student == null)
            {
                return NotFound();
            }

            //db.students.Remove(student);
            //db.SaveChanges();
            _studentRepo.Delete(student);
            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _studentRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool studentExists(int id)
        {
            bool result = false;
            
            if (_studentRepo.GetStudentCount(id) > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}