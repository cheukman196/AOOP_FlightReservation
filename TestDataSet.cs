using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOOP_GroupProject_draft1
{
    class TestDataSet
    {
        private static List<List<object>> flightData;
        private static List<List<string>> customerData;
        private static List<List<object>> bookingData;

        public TestDataSet()
        {
            flightData = new List<List<object>>{
                new List<object> { 111, "HKG", "YYZ", 20 },
                new List<object> { 222, "FDA", "BDE", 10 },
                new List<object> { 333, "XPT", "NLQ", 4 },
                new List<object> { 444, "EUT", "PKP", 35 },
                new List<object> { 555, "IEK", "YYZ", 35 },
                new List<object> { 666, "IEK", "PKP", 35 },
                new List<object> { 777, "HKG", "PKP", 35 },
                new List<object> { 888, "YYZ", "PKP", 35 },
                new List<object> { 999, "EUT", "YYZ", 35 },
                new List<object> { 100, "YVR", "PKP", 35 },
                new List<object> { 101, "YYZ", "PKP", 35 },
                new List<object> { 102, "YVR", "PKP", 35 },
                new List<object> { 103, "PIE", "YYZ", 35 },
                new List<object> { 104, "DIX", "PKP", 35 },
                new List<object> { 105, "WES", "YYZ", 35 }
            };

            customerData = new List<List<string>>
            {
                 new List<string> {"Lee", "Adams", "1111" },
                 new List<string> {"Queenie", "Merriweather", "2222"},
                 new List<string> {"Ian", "Kojima", "3333"},
                 new List<string> {"Levi", "Arson", "4444"},
                 new List<string> {"Dori", "Tang", "5555"},
                 new List<string> {"Aron", "Steveson", "6666"},
                 new List<string> {"Kuthrapalli", "Rajesh", "7777"},
                 new List<string> {"Indiana", "Reeds", "8888"},
                 new List<string> {"Manderly", "Hanson", "9999"},
                 new List<string> {"Elli", "Watson", "1000"},
                 new List<string> {"Yarvick", "Watson", "1001"},
                 new List<string> {"Ulysses", "Katzman", "1002"},
                 new List<string> {"Jeoffrey", "Jones", "1003"},
                 new List<string> {"Tiana", "Owana", "1004"},
                 new List<string> {"Aubrey", "Reeds", "1005" }
            };
        }

        
    }
}
