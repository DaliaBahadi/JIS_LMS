using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class StudentParentService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public StudentParentService(LMSDbContext context)
        {
            db = context;
        }



        /// <summary>
        /// Add content to stundent parent 
        /// </summary>
        /// <param name="studentParent">The student Parent to add</param>
        /// <returns>True if studentParent is added successfuly otherwise false</returns>
        public bool AddNewStudentParent(Student_Parent studentParent)
        {
            if (studentParent != null)
            {
                db.Student_Parent.Add(studentParent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        
    }
}