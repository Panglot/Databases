using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesDBFirst.Importers
{
    class ProjectImporter : IImporter
    {
        private const int projectsCount = 1000;

        public Action<SocialNetworkPractiseEntities, TextWriter> Get
        {
            get
            {
                return (dbContext, tWriter) =>
                {

                    for (int i = 0; i < projectsCount; i++)
                    {
                        var currentProject = RandomGenerator.GetRandomString(5, 50);

                        
                        dbContext.Projects.Add(new Project { Name = currentProject });

                        if (i % 20 == 0)
                        {
                            tWriter.Write(".");
                        }

                        if(i%100 == 0)
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
                return "Importing projects. Each dot is 20 projects ";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }
    }
}
