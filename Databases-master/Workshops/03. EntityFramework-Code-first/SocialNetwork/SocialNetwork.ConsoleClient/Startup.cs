namespace SocialNetwork.ConsoleClient
{
    using Data;

    public class Startup
    {
        public static void Main()
        {
            var db = new SocialNetworkDBContext();
            db.Database.CreateIfNotExists
        }
    }
}
