using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CityCrimes.DAL
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
}
