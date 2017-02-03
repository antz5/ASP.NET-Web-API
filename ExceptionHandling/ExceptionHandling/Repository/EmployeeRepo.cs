using ExceptionHandling.Models;
using System.Collections.Generic;

namespace ExceptionHandling.Repository
{
    public class EmployeeRepo
    {
        List<EmployeeModels> listOfEmployees = new List<EmployeeModels>();
        EmployeeModels empModel1 = new EmployeeModels()
        {
            EmployeeId = 1,
            FirstName = "Joseph",
            LastName = "Maddy",
            salary = 52000
        };

        EmployeeModels empModel5 = new EmployeeModels()
        {
            EmployeeId = 2,
            FirstName = "Jason",
            LastName = "Bourne",
            salary = 90000
        };

        EmployeeModels empModel2 = new EmployeeModels()
        {
            EmployeeId = 3,
            FirstName = "Jackson",
            LastName = "Gibbs",
            salary = 75000
        };

        EmployeeModels empModel3 = new EmployeeModels()
        {
            EmployeeId = 4,
            FirstName = "Jethro",
            LastName = "Gibbs",
            salary = 89000
        };

        EmployeeModels empModel4 = new EmployeeModels()
        {
            EmployeeId = 5,
            FirstName = "Allison",
            LastName = "Tancredi",
            salary = 43000
        };

        public EmployeeRepo()
        {
            
            listOfEmployees.Add(empModel1);
            listOfEmployees.Add(empModel5);
            listOfEmployees.Add(empModel4);
            listOfEmployees.Add(empModel3);
            listOfEmployees.Add(empModel2);
        }
        public List<EmployeeModels> Get()
        {  
            return listOfEmployees;
        }

        public EmployeeModels Get(int id)
        {
            EmployeeModels employee = null;
            foreach (EmployeeModels emp in listOfEmployees)
            {
                if (emp.EmployeeId == id)
                {
                    employee = emp;
                    return employee;
                }
            }
            return employee;
        }       
    }
}