using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesDBFirst.Importers
{
    class EmployeeImporter : IImporter
    {
        private const int employeesCount = 5000;

        public Action<SocialNetworkPractiseEntities, TextWriter> Get
        {

            get
            {
                return (dbContext, tWriter) =>
                {
                    var departmentIdCollection = dbContext.Departments.Select(x => x.DepartmentId).ToList();
                    var employeeCount = dbContext.Employees.ToList().Count;
                    var count = employeeCount == 0 ? 250 : employeeCount * (5/100)+250; 
                    for (int i = 0; i < employeesCount; i++)
                    {

                        var currentFirstName = RandomGenerator.GetRandomString(5, 20);
                        var currentLastName = RandomGenerator.GetRandomString(5, 20);
                        var currentSalary = RandomGenerator.GetRandomNumber(50000, 200000);
                        var currentDepartmentId = departmentIdCollection[RandomGenerator.GetRandomNumber(0, departmentIdCollection.Count-1)];

                        var currentEmployee = new Employee
                        {
                            FirstName = currentFirstName,
                            LastName = currentLastName,
                            YearSalary = currentSalary,
                            DepartmentId = currentDepartmentId
                        };
                        if(i>count)
                        {
                            var empCollection = dbContext.Employees.Select(x => x.EmployeeId).ToList();
                            var empCount = empCollection.Count;
                            currentEmployee.ManagerId = empCollection[RandomGenerator.GetRandomNumber(0, empCount - 1)];
                        }

                        dbContext.Employees.Add(currentEmployee);

                        if (i % 20 == 0)
                        {
                            tWriter.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            dbContext.SaveChanges();
                            dbContext.Dispose();
                            dbContext = new SocialNetworkPractiseEntities();
                        }
                    }

                    dbContext.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing Employees. Each dot is 20 emmployees ";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }
    }
}
