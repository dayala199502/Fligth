using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class JourneyFligthEntities
    {
        public int FLIGHTID { get; set; }
        public int JOURNEYID { get; set; }

        public List<FlightEntities> FlightEntities { get; set; }
        public JourneyEntities JourneyEntities { get; set; }

    }
}
