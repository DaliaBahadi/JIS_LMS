using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class TeacherService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public TeacherService(LMSDbContext context)
        {
            db = context;
        }

        public List<Teacher> GetTeachers()
        {
            return db.Teacher.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return db.Teacher.SingleOrDefault(c => c.EmployeeId == id);
        }

        public bool AddNewTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                db.Teacher.Add(teacher);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = db.Teacher.Find(id);
            if (teacher != null)
            {
                db.Teacher.Remove(teacher);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditTeacher(Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}