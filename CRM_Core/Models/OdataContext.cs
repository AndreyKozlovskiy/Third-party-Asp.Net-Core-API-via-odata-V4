using Newtonsoft.Json;
using System.Collections.Generic;

namespace CRM_Core.Models
{
    public class OdataContext
    {
        [JsonProperty("@odata.context")]
        public string Context { get; set; }
        [JsonProperty("value")]
        public List<Contact> Contacts { get; set; }
    }
}
