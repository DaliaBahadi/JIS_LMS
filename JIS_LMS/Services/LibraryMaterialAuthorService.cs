﻿using System;
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

        
    }
}