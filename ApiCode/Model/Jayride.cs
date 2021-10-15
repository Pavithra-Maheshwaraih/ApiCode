using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiCode.Model
{
    public class Jayride
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class VehicleType
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("maxPassengers")]
            public int MaxPassengers { get; set; }
        }

        public class Listing
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("pricePerPassenger")]
            public double PricePerPassenger { get; set; }
            [JsonProperty("vehicleType")]
            public VehicleType VehicleType { get; set; }
        }

        public class Root
        {
            [JsonProperty("from")]
            public string From { get; set; }
            [JsonProperty("to")]
            public string To { get; set; }

            [JsonProperty("listings")]
            public List<Listing> Listings { get; set; }
        }




    }
}
