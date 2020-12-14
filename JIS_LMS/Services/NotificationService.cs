using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class NotificationService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public NotificationService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all notifications
        /// </summary>
        /// <returns>List of all notifications</returns>
        public List<Notification> GetNotifications()

        {

            return db.Notification.ToList();
        }

        /// <summary>
        /// Get a notification
        /// </summary>
        /// <param name="id">Id of the notification to return</param>
        /// <returns>A notification with the provided id or null</returns>
        public Notification GetNotification(int id)
        {
            return db.Notification.SingleOrDefault(c => c.NotificationId == id);
        }

        /// <summary>
        /// Add a new notification
        /// </summary>
        /// <param name="notification">The notification to add</param>
        /// <returns>True if notification is added successfuly otherwise false</returns>
        public bool AddNewNotification(Notification notification)
        {
            if (notification != null)
            {
                db.Notification.Add(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a notification
        /// </summary>
        /// <param name="id">Id of the notification to delete</param>
        /// <returns>True if notification is deleted successfuly otherwise false</returns>
        public bool DeleteNotification(int id)
        {
            var notification = db.Notification.Find(id);
            if (notification != null)
            {
                db.Notification.Remove(notification);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a notification
        /// </summary>
        /// <param name="notification">notification object</param>
        public void EditNotification(Notification notification)
        {
            db.Entry(notification).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}