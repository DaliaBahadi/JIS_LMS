using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class ParentService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public ParentService(LMSDbContext context)
        {
            db = context;
        }

        public List<Parent> GetParents()

        {

            return db.Parent.ToList();
        }

        public Parent GetParent(int id)
        {
            return db.Parent.SingleOrDefault(c => c.ParentId == id);
        }

        public bool AddNewParent(Parent parent)
        {
            if (parent != null)
            {
                db.Parent.Add(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteParent(int id)
        {
            var parent = db.Parent.Find(id);
            if (parent != null)
            {
                db.Parent.Remove(parent);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditParent(Parent parent)
        {
            db.Entry(parent).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}