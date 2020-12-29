using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Patron")]
    [Index(nameof(FirstName), Name = "NonClusteredIndex_Patron_FirstName")]
    [Index(nameof(LastName), Name = "NonClusteredIndex_Patron_LastName")]
    [Index(nameof(MiddleName), Name = "NonClusteredIndex_Patron_MiddleName")]
    [Index(nameof(Section), Name = "NonClusteredIndex_Patron_Section")]
    public partial class Patron
    {
        public Patron()
        {
            Borrowings = new HashSet<Borrowing>();
            Holds = new HashSet<Hold>();
            Notifications = new HashSet<Notification>();
            Schedules = new HashSet<Schedule>();
        }

        [Key]
        public int PatronId { get; set; }

        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Middle Name field is required ")]
        [StringLength(30)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Gender field is required ")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "The Date Of Birth field is required ")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "The Primary Contact Number field is required ")]
        [StringLength(15)]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong Primary Contact Number format. Ex. 0578965147 ")]

        public string PrimaryContactNumber { get; set; }

        [StringLength(15)]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong Secondary Contact Number format. Ex. 0578965147 ")]

        public string SecondaryContactNumber { get; set; }

        [Required(ErrorMessage = "The Primary Email Number field is required ")]
        [StringLength(100)]
        [EmailAddress]
        public string PrimaryEmail { get; set; }
        [StringLength(100)]
        [EmailAddress]
        public string SecondaryEmail { get; set; }

        [Required(ErrorMessage = "The Language field is required ")]
        public int Language { get; set; }

        [Required(ErrorMessage = "The Section field is required ")]
        public int Section { get; set; }
        public string ImageFile { get; set; }
        public string Remark { get; set; }

        [Required(ErrorMessage = "The Status field is required ")]
        public int Status { get; set; }

        [Required(ErrorMessage = "The Primary Registration Date field is required ")]
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "The UserName field is required ")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required ")]
        [StringLength(15)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Patron Type field is required ")]
        public int PatronType { get; set; }

        [Required(ErrorMessage = "The Library field is required ")]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "The Address field is required ")]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Patrons")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(LibraryId))]
        [InverseProperty("Patrons")]
        public virtual Library Library { get; set; }
        [InverseProperty("Patron")]
        public virtual Student Student { get; set; }
        [InverseProperty("Patron")]
        public virtual Teacher Teacher { get; set; }
        [InverseProperty(nameof(Borrowing.Patron))]
        public virtual ICollection<Borrowing> Borrowings { get; set; }
        [InverseProperty(nameof(Hold.Patron))]
        public virtual ICollection<Hold> Holds { get; set; }
        [InverseProperty(nameof(Notification.Patron))]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty(nameof(Schedule.Patron))]
        public virtual ICollection<Schedule> Schedules { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}

public enum PatronGender
{
    Female = 1, Male
}

public enum PatronLanguage
{
    English = 1, Arabic, Frensh
}

public enum PatronSection
{
    Girls = 1, Boys
}

public enum PatronStatus
{
    Active = 1, Inactive
}

public enum PatronType
{
    Student = 1, Teacher
}