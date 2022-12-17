
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FreePark.Models
{
    public class CarDetails
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        /*public class Root
        {
            public List<string> decode { get; set; }
        }*/
        public int Id { get; set; }
    }
    public class Balance
    {
        [Newtonsoft.Json.JsonProperty("API Decode")]
        public int APIDecode { get; set; }
    }

    public class Decode
    {
        public string label { get; set; }
        public object value { get; set; }
        public int? id { get; set; }
    }

    public class Root
    {
        public int price { get; set; }
        public string price_currency { get; set; }
        public Balance balance { get; set; }
        public List<Decode> decode { get; set; }
    }
}
