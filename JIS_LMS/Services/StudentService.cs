using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class StudentService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public StudentService(LMSDbContext context)
        {
            db = context;
        }

        public List<Student> GetStudents()
        {
            return db.Student.ToList();
        }

        public Student GetStudent(int id)
        {
            return db.Student.SingleOrDefault(c => c.StudentId == id);
        }

        public bool AddNewStudent(Student student)
        {
            if (student != null)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteStudent(int id)
        {
            var student = db.Student.Find(id);
            if (student != null)
            {
                db.Student.Remove(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditStudent(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}