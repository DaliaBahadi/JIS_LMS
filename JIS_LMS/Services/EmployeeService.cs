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

        public List<Employee> GetEmployees()
        {
            return db.Employee.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return db.Employee.SingleOrDefault(c => c.EmployeeId == id);
        }

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

        public bool DeleteEmployee(int id)
        {
            var employee = db.Employee.Find(id);
            if (employee != null)
            {
                db.Employee.Remove(employee);
                db.SaveChanges();
                return true;
            }
            return false;
        }

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