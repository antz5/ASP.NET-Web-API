using System.Collections.Generic;
using System.Linq;
using X_Http_Method_Override.Models;

namespace X_Http_Method_Override.Helpers
{
    public class EmployeesHelper
    {
        static List<Employee> _empList = new List<Employee>();
        public static List<Employee> empList
        {
            get
            {
                return _empList;
            }
            set
            {
                value = new List<Employee>();
            }
        }
        
        public static List<Employee> All()
        {
            return empList;
        }

        public static Employee Single(int id)
        {
            return empList.SingleOrDefault(e => e.ID == id);
        }

        internal static void Add(Employee employee)
        {
            empList.Add(employee);
        }

        internal static Employee Modify(Employee emp)
        {
            var employee = empList.SingleOrDefault(e => e.ID == emp.ID);
            if (employee == null)
                return null;
            int i = empList.IndexOf(empList.Single(e => e.ID == emp.ID));
            empList.RemoveAt(i);
            employee = emp;
            empList.Insert(i, employee);
            return employee;
        }

        internal static void Delete(int id)
        {
            var employee = empList.SingleOrDefault(e => e.ID == id);
            if (employee != null)
                empList.Remove(employee);
        }
    }
}