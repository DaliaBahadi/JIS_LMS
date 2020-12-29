using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("CD_DVD_BR")]
    [Index(nameof(ISBN), Name = "NonClusteredIndex_CD_DVD_BR_ISBN")]
    public partial class CD_DVD_BR
    {
        [Key]
        public int LibraryMaterialId { get; set; }
        [Required(ErrorMessage = "The ISBN field is required ")]
        [StringLength(25)]
        [RegularExpression("[0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*[-| ][0-9]*", ErrorMessage = "Wrong ISBN format. Ex. 978-1-86197-876-9 ")]

        public string ISBN { get; set; }
        [Required]
        [StringLength(80)]

        public string Format { get; set; }
        [StringLength(50)]
        public string Runtime { get; set; }
        [StringLength(80)]
        public string Quality { get; set; }
        [StringLength(100)]
        public string Subtitles { get; set; }
        [Required]
        public int Type { get; set; }

        [ForeignKey(nameof(LibraryMaterialId))]
        [InverseProperty(nameof(Library_Material.CD_DVD_BR))]
        public virtual Library_Material LibraryMaterial { get; set; }
    }
}

public enum CD_DVD_BR_Type
{
    DVD = 1, BR, CdROM, AudioFiles, VideoFiles


}
