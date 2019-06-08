using MongoDB.Driver;
using System;
using System.Diagnostics;

namespace CityCrimes.DAL
{

    public class DalTester
    {
        public DalTester()
        {
            try
            {
                //Debug.WriteLine("START");
                //var client = new MongoClient("mongodb://localhost:27017");
                //var mongoClientSettings = new MongoClientSettings();
                //mongoClientSettings.Credential = new MongoCredential().;

                //client.

                //Debug.WriteLine("MongoClient is initialized");

                //var doc = new TDocument
                //var db = client.GetDatabase("test");
                //var testCl = db.GetCollection("").InsertOne()

                //var collection = db.GetCollection<Crime>("crimes");

                //var data = collection.Find<Crime>(_ => _.ID == "4677901").ToList();

                //foreach (var item in data)
                //{
                //    Debug.WriteLine(item._id);
                //    Debug.WriteLine(item.ID);
                //    Debug.WriteLine(Environment.NewLine);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
