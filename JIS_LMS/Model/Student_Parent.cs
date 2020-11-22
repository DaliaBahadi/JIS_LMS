using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Student_Parent")]
    public partial class Student_Parent
    {
        [Key]
        public int PatronId { get; set; }
        [Key]
        public int ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty("Student_Parents")]
        public virtual Parent Parent { get; set; }
        [ForeignKey(nameof(PatronId))]
        [InverseProperty(nameof(Student.Student_Parents))]
        public virtual Student Patron { get; set; }
    }
}
