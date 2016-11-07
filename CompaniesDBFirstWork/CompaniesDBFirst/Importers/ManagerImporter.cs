using System;
using System.IO;
using System.Linq;

namespace CompaniesDBFirst.Importers
{
    class ManagerImporter
    {

        public Action<SocialNetworkPractiseEntities, TextWriter> Get
        {
            get
            {
                return (dbContext, tWriter) =>
                {
                    var employeesCollection = dbContext.Employees.ToList();
                    int employeesCount = employeesCollection.Count;
                    int managerCount = employeesCount * 5/100;

                    for (int i = 0; i < employeesCount; i++)
                    {
                        
                        employeesCollection[i].ManagerId = employeesCollection[RandomGenerator.GetRandomNumber(0, managerCount)].EmployeeId;
                                              

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
                return "Assigning managers. Each dot is 20 managers ";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }
    }
}
