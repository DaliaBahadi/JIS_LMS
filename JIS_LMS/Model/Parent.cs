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
        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the First Name field is 30 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Middle Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the Middle Name field is 30 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the Last Name field is 30 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Gender field is required ")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "The Relation field is required ")]
        public int Relation { get; set; }
        [Required(ErrorMessage = "The Primary Contact Number field is required ")] 
        [StringLength(15)]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong Primary Contact Number format. Ex. 0578965147 ")]

        public string PrimaryContactNumber { get; set; }
        [StringLength(15)]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong Secondary Contact Number format. Ex. 0578965147 ")]

        public string SecondaryContactNumber { get; set; }
        [Required(ErrorMessage = "The Primary Email field is required ")]
        [StringLength(100, ErrorMessage = "The length for the Primary Email field is 100 characters")]
        [EmailAddress]
        public string PrimaryEmail { get; set; }
        [StringLength(100, ErrorMessage = "The length for the Secondary Email field is 100 characters")]
        [EmailAddress]
        public string SecondaryEmail { get; set; }
        [Required(ErrorMessage = "The Language field is required ")]
        public int Language { get; set; }
        [Required(ErrorMessage = "The Address field is required ")]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Parents")]
        public virtual Address Address { get; set; }
        [InverseProperty(nameof(Student_Parent.Parent))]
        public virtual ICollection<Student_Parent> Student_Parents { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
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