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

        public List<Publisher> GetPublishers()
        {
            return db.Publisher.ToList();
        }

        public Publisher GetPublisher(int id)
        {
            return db.Publisher.SingleOrDefault(c => c.PublisherId == id);
        }

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

        public bool DeletePublisher(int id)
        {
            var publisher = db.Publisher.Find(id);
            if (publisher != null)
            {
                db.Publisher.Remove(publisher);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditPublisher(Publisher publisher)
        {
            db.Entry(publisher).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}