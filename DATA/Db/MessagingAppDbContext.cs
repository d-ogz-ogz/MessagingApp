
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Db
{
    public class MessagingAppDbContext 
    {
        private readonly IMongoDatabase _db;
        internal IMongoClient? MongoClient;

        public MessagingAppDbContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            _db = client.GetDatabase(config["MongoDbSetting:DatabaseName"]);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db .GetCollection<T>(name);
        }


    }
}