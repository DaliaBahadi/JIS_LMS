using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class PublisherService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public PublisherService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Publishers
        /// </summary>
        /// <returns>List of all Publisher</returns>
        public List<Publisher> GetPublishers()
        {
            return db.Publisher.ToList();
        }

        /// <summary>
        /// Get a Publisher
        /// </summary>
        /// <param name="id">Id of the Publisher to return</param>
        /// <returns>A Publisher with the provided id or null</returns>
        public Publisher GetPublisher(int id)
        {
            return db.Publisher.SingleOrDefault(c => c.PublisherId == id);
        }

        /// <summary>
        /// Add a new Publisher
        /// </summary>
        /// <param name="publisher">The Publisher to add</param>
        /// <returns>True if Publisher is added successfuly otherwise false</returns>
        public bool AddNewPublisher(Publisher publisher)
        {
            if (publisher != null)
            {
                db.Publisher.Add(publisher);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Publisher
        /// </summary>
        /// <param name="id">Id of the Publisher to delete</param>
        /// <returns>True if Publisher is deleted successfuly otherwise false</returns>
        public bool DeletePublisher(int id)
        {
            var publisher = db.Publisher.Find(id);

            try
            {
                if (publisher != null)
                {
                    db.Publisher.Remove(publisher);
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
        /// Edit a Publisher
        /// </summary>
        /// <param name="publisher">publisher object</param>
        public void EditPublisher(Publisher publisher)
        {
            db.Entry(publisher).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}