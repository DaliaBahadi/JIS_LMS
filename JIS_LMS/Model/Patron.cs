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
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
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
        public int Section { get; set; }
        public string ImageFile { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        public int PatronType { get; set; }
        public int LibraryId { get; set; }
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