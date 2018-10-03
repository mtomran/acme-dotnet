using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mongo.connect();
            var document = new BsonDocument
            {
                { "title", "MongoDB" },
                { "type", "Database" },                
                { "sensors", new BsonDocument
                    {
                        { "fuel", "90" },
                        { "engine", "ON" }
                    }}
            };
            Mongo.insert(document);
            Mongo.get();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
