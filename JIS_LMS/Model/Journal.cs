using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Journal")]
    [Index(nameof(ISSN), Name = "NonClusteredIndex_Journal_ISSN")]
    public partial class Journal
    {
        [Key]
        public int LibraryMaterialId { get; set; }
        [Required]
        [StringLength(15)]
        public string ISSN { get; set; }
        public int? Volume { get; set; }
        public int? Issue { get; set; }
        public int JournalType { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.Journal))]
        public virtual Library_Material LibraryMaterial { get; set; }
    }
}

public enum JournalType
{
    Journals = 1, Serials, Periodicals, Magazine

}