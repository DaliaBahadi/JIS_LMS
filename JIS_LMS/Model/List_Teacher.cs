using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Keyless]
    public partial class List_Teacher
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public string ImageFile { get; set; }
    }
}
