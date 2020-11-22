using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Author")]
    [Index(nameof(FirstName), nameof(LastName), Name = "NonClusteredIndex_Author_Name")]
    public partial class Author
    {
        public Author()
        {
            LibraryMaterial_Authors = new HashSet<LibraryMaterial_Author>();
        }

        [Key]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [InverseProperty(nameof(LibraryMaterial_Author.Author))]
        public virtual ICollection<LibraryMaterial_Author> LibraryMaterial_Authors { get; set; }
    }
}
