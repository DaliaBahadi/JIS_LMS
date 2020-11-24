using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class BookService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public BookService(LMSDbContext context)
        {
            db = context;
        }


        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>List of all Book</returns>
        public List<Book> GetBooks()
        {
            return db.Book.ToList();
        }

        /// <summary>
        /// Get a Book
        /// </summary>
        /// <param name="id">Id of the Book to return</param>
        /// <returns>A Book with the provided id or null</returns>
        public Book GetBook(int id)
        {
            return db.Book.SingleOrDefault(c => c.LibraryMaterialId == id);
        }

        /// <summary>
        /// Add a new Book
        /// </summary>
        /// <param name="book">The Book to add</param>
        /// <returns>True if Book is added successfuly otherwise false</returns>
        public bool AddNewBook(Book book)
        {
            if (book != null)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Delete a Book
        /// </summary>
        /// <param name="id">Id of the Book to delete</param>
        /// <returns>True if Book is deleted successfuly otherwise false</returns>
        public bool DeleteBook(int id)
        {
            var book = db.Book.Find(id);
            if (book != null)
            {
                db.Book.Remove(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a Book
        /// </summary>
        /// <param name="book">Book object</param>
        public void EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}