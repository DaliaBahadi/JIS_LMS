using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Library")]
    [Index(nameof(Name), Name = "NonClusteredIndex_library_Name")]
    public partial class Library
    {
        public Library()
        {
            Library_Materials = new HashSet<Library_Material>();
            Patrons = new HashSet<Patron>();
            Time_Slots = new HashSet<Time_Slot>();
        }

        [Key]
        public int LibraryId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int Section { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public int LibrarianId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Libraries")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(LibrarianId))]
        [InverseProperty(nameof(Employee.Libraries))]
        public virtual Employee Librarian { get; set; }
        [InverseProperty(nameof(Library_Material.Library))]
        public virtual ICollection<Library_Material> Library_Materials { get; set; }
        [InverseProperty(nameof(Patron.Library))]
        public virtual ICollection<Patron> Patrons { get; set; }
        [InverseProperty(nameof(Time_Slot.Library))]
        public virtual ICollection<Time_Slot> Time_Slots { get; set; }
    }
}

public enum LibrarySection
{
    Girls = 1, Boys
}

public enum LibraryStatus
{
    Opened = 1, Closed
}