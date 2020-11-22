using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Student")]
    [Index(nameof(ClassYear), Name = "NonClusteredIndex_ClassYear")]
    [Index(nameof(StudentId), Name = "NonClusteredIndex_StudentId", IsUnique = true)]
    [Index(nameof(ClassName), Name = "NonClusteredIndex__Student_ClassName")]
    public partial class Student
    {
        public Student()
        {
            Student_Parents = new HashSet<Student_Parent>();
        }

        [Key]
        public int PatronId { get; set; }
        public int StudentId { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassYear { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassName { get; set; }
        public int AgeLevel { get; set; }
        [Required]
        [StringLength(30)]
        public string HomeRoomTeacher { get; set; }

        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Student")]
        public virtual Patron Patron { get; set; }
        [InverseProperty(nameof(Student_Parent.Patron))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }

       
    }
}

public enum StudentAgeLevel
{
    Kindergarten = 1, Elementary, MiddleSchool, HighSchool
}