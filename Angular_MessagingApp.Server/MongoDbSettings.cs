using MongoDB.Driver;

namespace Angular_MessagingApp.Server
{
    public class MongoDbSettings
    {
        public string? ConnectionString { get; set; } 

        public string? MessagingApp { get; set; } 
    }
}
