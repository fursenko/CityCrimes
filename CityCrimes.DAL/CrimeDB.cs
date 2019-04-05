using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CityCrimes.Common;
using System.Diagnostics;

namespace CityCrimes.DAL
{
    public class CrimeDB
    {
        private readonly string _connectionString;

        public CrimeDB(string cs = null)
        {
            _connectionString = cs ?? "mongodb://localhost:27017";
        }

        public IEnumerable<Crime> GetCrimes(SearchCrimeRequest request)
        {
            try
            {
                var client = new MongoClient(_connectionString);

                var db = client.GetDatabase("test");

                if (request == null || String.IsNullOrWhiteSpace(request.SearchCollection))
                    return new List<Crime>();

                var collection = db.GetCollection<Crime>(request.SearchCollection);

                var data = collection.Find(_ => _.PrimaryType == request.PrimaryType
                && _.Latitude != null
                && _.Latitude != ""
                && _.Longitude != null
                && _.Year == request.Year
                && _.Longitude != "").ToList();

                return data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return new List<Crime>();
            }
        }
    }
}
