using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class LibraryService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public LibraryService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all libraries
        /// </summary>
        /// <returns>List of all library</returns>
        public List<Library> GetLibraries()
        {
            return db.Library.Include("Address").ToList();
        }

        /// <summary>
        /// Get a library
        /// </summary>
        /// <param name="id">Id of the library to return</param>
        /// <returns>A library with the provided id or null</returns>
        public Library GetLibrary(int id)
        {
            return db.Library.SingleOrDefault(c => c.LibraryId == id);
        }

        /// <summary>
        /// Add a new library
        /// </summary>
        /// <param name="library">The library to add</param>
        /// <returns>True if library is added successfuly otherwise false</returns>
        public bool AddNewLibrary(Library library)
        {
            if (library != null)
            {
                db.Library.Add(library) ;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a library
        /// </summary>
        /// <param name="id">Id of the library to delete</param>
        /// <returns>True if library is deleted successfuly otherwise false</returns>
        public bool DeleteLibrary(int id)
        {
            var library = db.Library.Find(id);
            if (library != null)
            {
                db.Library.Remove(library);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a library
        /// </summary>
        /// <param name="library">library object</param>
        public void EditLibrary(Library library)
        {
            db.Entry(library).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}