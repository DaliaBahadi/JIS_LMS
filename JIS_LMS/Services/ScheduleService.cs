using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class ScheduleService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public ScheduleService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all schedules
        /// </summary>
        /// <returns>List of all schedules</returns>
        public List<Schedule> GetSchedules()
        {
            return db.Schedule.ToList();
        }

        /// <summary>
        /// Get a Schedule
        /// </summary>
        /// <param name="id">Id of the Schedule to return</param>
        /// <returns>A Schedule with the provided id or null</returns>
        public Schedule GetSchedule(int id)
        {
            return db.Schedule.SingleOrDefault(c => c.ScheduleId == id);
        }

        /// <summary>
        /// Add a new Schedule
        /// </summary>
        /// <param name="schedule">The Schedule to add</param>
        /// <returns>True if Schedule is added successfuly otherwise false</returns>
        public bool AddNewSchedule(Schedule schedule)
        {
            if (schedule != null)
            {
                db.Schedule.Add(schedule) ;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a Schedule
        /// </summary>
        /// <param name="id">Id of the Schedule to delete</param>
        /// <returns>True if Schedule is deleted successfuly otherwise false</returns>
        public bool DeleteSchedule(int id)
        {
            var schedule = db.Schedule.Find(id);
            if (schedule != null)
            {
                db.Schedule.Remove(schedule);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Edit a Schedule
        /// </summary>
        /// <param name="schedule">Schedule object</param>
        public void EditSchedule(Schedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}