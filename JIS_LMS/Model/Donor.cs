using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Donor")]
    [Index(nameof(FirstName), Name = "NonClusteredIndex_Donor_FirstName")]
    [Index(nameof(LastName), Name = "NonClusteredIndex_Donor_LastName")]
    [Index(nameof(MiddleName), Name = "NonClusteredIndex_Donor_MiddleName")]
    [Index(nameof(Mobile), Name = "NonClusteredIndex_Donor_Mobile")]
    public partial class Donor
    {
        public Donor()
        {
            Library_Materials = new HashSet<Library_Material>();
        }

        [Key]
        public int DonorId { get; set; }
        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the First Name field is 30 characters")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage = "The length for the Middle Name field is 30 characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the Last Name field is 30 characters")]
        public string LastName { get; set; }
        [StringLength(100, ErrorMessage = "The length for the Email field is 100 characters")]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(15) ]
        [RegularExpression("(05)(5|0|3|6|4|9|1|8|7)([0-9]{7})", ErrorMessage = "Wrong mobile number format. Ex. 0578965147 ")]
        public string Mobile { get; set; }

        [InverseProperty(nameof(Library_Material.Donor))]
        public virtual ICollection<Library_Material> Library_Materials { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
