using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class JournalService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public JournalService(LMSDbContext context)
        {
            db = context;
        }


        /// <summary>
        /// Get all Journals
        /// </summary>
        /// <returns>List of all Journals</returns>
        public List<Journal> GetJournals()
        {
            return db.Journal.ToList();
        }

        /// <summary>
        /// Get a Journal
        /// </summary>
        /// <param name="id">Id of the Journal to return</param>
        /// <returns>A Journal with the provided id or null</returns>
        public Journal GetJournal(int id)
        {
            return db.Journal.SingleOrDefault(c => c.LibraryMaterialId == id);
        }

        /// <summary>
        /// Add a new Journal
        /// </summary>
        /// <param name="journal">The Journal to add</param>
        /// <returns>True if Journal is added successfuly otherwise false</returns>
        public bool AddNewJournal(Journal journal)
        {
            if (journal != null)
            {
                db.Journal.Add(journal);
                db.SaveChanges();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Delete a Journal
        /// </summary>
        /// <param name="id">Id of the Journal to delete</param>
        /// <returns>True if Journal is deleted successfuly otherwise false</returns>
        public bool DeleteJournal(int id)
        {
            var journal = db.Journal.Find(id);
            if (journal != null)
            {
                db.Journal.Remove(journal);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a Journal
        /// </summary>
        /// <param name="journal">Journal object</param>
        public void EditJournal(Journal journal)
        {
            db.Entry(journal).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}