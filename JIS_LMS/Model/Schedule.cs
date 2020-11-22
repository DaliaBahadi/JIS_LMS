using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Schedule")]
    public partial class Schedule
    {
        public Schedule()
        {
            Time_Slots = new HashSet<Time_Slot>();
        }

        [Key]
        public int ScheduleId { get; set; }
        [Required]
        [StringLength(4)]
        public string Year { get; set; }
        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassName { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassYear { get; set; }
        public int PatronId { get; set; }

        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Schedules")]
        public virtual Patron Patron { get; set; }
        [InverseProperty(nameof(Time_Slot.Schedule))]
        public virtual ICollection<Time_Slot> Time_Slots { get; set; }
    }
}
