using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using JIS_LMS.Data;

using JIS_LMS.Model;

using Microsoft.EntityFrameworkCore;



namespace JIS_LMS.Services

{

    public class TimeSlotService

    {




        // Instance of the db context

        private readonly LMSDbContext db;



        // Constructor using dependency injection

        public TimeSlotService(LMSDbContext context)

        {

            db = context;

        }



        /// <summary>

        /// Get all appoitnments



        async public Task<List<Time_Slot>> GetAppointments()

        {

            return db.Time_Slot.ToList();

        }



        /// <summary>

        /// Get an appointment 

        /// </summary>



        public Time_Slot GetAppointment(int id)

        {

            return db.Time_Slot.SingleOrDefault(c => c.TimeSlotId == id);

        }



        /// <summary>

        /// Add a new appointment

        /// <returns>True if address is added successfuly otherwise false</returns>

        public bool AddNewAppointment(Time_Slot t)

        {

            if (t != null)

            {

                db.Time_Slot.Add(t);

                db.SaveChanges();

                return true;

            }

            return false;

        }



        /// <summary>

        /// Delete appointment



        public bool DeleteAppointment(int id)

        {

            var slot = db.Time_Slot.Find(id);

            if (slot != null)

            {

                db.Time_Slot.Remove(slot);

                db.SaveChanges();

                return true;

            }

            return false;

        }



        /// <summary>

        /// Edit appointment





        public void EditAppointment(Time_Slot slot)

        {

            db.Entry(slot).State = EntityState.Modified;

            db.SaveChanges();



        }

    }

}