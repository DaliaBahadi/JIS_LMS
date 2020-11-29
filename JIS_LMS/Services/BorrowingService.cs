using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class BorrowingService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public BorrowingService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get a borrowing
        /// </summary>
        /// <param name="id">Id of the borrowing to return</param>
        /// <returns>A borrowing with the provided id or null</returns>
        public List<Borrowing> GetBorrowings()
        {
            return db.Borrowing.ToList();
        }

        /// <summary>
        /// Get a borrowing
        /// </summary>
        /// <param name="id">Id of the borrowing to return</param>
        /// <returns>A borrowing with the provided id or null</returns>
        public Borrowing GetBorrowing(int id)
        {
            return db.Borrowing.Include(c => c.Patron).Include(c => c.LibraryMaterial).SingleOrDefault(c => c.BorrowingId == id);
        }

        /// <summary>
        /// Add a new borrowing
        /// </summary>
        /// <param name="borrowing">The borrowing to add</param>
        /// <returns>True if borrowing is added successfuly otherwise false</returns>
        public bool AddNewBorrowing(Borrowing borrowing)
        {
            if (borrowing != null)
            {
                db.Borrowing.Add(borrowing);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a borrowing
        /// </summary>
        /// <param name="id">Id of the borrowing to delete</param>
        /// <returns>True if borrowing is deleted successfuly otherwise false</returns>
        public bool DeleteBorrowing(int id)
        {
            var borrowing = db.Borrowing.Find(id);
            if (borrowing != null)
            {
                db.Borrowing.Remove(borrowing);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a borrowing
        /// </summary>
        /// <param name="borrowing">borrowing object</param>
        public void EditBorrowing(Borrowing borrowing)
        {
            db.Entry(borrowing).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}