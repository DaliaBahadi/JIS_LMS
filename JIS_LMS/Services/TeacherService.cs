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

        /// <summary>
        /// Get all teachers
        /// </summary>
        /// <returns>List of all teacher</returns>
        public List<Teacher> GetTeachers()
        {
            return db.Teacher.ToList();
        }

        /// <summary>
        /// Get a teacher
        /// </summary>
        /// <param name="id">Id of the teacher to return</param>
        /// <returns>A teacher with the provided id or null</returns>
        public Teacher GetTeacher(int id)
        {
            return db.Teacher.SingleOrDefault(c => c.PatronId == id);
        }

        /// <summary>
        /// Add a new teacher
        /// </summary>
        /// <param name="teacher">The teacher to add</param>
        /// <returns>True if teacher is added successfuly otherwise false</returns>
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

        /// <summary>
        /// Delete a teacher
        /// </summary>
        /// <param name="id">Id of the teacher to delete</param>
        /// <returns>True if teacher is deleted successfuly otherwise false</returns>
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

        /// <summary>
        /// Edit a teacher
        /// </summary>
        /// <param name="teacher">teacher object</param>
        public void EditTeacher(Teacher teacher)
        {
            db.Entry(teacher).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}