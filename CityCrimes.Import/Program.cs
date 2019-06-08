using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCrimes.Import
{
    [BsonIgnoreExtraElements]
    public class Crime
    {
        [BsonElement(elementName: "Date")]
        public string Date { get; set; }

        [BsonElement(elementName: "Year")]
        public string Year { get; set; }

        [BsonElement(elementName: "Block")]
        public string Block { get; set; }

        [BsonElement(elementName: "Primary Type")]
        public string PrimaryType { get; set; }

        [BsonElement(elementName: "Description")]
        public string Description { get; set; }

        [BsonElement(elementName: "Location Description")]
        public string LocationDescription { get; set; }

        [BsonElement(elementName: "Latitude")]
        public string Latitude { get; set; }

        [BsonElement(elementName: "Longitude")]
        public string Longitude { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var settings = new MongoClientSettings() { Credentials = new[] { MongoCredential.CreateCredential("admin", "tom", "jerry") } };
                settings.Server = new MongoServerAddress("35.246.248.243", 27017);
                var mongoClient = new MongoClient(settings);
                //Crime
                var testDb = mongoClient.GetDatabase("citycrimes");
                var test = testDb.GetCollection<Crime>("test");

                var startTime = DateTime.Now.ToString();
                var lineCounter = 0;
                var addedLineCounter = 0;

                using (var fileReader = new StreamReader(@"C:\ROOT\Db\crimes-in-chicago\Chicago_Crimes_2001_to_2004.csv"))
                {
                    string line = null;
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        if (lineCounter == 0) { fileReader.ReadLine(); lineCounter++; continue; }

                        lineCounter++;
                        var data = line.Split(',');

                        if (String.IsNullOrWhiteSpace(data[data.Length - 1])) continue;

                        var crime = new Crime()
                        {
                            Block = data[4]
                            ,
                            Date = data[3]
                            ,
                            Description = data[7]
                            ,
                            Latitude = data[20]
                            ,
                            LocationDescription = data[8]
                            ,
                            Longitude = data[21]
                            ,
                            PrimaryType = data[6]
                            ,
                            Year = data[18]
                        };
                        addedLineCounter++;
                        test.InsertOne(crime);
                        Console.Clear();
                        Console.WriteLine("Start: {0}; Proccessed Lines: {1}; Added rows: {2}; Time: {3}", startTime, lineCounter, addedLineCounter, DateTime.Now);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

    }
}
