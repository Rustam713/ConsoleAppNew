using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNew.Models
{
    public class Employee
    {
        private static int nextId = 1;

        public int Employee_Code { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string WorkSchedule { get; set; }
        public int RestaurantID { get; set; }

        public Employee(int employee_code)
        {
            Employee_Code = employee_code;
        }

        public Employee(int employee_code, string name, string position, decimal salary, string workschedule, int restaurant)
        {

            Employee_Code = employee_code;
            Name = name;
            Salary = salary;
            Position = position;
            WorkSchedule = workschedule;
            RestaurantID = restaurant;
        }
    }
}

