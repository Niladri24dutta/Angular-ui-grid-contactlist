using SPA_MVC_StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPA_MVC_StudentApp
{
    public class StudentRepository : IRepository<student>,IDisposable
    {
        private StudentManageEntities _studentEntities;

        public StudentRepository()
        {
            _studentEntities = new StudentManageEntities();
        }
        public IEnumerable<student> Search(string query)
        {
            return string.IsNullOrEmpty(query) ? _studentEntities.students.ToList() : _studentEntities.students.Where(p => p.Name.Contains(query)).ToList();
        }

        public void Add(student entity)
        {
            try
            {
                _studentEntities.students.Add(entity);
                _studentEntities.SaveChanges();
            }
            catch(Exception err)
            {
                throw err;
            }
            
            
        }

        public void Update(student entity)
        {
            try
            {
                _studentEntities.Entry(entity).State = EntityState.Modified;
                _studentEntities.SaveChanges();
            }
            catch (Exception err)
            {
                throw err;
            }
            

        }

        public void Delete(student entity)
        {
            try
            {
                student std = _studentEntities.students.Find(entity.StudentId);
                _studentEntities.students.Remove(std);
                _studentEntities.SaveChanges();
            }

            catch (Exception err)
            {
                throw err;
            }

        }

        public student SeachById(int id)
        {
            return id == 0 ? _studentEntities.students.FirstOrDefault() : _studentEntities.students.Where(x => x.StudentId == id).FirstOrDefault();
        }

        public IEnumerable<student> ShowAll()
        {
            return _studentEntities.students.AsEnumerable();
        }

        public int GetStudentCount(int id)
        {
            return _studentEntities.students.Where(x => x.StudentId == id).Count();
        }

        private bool disposed = false;



        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {

                if (disposing)
                {

                    _studentEntities.Dispose();

                }

            }

            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}