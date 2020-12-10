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

        /// <summary>
        /// Delete a address
        /// </summary>
        /// <param name="id">Id of the address to delete</param>
        /// <returns>True if address is deleted successfuly otherwise false</returns>
        //public bool DeleteAddress(int id)
        //{
        //    var address = db.Address.Find(id);
        //    if (address != null)
        //    {
        //        db.Address.Remove(address);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// Edit a address
        /// </summary>
        /// <param name="address">address object</param>
        //public void EditAddress(Address address)
        //{
        //    db.Entry(address).State = EntityState.Modified;
        //    db.SaveChanges();

        //}
    }
}