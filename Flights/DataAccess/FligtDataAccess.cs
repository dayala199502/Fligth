using DataAccess.DAOs;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FligtDataAccess
    {
        private readonly FligthisDAOs _fligthisDAOs ;
        public FligtDataAccess()
        {
            _fligthisDAOs = new FligthisDAOs();
        }
        public async Task<int> SaveJourney(JourneyEntities journeyEntities)
        {
            return await _fligthisDAOs.SaveJourney(journeyEntities);
        }
        public async Task<int> SaveFlight(FlightEntities flightEntities)
        {
            return await _fligthisDAOs.SaveFlight(flightEntities);
        }
        public async Task<int> SaveTransport(TransportEntities transportEntities)
        {
            return await _fligthisDAOs.SaveTransport(transportEntities);
        }
        public async Task<int> SaveJourneyFlight(JourneyFligthEntities journeyFligthEntities)
        {
            return await _fligthisDAOs.SaveJourneyFlight(journeyFligthEntities);
        }
        public JourneyFligthEntities GetFligthEntities(JourneyEntities journeyEntities)
        {
            return _fligthisDAOs.GetFligthEntities(journeyEntities);
        }
        public async Task<int> UpdateJourney(JourneyEntities journeyEntities)
        {
            return await _fligthisDAOs.UpdateJourney(journeyEntities);
        }

    }
}
