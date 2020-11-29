using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class HoldService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public HoldService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get a hold
        /// </summary>
        /// <param name="id">Id of the hold to return</param>
        /// <returns>A hold with the provided id or null</returns>
        public List<Hold> GetHolds()
        {
            return db.Hold.ToList();
        }

        /// <summary>
        /// Get a hold
        /// </summary>
        /// <param name="id">Id of the hold to return</param>
        /// <returns>A hold with the provided id or null</returns>
        public Hold GetHold(int id)
        {
            return db.Hold.Include(c => c.Patron).Include(c => c.LibraryMaterial).SingleOrDefault(c => c.HoldId == id);
        }

        /// <summary>
        /// Add a new hold
        /// </summary>
        /// <param name="hold">The hold to add</param>
        /// <returns>True if hold is added successfuly otherwise false</returns>
        public bool AddNewHold(Hold hold)
        {
            if (hold != null)
            {
                db.Hold.Add(hold);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a hold
        /// </summary>
        /// <param name="id">Id of the hold to delete</param>
        /// <returns>True if hold is deleted successfuly otherwise false</returns>
        public bool DeleteHold(int id)
        {
            var hold = db.Hold.Find(id);
            if (hold != null)
            {
                db.Hold.Remove(hold);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a hold
        /// </summary>
        /// <param name="hold">hold object</param>
        public void EditHold(Hold hold)
        {
            db.Entry(hold).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}