using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Library_Material")]
    [Index(nameof(LibraryMaterialType), Name = "NonClusteredIndex_LibraryMateialType")]
    [Index(nameof(AccessionNumber), Name = "NonClusteredIndex_LibraryMaterial_AcessionNumber")]
    [Index(nameof(AgeLevel), Name = "NonClusteredIndex_LibraryMaterial_AgeLevel")]
    [Index(nameof(Genre), Name = "NonClusteredIndex_LibraryMaterial_Genre")]
    [Index(nameof(Subject), Name = "NonClusteredIndex_LibraryMaterial_Subject")]
    public partial class Library_Material
    {
        public Library_Material()
        {
            Borrowings = new HashSet<Borrowing>();
            Holds = new HashSet<Hold>();
            LibraryMaterial_Authors = new HashSet<LibraryMaterial_Author>();
        }

        [Key]
        public int LibraryMaterialId { get; set; }
        public int AccessionNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateAcquired { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateRecorded { get; set; }
        [Required]
        public string Title { get; set; }
        public int? NumberOfPages { get; set; }
        [StringLength(150)]
        public string SourceOfFund { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? CostPrice { get; set; }
        [Required]
        [StringLength(4)]
        public string YearPublished { get; set; }
        public int Language { get; set; }
        public string SubjectTranslationInEnglish { get; set; }
        [Required]
        [StringLength(80)]
        public string Genre { get; set; }
        [Required]
        [StringLength(80)]
        public string Subject { get; set; }
        [StringLength(80)]
        public string CityPublished { get; set; }
        public int AgeLevel { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public string DOIURL { get; set; }
        public int? RestrictionType { get; set; }
        public int LibraryMaterialType { get; set; }
        public int PublisherId { get; set; }
        public int DonorId { get; set; }
        public int LibraryId { get; set; }

        [ForeignKey(nameof(DonorId))]
        [InverseProperty("Library_Materials")]
        public virtual Donor Donor { get; set; }
        [ForeignKey(nameof(LibraryId))]
        [InverseProperty("Library_Materials")]
        public virtual Library Library { get; set; }
        [ForeignKey(nameof(PublisherId))]
        [InverseProperty("Library_Materials")]
        public virtual Publisher Publisher { get; set; }
        [InverseProperty("LibraryMaterial")]
        public virtual Book Book { get; set; }
        [InverseProperty("LibraryMaterial")]
        public virtual CD_DVD_BR CD_DVD_BR { get; set; }
        [InverseProperty("LibraryMaterial")]
        public virtual Journal Journal { get; set; }
        [InverseProperty(nameof(Borrowing.LibraryMaterial))]
        public virtual ICollection<Borrowing> Borrowings { get; set; }
        [InverseProperty(nameof(Hold.LibraryMaterial))]
        public virtual ICollection<Hold> Holds { get; set; }
        [InverseProperty(nameof(LibraryMaterial_Author.LibraryMaterial))]
        public virtual ICollection<LibraryMaterial_Author> LibraryMaterial_Authors { get; set; }
    }
}

public enum LibraryMaterialLanguage
{
    English = 1, Arabic, Frensh, Other
}


public enum LibraryMaterialStatus
{
    Available = 1, Borrowed, Hold, Lost, Damaged, Missing, Restricted
}

public enum RestrectionType
{
    TeachersTextbooks = 1 , References, Other
}

public enum LibraryMaterialType
{
    Book = 1, Journal = 2, CdDvdBr 

}

public enum LibraryMaterialAgeLevel
{
    Kindergarten = 1, Elementary, MiddleSchool, HighSchool
}