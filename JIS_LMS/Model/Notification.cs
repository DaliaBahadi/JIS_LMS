using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JIS_LMS.Model
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public DateTime NotificationDateTime { get; set; }
        [Required]
        public string MessageContent { get; set; }
        public int NotificationType { get; set; }
        public int PatronId { get; set; }
        public int LibrarianId { get; set; }
        public int TimeSlotId { get; set; }

        [ForeignKey(nameof(LibrarianId))]
        [InverseProperty(nameof(Employee.Notifications))]
        public virtual Employee Librarian { get; set; }
        [ForeignKey(nameof(PatronId))]
        [InverseProperty("Notifications")]
        public virtual Patron Patron { get; set; }
        [ForeignKey(nameof(TimeSlotId))]
        [InverseProperty(nameof(Time_Slot.Notifications))]
        public virtual Time_Slot TimeSlot { get; set; }
    }
}
