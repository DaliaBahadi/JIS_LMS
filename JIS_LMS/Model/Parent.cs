using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Parent")]
    [Index(nameof(FirstName), Name = "NonClusteredIndex_Parent_FirstName")]
    [Index(nameof(LastName), Name = "NonClusteredIndex_Parent_LastName")]
    [Index(nameof(MiddleName), Name = "NonClusteredIndex_Parent_MiddleName")]
    [Index(nameof(PrimaryContactNumber), Name = "NonClusteredIndex_Parent_PrimaryContactNumber")]
    public partial class Parent
    {
        public Parent()
        {
            Student_Parents = new HashSet<Student_Parent>();
        }

        [Key]
        public int ParentId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int Relation { get; set; }
        [Required]
        [StringLength(15)]
        public string PrimaryContactNumber { get; set; }
        [StringLength(15)]
        public string SecondaryContactNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string PrimaryEmail { get; set; }
        [StringLength(100)]
        public string SecondaryEmail { get; set; }
        public int Language { get; set; }
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Parents")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Student_Parent.Parent))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }
    }
}

public enum ParentGender
{
    Female = 1, Male
}

public enum ParentLanguage
{
    English = 1, Arabic, Frensh
}

public enum ParentRelation
{
    Mother = 1, Father, Other
}