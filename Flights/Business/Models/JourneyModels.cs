using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Business.Models
{
    [DataContract]
    public class JourneyModels
    {

        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string Destination { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public List<FligthsModels> Fligths { get; set; }
    }
}
