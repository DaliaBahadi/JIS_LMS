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

        /// <summary>
        /// Get a addresses
        /// </summary>
        /// <param name="id">Id of the address to return</param>
        /// <returns>A addresses with the provided id or null</returns>
        public List<Address> GetAddresses()
        {
            return db.Address.ToList();
        }

        /// <summary>
        /// Get a address
        /// </summary>
        /// <param name="id">Id of the address to return</param>
        /// <returns>A address with the provided id or null</returns>
        public Address GetAddress(int id)
        {
            return db.Address.SingleOrDefault(c => c.AddressId == id);
        }

        /// <summary>
        /// Add a new address
        /// </summary>
        /// <param name="address">The address to add</param>
        /// <returns>True if address is added successfuly otherwise false</returns>
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

        /// <summary>
        /// Delete a address
        /// </summary>
        /// <param name="id">Id of the address to delete</param>
        /// <returns>True if address is deleted successfuly otherwise false</returns>
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

        /// <summary>
        /// Edit a address
        /// </summary>
        /// <param name="address">address object</param>
        public void EditAddress(Address address)
        {
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}