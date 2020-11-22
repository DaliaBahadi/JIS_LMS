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

        public List<Library> GetLibraries()
        {
            return db.Library.Include("Address").ToList();
        }

        public Library GetLibrary(int id)
        {
            return db.Library.SingleOrDefault(c => c.LibraryId == id);
        }

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

        public void EditLibrary(Library library)
        {
            db.Entry(library).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}