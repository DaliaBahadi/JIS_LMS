using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class PatronService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public PatronService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all patrons
        /// </summary>
        /// <returns>List of all patrons</returns>
        public List<Patron> GetPatrons()
        {
            
            return db.Patron.Include("Student").Include("Teacher").ToList();
        }

        /// <summary>
        /// Get a Patron
        /// </summary>
        /// <param name="id">Id of the patron to return</param>
        /// <returns>A patron with the provided id or null</returns>
        public Patron GetPatron(int id)
        {
            return db.Patron.Include(c => c.Student).Include(c => c.Teacher).SingleOrDefault(c => c.PatronId == id);
        }

        /// <summary>
        /// Add a new patron
        /// </summary>
        /// <param name="patron">The patron to add</param>
        /// <returns>True if patron is added successfuly otherwise false</returns>
        public bool AddNewPatron(Patron patron)
        {
            if (patron != null)
            {
                db.Patron.Add(patron);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a patron
        /// </summary>
        /// <param name="id">Id of the patron to delete</param>
        /// <returns>True if patront is deleted successfuly otherwise false</returns>
        public bool DeletePatron(int id)
        {
            var patron = db.Patron.Find(id);

            try
            {
                if (patron != null)
                {
                    db.Patron.Remove(patron);
                    db.SaveChanges();
                    return true;
                }

            }


            catch (DbUpdateException ex)
            {
            }
            
            return false;
        }

        /// <summary>
        /// Edit a patron
        /// </summary>
        /// <param name="patron">patron object</param>
        public void EditPatron(Patron patron)
        {
            // Change the state of the patron object to modified, so it will be update in database
            db.Entry(patron).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}