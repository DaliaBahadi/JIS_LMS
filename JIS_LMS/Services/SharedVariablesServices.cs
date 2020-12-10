using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class SharedVariablesService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public SharedVariablesService(LMSDbContext context)
        {
            db = context;
        }

        public int AuthorMaterialId { get; set;}

        public int BookId { get; set; }

        public int JournalId { get; set; }

        public int CD_DVD_BR_Id { get; set; }

        public int StudentMaterialId { get; set; }

        public int TeacherMaterialId { get; set; }

        public int BorrowingMaterialId { get; set; }

        public int HoldMaterialId { get; set; }

        /// <summary>
        /// Get a addresses
        /// </summary>
        /// <param name="id">Id of the address to return</param>
        /// <returns>A addresses with the provided id or null</returns>
        //public List<Address> GetAddresses()
        //{
        //    return db.Address.ToList();
        //}







    }
}