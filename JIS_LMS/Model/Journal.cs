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
        [Required(ErrorMessage = "The ISSN field is required ")]
        [StringLength(15)]
        [RegularExpression("[0-9]*[-| ][0-9]*", ErrorMessage = "Wrong ISSN format. Ex. 1237-4197 ")]

        public string ISSN { get; set; }
        public int? Volume { get; set; }
        public int? Issue { get; set; }
        [Required]
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