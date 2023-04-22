using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Business.Models
{
    [DataContract]
    public class FligthsModels
    {
        [JsonIgnore]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public TransportModel Transport { get; set; }
    }
}
