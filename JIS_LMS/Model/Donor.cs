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
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(15)]
        [Range(0000000000, 0999999999, ErrorMessage ="Please Enter a valid mobile number")]
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
