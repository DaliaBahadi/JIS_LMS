using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Book")]
    [Index(nameof(ISBN), Name = "NonClusteredIndex_Book_ISBN")]
    public partial class Book
    {
        [Key]
        public int LibraryMaterialId { get; set; }
        [Required(ErrorMessage = "The ISBN field is required ")]
        [StringLength(25)]
        [RegularExpression("[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*", ErrorMessage = "Wrong ISBN format. Ex. 978-1-86197-876-9 ")]

        public string ISBN { get; set; }
        public int? Edition { get; set; }
        [Required]
        public int BookType { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.Book))]
        public virtual Library_Material LibraryMaterial { get; set; }
    }
}

public enum BookType
{
    PhysicalBook = 1, EBook,

}
