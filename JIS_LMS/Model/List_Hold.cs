using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Keyless]
    public partial class List_Hold
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime ExpiryDateTime { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
    }
}
