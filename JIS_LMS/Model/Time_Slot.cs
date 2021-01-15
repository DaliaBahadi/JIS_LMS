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
        [Required(ErrorMessage = "The Week Day field is required ")]
        public int WeekDay { get; set; }
        [Required(ErrorMessage = "The Start Time field is required ")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "The End Time field is required ")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "The Year field is required ")]
        [StringLength(4,ErrorMessage = "The length of the Year must be 4")]
        public string Year { get; set; }
        [Required(ErrorMessage = "The Semester field is required ")]
        [StringLength(20)]
        public string Semester { get; set; }
        [Required(ErrorMessage = "The Reserved field is required ")]
        public bool Reserved { get; set; }
        public string Text { get; set; }
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
