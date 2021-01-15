using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class Library_MaterialService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public Library_MaterialService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Library Materials
        /// </summary>
        /// <returns>List of all Library Materials</returns>
        public List<Library_Material> GetLibraryMaterials()

        {

            return db.Library_Material.Include("Book").Include("Journal").Include("CD_DVD_BR").Include("Publisher").Include("Library").Include("Donor").Include("LibraryMaterial_Authors").ToList();
        }

        /// <summary>
        /// Get a Library Material
        /// </summary>
        /// <param name="id">Id of the Library Material to return</param>
        /// <returns>A Library Material with the provided id or null</returns>
        public Library_Material GetLibraryMaterial(int id)
        {
            return db.Library_Material.SingleOrDefault(c => c.LibraryMaterialId == id);
        }

        /// <summary>
        /// Add a new Library_Material
        /// </summary>
        /// <param name="library_Material">The Library Material to add</param>
        /// <returns>True if Library Material is added successfuly otherwise false</returns>
        public bool AddNewLibraryMaterial(Library_Material library_Material)
        {
            if (library_Material != null)
            {
                db.Library_Material.Add(library_Material);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Library Material
        /// </summary>
        /// <param name="id">Id of the Library Material to delete</param>
        /// <returns>True if Library Material is deleted successfuly otherwise false</returns>
        public bool DeleteLibraryMaterial(int id)
        {
            var library_Material = db.Library_Material.Find(id);

            //Delete library material authors from LibraryMaterial_Author table
            List<LibraryMaterial_Author> authors = db.LibraryMaterial_Author.Where(x => x.LibraryMaterialId == id).ToList();

            try
            {
                foreach (var x in authors)
                {
                    db.LibraryMaterial_Author.Remove(x);
                    db.SaveChanges();
                }

                if (library_Material != null)
                {
                    db.Library_Material.Remove(library_Material);
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
        /// Edit a Library Material
        /// </summary>
        /// <param name="library_Material">Library Material object</param>
        public void EditLibraryMaterial(Library_Material library_Material)
        {
            db.Entry(library_Material).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}