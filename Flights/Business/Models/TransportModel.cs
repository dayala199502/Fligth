using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Business.Models
{
    [DataContract]
    public class TransportModel
    {
        [JsonIgnore]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FlightCarrier { get; set; }
        [DataMember]
        public string FligthNumber { get; set; }
    }
}
