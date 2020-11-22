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
        public int BuildingNumber { get; set; }
        public int? UnitNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [StringLength(10)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [InverseProperty(nameof(Library.Address))]
        public virtual ICollection<Library> Libraries { get; set; }
        [InverseProperty(nameof(Parent.Address))]
        public virtual ICollection<Parent> Parents { get; set; }
        [InverseProperty(nameof(Patron.Address))]
        public virtual ICollection<Patron> Patrons { get; set; }
    }
}
