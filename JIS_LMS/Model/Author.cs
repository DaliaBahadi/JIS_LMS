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
        [Required(ErrorMessage = "The First Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the First Name field is 30 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name field is required ")]
        [StringLength(30, ErrorMessage = "The length for the Last Name field is 30 characters")]
        public string LastName { get; set; }

        [InverseProperty(nameof(LibraryMaterial_Author.Author))]
        public virtual ICollection<LibraryMaterial_Author> LibraryMaterial_Authors { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
