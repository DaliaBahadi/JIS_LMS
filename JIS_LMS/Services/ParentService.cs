using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class ParentService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public ParentService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all parents
        /// </summary>
        /// <returns>List of all parent</returns>
        public List<Parent> GetParents()

        {

            return db.Parent.ToList();
        }

        /// <summary>
        /// Get a parent
        /// </summary>
        /// <param name="id">Id of the parent to return</param>
        /// <returns>A parent with the provided id or null</returns>
        public Parent GetParent(int id)
        {
            return db.Parent.SingleOrDefault(c => c.ParentId == id);
        }

        /// <summary>
        /// Add a new parent
        /// </summary>
        /// <param name="parent">The parent to add</param>
        /// <returns>True if parent is added successfuly otherwise false</returns>
        public bool AddNewParent(Parent parent)
        {
            if (parent != null)
            {
                db.Parent.Add(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a parent
        /// </summary>
        /// <param name="id">Id of the parent to delete</param>
        /// <returns>True if parent is deleted successfuly otherwise false</returns>
        public bool DeleteParent(int id)
        {
            var parent = db.Parent.Find(id);

            //Delete parent patrons from Student_Parent table
            List<Student_Parent> patrons = db.Student_Parent.Where(x => x.ParentId == id).ToList();

            foreach (var x in patrons)
            {
                db.Student_Parent.Remove(x);
                db.SaveChanges();
            }

            if (parent != null)
            {
                db.Parent.Remove(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a parent
        /// </summary>
        /// <param name="parent">parent object</param>
        public void EditParent(Parent parent)
        {
            db.Entry(parent).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}