using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JIS_LMS.Data;
using JIS_LMS.Model;

namespace JIS_LMS.Services
{
    public class EmployeeService
    {
        // Instance of the db context
        private readonly LMSDbContext db;

        // Constructor using dependency injection
        public EmployeeService(LMSDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of all employee</returns>
        public List<Employee> GetEmployees()
        {
            return db.Employee.ToList();
        }

        /// <summary>
        /// Get a employee
        /// </summary>
        /// <param name="id">Id of the employee to return</param>
        /// <returns>A employee with the provided id or null</returns>
        public Employee GetEmployee(int id)
        {
            return db.Employee.SingleOrDefault(c => c.EmployeeId == id);
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="employee">The employee to add</param>
        /// <returns>True if employee is added successfuly otherwise false</returns>
        public bool AddNewEmployee(Employee employee)
        {
            if (employee != null)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete a employee
        /// </summary>
        /// <param name="id">Id of the employee to delete</param>
        /// <returns>True if employee is deleted successfuly otherwise false</returns>
        public bool DeleteEmployee(int id)
        {
            var employee = db.Employee.Find(id);

            try
            {
                if (employee != null)
                {
                    db.Employee.Remove(employee);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (DbUpdateException ex)
            {
            }
            
            return false;
        }

        /// <summary>
        /// Edit a employee
        /// </summary>
        /// <param name="employee">employee object</param>
        public void EditEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

        }


        List<Employee> employees = new List<Employee>();
        public async Task<List<Employee>> EmployeeList()
        {
            return await Task.FromResult(employees);
        }
    }
}