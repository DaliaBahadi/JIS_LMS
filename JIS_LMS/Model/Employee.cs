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
        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the First Name field is 30 characters")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "The length for the Middle Name field is 30 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the Last Name field is 30 characters")]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "The Date Of Birth field is required ")]

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "The Email field is required ")]
        [StringLength(100, ErrorMessage = "The length for the Email field is 100 characters")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Mobile field is required ")]
        [StringLength(15)]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong mobile number format. Ex. 0578965147 ")]

        public string Mobile { get; set; }
        [Required(ErrorMessage = "The Language field is required ")]
        public int Language { get; set; }
        [Required(ErrorMessage = "The Gender field is required ")]
        public int Gender { get; set; }
        [StringLength(15, ErrorMessage = "The length for the Phone Extension field is 15 characters")]
        public string PhoneExtension { get; set; }
        [Required(ErrorMessage = "The UserName field is required ")]
        [StringLength(10, ErrorMessage = "The length for the UserName field is 10 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password field is required ")]
        [StringLength(15, ErrorMessage = "The length for the Password field is 15 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Employee Type field is required ")]
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
