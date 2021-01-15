using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class DonorService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public DonorService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all Donors
        /// </summary>
        /// <returns>List of all Donor</returns>
        public List<Donor> GetDonors()
        {
            return db.Donor.ToList();
        }

        /// <summary>
        /// Get a Donor
        /// </summary>
        /// <param name="id">Id of the Donor to return</param>
        /// <returns>A Donor with the provided id or null</returns>
        public Donor GetDonor(int id)
        {
            return db.Donor.SingleOrDefault(c => c.DonorId == id);
        }

        /// <summary>
        /// Add a new Donor
        /// </summary>
        /// <param name="donor">The Donor to add</param>
        /// <returns>True if Donor is added successfuly otherwise false</returns>
        public bool AddNewDonor(Donor donor)
        {
            if (donor != null)
            {
                db.Donor.Add(donor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Donor
        /// </summary>
        /// <param name="id">Id of the Donor to delete</param>
        /// <returns>True if Donor is deleted successfuly otherwise false</returns>
        public bool DeleteDonor(int id)
        {
            var donor = db.Donor.Find(id);

            try
            {
                if (donor != null)
                {
                    db.Donor.Remove(donor);
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
        /// Edit a Donor
        /// </summary>
        /// <param name="donor">Donor object</param>
        public void EditDonor(Donor donor)
        {
            db.Entry(donor).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}