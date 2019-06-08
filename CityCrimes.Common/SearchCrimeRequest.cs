using System;
using System.Collections.Generic;
using System.Text;

namespace CityCrimes.Common
{
    public class SearchCrimesRequest
    {
        public string Db { get; set; }
        public string PrimaryType { get; set; }
        public string Year { get; set; }
        public string SearchCollection { get { return GetCollection(Year); } }

        static string GetCollection(string ye)
        {
            //int year = 0;
            //if (Int32.TryParse(ye, out year))
            //{
            //    if (year >= 2000 && year <= 2004)
            //        return "crimes_2001_2004";

            //    if (year >= 2005 && year <= 2007)
            //        return "crimes_2005_2007";
            //}

            return "test";
        }
    }
}
