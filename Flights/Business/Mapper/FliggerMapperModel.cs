using Business.Models;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Mapper
{
    internal class FliggerMapperModel
    {
        public static JourneyModels MapModelEntitis(JourneyEntities journeyEntities)
        {
            if (journeyEntities != null)
            {
                return new JourneyModels()
                {
                    Destination = journeyEntities.DESTINATION,
                    Origin = journeyEntities.ORIGIN,
                    Price = journeyEntities.PRICE,

                };
            }
            return null;            
        }
        public static List<FligthsModels> MapModelEntitis(List<FlightEntities> flightEntities)
        {
            List<FligthsModels> fligthsModels = new List<FligthsModels>();
            foreach (FlightEntities flight in flightEntities)
            {
                FligthsModels models = new FligthsModels() 
                {

                    Destination = flight.DESTINATION,
                    Origin = flight.ORIGIN,
                    Price = flight.PRICE,
                    Transport = MapModelEntitis(flight.TransportEntities)
                };
                fligthsModels.Add(models);
                
            }
            return fligthsModels;
        }
        public static TransportModel MapModelEntitis(TransportEntities transportEntities)
        {
            return new TransportModel()
            {
                FlightCarrier = transportEntities.FLIGHTCARNER,
                FligthNumber = transportEntities.FLIGHTNUMBER
            };
        }
        public static JourneyFligthModel MapModelEntitis(JourneyFligthEntities journeyFligthEntities)
        {
            
            return new JourneyFligthModel()
            {
                FligthsModels = MapModelEntitis(journeyFligthEntities.FlightEntities),
                JourneyModels = MapModelEntitis(journeyFligthEntities.JourneyEntities)
            };
        }

    }
}
