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
        [Required]
        [StringLength(25)]
        public string ISBN { get; set; }
        public int? Edition { get; set; }
        public int BookType { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.Book))]
        public virtual Library_Material LibraryMaterial { get; set; }
    }
}
