using CompaniesDBFirst.Importers;
using System;

namespace CompaniesDBFirst
{
    class DBWork
    {
        static void Main(string[] args)
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
