using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Teacher")]
    [Index(nameof(EmployeeId), Name = "NonClusteredIndex_Teacher_EmployeeId", IsUnique = true)]
    public partial class Teacher
    {
        [Key]
        public int PatronId { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Teacher")]
        public virtual Patron Patron { get; set; }
    }
}
