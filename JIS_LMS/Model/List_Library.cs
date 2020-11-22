using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Keyless]
    public partial class List_Library
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public int Section { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }
}
