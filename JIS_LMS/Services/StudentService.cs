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


        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns>List of all student</returns>
        public List<Student> GetStudents()
        {
            return db.Student.ToList();
        }

        /// <summary>
        /// Get a student
        /// </summary>
        /// <param name="id">Id of the student to return</param>
        /// <returns>A student with the provided id or null</returns>
        public Student GetStudent(int id)
        {
            return db.Student.SingleOrDefault(c => c.PatronId == id);
        }

        /// <summary>
        /// Add a new student
        /// </summary>
        /// <param name="student">The student to add</param>
        /// <returns>True if student is added successfuly otherwise false</returns>
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


        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="id">Id of the student to delete</param>
        /// <returns>True if student is deleted successfuly otherwise false</returns>
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

        /// <summary>
        /// Edit a student
        /// </summary>
        /// <param name="student">student object</param>
        public void EditStudent(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}