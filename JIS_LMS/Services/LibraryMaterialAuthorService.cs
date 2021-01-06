using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class LibraryMaterilaAuthorService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public LibraryMaterilaAuthorService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Library Materials authors
        /// </summary>
        /// <returns>List of all Library Materials authors</returns>
        public List<LibraryMaterial_Author> GetLibraryMaterialAuthors()

        {

            return db.LibraryMaterial_Author.Include("Author").Include("Library_Material").ToList();
        }
        /// <summary>
        /// Get a Library Material authors
        /// </summary>
        /// <param name="libraryMaterialId,authorId">Ids of the Library Material authors to return</param>
        /// <returns>A Library Material author with the provided id or null</returns>
        public LibraryMaterial_Author GetLibraryMaterialAuthor(int libraryMaterialId, int authorId)
        {
            return db.LibraryMaterial_Author.SingleOrDefault(c => c.LibraryMaterial.LibraryMaterialId == libraryMaterialId && c.AuthorId == authorId);
        }

        /// <summary>
        /// Add content to library material author 
        /// </summary>
        /// <param name="materialAuthor">The library material author to add</param>
        /// <returns>True if materialAuthor is added successfuly otherwise false</returns>
        public bool AddNewLibraryMaterialAuthor(LibraryMaterial_Author materialAuthor)
        {
            if (materialAuthor != null)
            {
                db.LibraryMaterial_Author.Add(materialAuthor);
                db.SaveChanges();
                return true;
            }
            return false;
        }



        //public Task<int> DeleteLibraryMaterialAuthor1(int libraryMaterialId, int authorId)
        //{
        //    var deleteLibraryMaterialAuthor = Task.FromResult(_dapperService
        //        Execute($"Delete [LibraryMaterial_Author] where LibraryMaterialId = {isbn} " +
        //        $"and AuthorId = {authorId}", null,
        //        commandType: CommandType.Text));
        //    return deleteBookAuthor;
        //}

        /// <summary>
        /// Delete a Library Material author
        /// </summary>
        /// <param name="libraryMaterialId, authorId">Id of the Library Material author to delete</param>
        /// <returns>True if Library Material author is deleted successfuly otherwise false</returns>
        public bool DeleteLibraryMaterialAuthor(int libraryMaterialId, int authorId)
        {
            var libraryMaterial_Author = db.LibraryMaterial_Author.Find(libraryMaterialId, authorId);
            if (libraryMaterial_Author != null)
            {
                db.LibraryMaterial_Author.Remove(libraryMaterial_Author);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}