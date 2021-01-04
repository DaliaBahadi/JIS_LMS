using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            Libraries = new HashSet<Library>();
            Parents = new HashSet<Parent>();
            Patrons = new HashSet<Patron>();
        }

        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "The Building Number field is required ")]
        public int BuildingNumber { get; set; }
        public int? UnitNumber { get; set; }
        [Required(ErrorMessage = "The Street Name field is required ")]
        public string StreetName { get; set; }
        [StringLength(10, ErrorMessage = "The length for the Zip Code field is 5 characters", MinimumLength = 5)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "The City field is required ")]
        [StringLength(100, ErrorMessage = "The length for the City field is 100 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "The Country field is required ")]
        [StringLength(100, ErrorMessage = "The length for the Country field is 100 characters")]
        public string Country { get; set; }

        [InverseProperty(nameof(Library.Address))]
        public virtual ICollection<Library> Libraries { get; set; }
        [InverseProperty(nameof(Parent.Address))]
        public virtual ICollection<Parent> Parents { get; set; }
        [InverseProperty(nameof(Patron.Address))]
        public virtual ICollection<Patron> Patrons { get; set; }
    }
}
