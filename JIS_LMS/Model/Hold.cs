using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Hold")]
    public partial class Hold
    {
        [Key]
        public int HoldId { get; set; }
        public DateTime HoldDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public bool HoldStatus { get; set; }
        public string Remark { get; set; }
        public int LibraryMaterialId { get; set; }
        public int PatronId { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.Holds))]
        public virtual Library_Material LibraryMaterial { get; set; }
        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Holds")]
        public virtual Patron Patron { get; set; }
    }
}
