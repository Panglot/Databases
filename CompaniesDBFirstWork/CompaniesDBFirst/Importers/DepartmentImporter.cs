using System;
using System.Collections.Generic;
using System.IO;

namespace CompaniesDBFirst.Importers
{
    public class DepartmentImporter : IImporter
    {
        private const int departmentsCount = 100;

        public Action<SocialNetworkPractiseEntities, TextWriter> Get
        {
            get
            {
                return (dbContext, tWriter) =>
                {
                    var departmentCollection = new List<string>();

                    for (int i = 0; i < departmentsCount; i++)
                    {
                        var currentDepartment = RandomGenerator.GetRandomString(10, 50);

                        while (departmentCollection.Contains(currentDepartment))
                        {
                            currentDepartment = RandomGenerator.GetRandomString(10, 50);
                        }

                        departmentCollection.Add(currentDepartment);
                        dbContext.Departments.Add(new Department { Name = currentDepartment });

                        if(i%20 == 0)
                        {
                            tWriter.Write(".");
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
                return "Importing departments. Each dot is 20 departments ";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }
    }
}
