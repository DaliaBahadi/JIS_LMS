using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Publisher")]
    [Index(nameof(Name), Name = "NonClusteredIndex_Publisher_Name")]
    public partial class Publisher
    {
        public Publisher()
        {
            Library_Materials = new HashSet<Library_Material>();
        }

        [Key]
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "The Name field is required ")]
        [StringLength(100, ErrorMessage = "The length for the Name field is 100 characters")]
        public string Name { get; set; }

        [InverseProperty(nameof(Library_Material.Publisher))]
        public virtual ICollection<Library_Material> Library_Materials { get; set; }
    }
}
