using Business.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Business.Mapper
{
    internal class FligthsMapperEntities
    {
        public static JourneyEntities MapEntityModel(JourneyModels journeyModels)
        {
            return new JourneyEntities()
            {
                DESTINATION = journeyModels.Destination,
                ORIGIN = journeyModels.Origin,
                PRICE = journeyModels.Price
            };
        }
        public static FlightEntities MapEntitiesModel(FligthsModels fligthsModels)
        {
            return new FlightEntities()
            {
                DESTINATION = fligthsModels.Destination,
                ORIGIN = fligthsModels.Origin,
                PRICE = fligthsModels.Price,
                TRANSPORT_ID = fligthsModels.Transport.Id
            };
        }
        public static TransportEntities MapEntitiesModel(TransportModel transportModel) 
        {
            return new TransportEntities()
            {
                FLIGHTCARNER = transportModel.FlightCarrier,
                FLIGHTNUMBER = transportModel.FligthNumber
            };
        }
        public static JourneyFligthEntities MapEntitiesModel(int fligthid, int journeyId)
        {
            return new JourneyFligthEntities()
            {
                FLIGHTID = fligthid,
                JOURNEYID = journeyId
            };
        }
    }
}
