using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class FlightEntities
    {
        public int ID { get; set; }
        public int TRANSPORT_ID { get; set; }
        public string ORIGIN { get; set; }
        public string DESTINATION { get; set; }
        public decimal PRICE { get; set; }
        public TransportEntities TransportEntities { get; set; }
    }
}
