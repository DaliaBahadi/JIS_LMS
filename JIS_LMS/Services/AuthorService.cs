using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;
using Microsoft.Extensions.Logging;

namespace JIS_LMS.Services
{
    public class AuthorService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        //ILogger<String> Logger = new ILogger<String>() ;

        // Constructor using dependency injection
        public AuthorService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Authors
        /// </summary>
        /// <returns>List of all Author</returns>
        public List<Author> GetAuthors()
        {
            return db.Author.ToList();
        }

        /// <summary>
        /// Get a Author
        /// </summary>
        /// <param name="id">Id of the Author to return</param>
        /// <returns>A Author with the provided id or null</returns>
        public Author GetAuthor(int id)
        {
            return db.Author.SingleOrDefault(c => c.AuthorId == id);
        }

        /// <summary>
        /// Add a new Author
        /// </summary>
        /// <param name="author">The Author to add</param>
        /// <returns>True if Author is added successfuly otherwise false</returns>
        public bool AddNewAuthor(Author author)
        {
            if (author != null)
            {
                db.Author.Add(author);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Author
        /// </summary>
        /// <param name="id">Id of the Author to delete</param>
        /// <returns>True if Author is deleted successfuly otherwise false</returns>
        public bool DeleteAuthor(int id)
        {
            var author = db.Author.Find(id);

            try
            {
                if (author != null)
                {

                    db.Author.Remove(author);
                    db.SaveChanges();
                    return true;

                }

            }


            catch(DbUpdateException ex)
            {
                //Logger.LogWarning(ex, "Author is connected" );
            }

            return false;
        }

        /// <summary>
        /// Edit a Author
        /// </summary>
        /// <param name="author">Author object</param>
        public void EditAuthor(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}