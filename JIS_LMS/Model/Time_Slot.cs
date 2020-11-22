using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Time_Slot")]
    public partial class Time_Slot
    {
        public Time_Slot()
        {
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public int TimeSlotId { get; set; }
        public int WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        [StringLength(4)]
        public string Year { get; set; }
        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
        public bool Reserved { get; set; }
        public int ScheduleId { get; set; }
        public int LibraryId { get; set; }

        [ForeignKey(nameof(LibraryId))]
        [InverseProperty("Time_Slots")]
        public virtual Library Library { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        [InverseProperty("Time_Slots")]
        public virtual Schedule Schedule { get; set; }
        [InverseProperty(nameof(Notification.TimeSlot))]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
