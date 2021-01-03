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

        public int GetLibraryMaterialId { get; set; }
        
        public int AcquirePatronId { get; set; }

        public int AcquireParentId { get; set; }
        public int BorrowingMaterialId { get; set; }

        public int HoldMaterialId { get; set; }

        public int GetPatronId { get; set; }

        public int GetEmployeeId { get; set; }








    }
}