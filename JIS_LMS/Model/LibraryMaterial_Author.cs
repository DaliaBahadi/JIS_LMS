using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("LibraryMaterial_Author")]
    public partial class LibraryMaterial_Author
    {
        [Key]
        public int LibraryMaterialId { get; set; }
        [Key]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("LibraryMaterial_Authors")]
        public virtual Author Author { get; set; }
        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.LibraryMaterial_Authors))]
        public virtual Library_Material LibraryMaterial { get; set; }
    }
}
