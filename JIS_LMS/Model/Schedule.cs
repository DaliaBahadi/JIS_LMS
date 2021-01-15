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
        [Required (ErrorMessage = "The Year field is required")]
        [StringLength(4, ErrorMessage = "The length of the Year must be 4 characters")]
        public string Year { get; set; }
        [Required(ErrorMessage = "The Semester field is required")]
        [StringLength(20,ErrorMessage = "The length of the Semester is 20 characters")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "The Class Name field is required")]
        [StringLength(5, ErrorMessage = "The length of the Class Name is 5 characters")]
        public string ClassName { get; set; }
        [Required(ErrorMessage = "The Class Year field is required")]
        [StringLength(5, ErrorMessage = "The length of the Class Year is 5 characters")]
        public string ClassYear { get; set; }
        public int PatronId { get; set; }

        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Schedules")]
        public virtual Patron Patron { get; set; }
        [InverseProperty(nameof(Time_Slot.Schedule))]
        public virtual ICollection<Time_Slot> Time_Slots { get; set; }
    }
}
