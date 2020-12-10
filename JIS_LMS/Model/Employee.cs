using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            Libraries = new HashSet<Library>();
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Mobile { get; set; }
        public int Language { get; set; }
        public int Gender { get; set; }
        [StringLength(15)]
        public string PhoneExtension { get; set; }
        [Required]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        public int EmployeeType { get; set; }

        [InverseProperty(nameof(Library.Librarian))]
        public virtual ICollection<Library> Libraries { get; set; }
        [InverseProperty(nameof(Notification.Librarian))]
        public virtual ICollection<Notification> Notifications { get; set; }


        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}

public enum EmployeeGender
{
    Female = 1, Male
}

public enum EmployeeLanguage
{
    English = 1, Arabic, Frensh
}

public enum EmployeeType
{
    Librarian = 1, SystemAdminstrator
}
