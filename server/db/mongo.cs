using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System.Collections.Generic;

namespace server
{
    public class DeviceObject {
        public string id;
        public string title;
        public string type;
        public object sensors;
    }

    public static class Mongo {        
        private static IMongoCollection<BsonDocument> collection;
        public static void connect(){
            var conStrVar= Environment.GetEnvironmentVariable("CONNECTION_STRING");
            var conString =  string.IsNullOrEmpty(conStrVar)? "mongodb://root:secret@localhost:27017" : conStrVar;
            var client= new MongoClient(conString);
            var db= client.GetDatabase("acme");
            collection = db.GetCollection<BsonDocument>("devices"); 
        }

        public static void insert(BsonDocument document) {
            collection.InsertOne(document);
        }

        public static List<DeviceObject> get() {            
            List<DeviceObject> newList= new List<DeviceObject>();
            var documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument item in documents){                                
                DeviceObject device = new DeviceObject();
                device.id= item.GetValue("_id").AsObjectId.ToString();
                device.title= item.GetValue("title").AsString;
                device.type= item.GetValue("type").AsString;
                var sensors= item.GetValue("sensors").AsBsonDocument;
                var docs= new Dictionary<string, string>();
                foreach (var sensor in sensors){
                    docs.Add(sensor.Name, sensor.Value.AsString);
                }
                Console.WriteLine(docs);
                device.sensors= docs;
                newList.Add(device);                
            }
            return newList;
        }
    }
}