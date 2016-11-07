using System;
using System.IO;

namespace CompaniesDBFirst.Importers
{
    interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<SocialNetworkPractiseEntities, TextWriter> Get { get; }
    }
}
