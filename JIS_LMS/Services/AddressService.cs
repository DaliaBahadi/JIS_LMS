using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class AddressService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public AddressService(LMSDbContext context)
        {
            db = context;
        }

        public List<Address> GetAddresses()
        {
            return db.Address.ToList();
        }

        public Address GetAddress(int id)
        {
            return db.Address.SingleOrDefault(c => c.AddressId == id);
        }

        public bool AddNewAddress(Address address)
        {
            if (address != null)
            {
                db.Address.Add(address);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAddress(int id)
        {
            var address = db.Address.Find(id);
            if (address != null)
            {
                db.Address.Remove(address);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}