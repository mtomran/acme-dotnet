using System;
using MongoDB.Driver;
using MongoDB.Bson;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
namespace dotnettest
{
    class Program
    {
        static void Main(string[] args)
        {            
            var client= new MongoClient("mongodb://root:secret@localhost:27017");
            var db= client.GetDatabase("acme");
            var collection = db.GetCollection<BsonDocument>("devices"); 

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

            collection.InsertOne(document);

            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var doc in cursor.ToEnumerable())
            {
                Console.WriteLine(doc);   
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
