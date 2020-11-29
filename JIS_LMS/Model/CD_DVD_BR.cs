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
        [Required]
        [StringLength(25)]
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