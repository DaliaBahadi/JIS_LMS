using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class CD_DVD_BR_Service
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public CD_DVD_BR_Service(LMSDbContext context)
        {
            db = context;
        }


        /// <summary>
        /// Get all CDs_DVDs_BRs
        /// </summary>
        /// <returns>List of all CDs_DVDs_BRs</returns>
        public List<CD_DVD_BR> GetCDs_DVDs_BRs()
        {
            return db.CD_DVD_BR.ToList();
        }

        /// <summary>
        /// Get a CD_DVD_BR
        /// </summary>
        /// <param name="id">Id of the CD_DVD_BR to return</param>
        /// <returns>A CD_DVD_BR with the provided id or null</returns>
        public CD_DVD_BR GetCD_DVD_BR(int id)
        {
            return db.CD_DVD_BR.SingleOrDefault(c => c.LibraryMaterialId == id);
        }

        /// <summary>
        /// Add a new CD_DVD_BR
        /// </summary>
        /// <param name="cD_DVD_BR">The CD_DVD_BR to add</param>
        /// <returns>True if CD_DVD_BR is added successfuly otherwise false</returns>
        public bool AddNewCD_DVD_BR(CD_DVD_BR cD_DVD_BR)
        {
            if (cD_DVD_BR != null)
            {
                db.CD_DVD_BR.Add(cD_DVD_BR);
                db.SaveChanges();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Delete a CD_DVD_BR
        /// </summary>
        /// <param name="id">Id of the CD_DVD_BR to delete</param>
        /// <returns>True if CD_DVD_BR is deleted successfuly otherwise false</returns>
        public bool DeleteCD_DVD_BR(int id)
        {
            var cD_DVD_BR = db.CD_DVD_BR.Find(id);
            if (cD_DVD_BR != null)
            {
                db.CD_DVD_BR.Remove(cD_DVD_BR);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a CD_DVD_BR
        /// </summary>
        /// <param name="cD_DVD_BR">CD_DVD_BR object</param>
        public void EditCD_DVD_BR(CD_DVD_BR cD_DVD_BR)
        {
            db.Entry(cD_DVD_BR).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}