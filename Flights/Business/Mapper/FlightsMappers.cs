using Business.Models;
using Business.ModelServices;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Mapper
{
    internal class FlightsMappers
    {
        public static List<FligthsModels> MapEntityModel(List<FligthsModelServices> fligthsEntities)
        {

            List<FligthsModels> fligths = new List<FligthsModels>();
            fligthsEntities.ForEach(entity =>
            {
                fligths.Add(new FligthsModels
                {
                    Destination = entity.arrivalStation,
                    Origin = entity.departureStation,
                    Price = Convert.ToDecimal(entity.price),
                    Transport = new TransportModel()
                    {
                        FlightCarrier = entity.flightCarrier,
                        FligthNumber = entity.flightNumber
                    }
                });
            });
            return fligths;
        }
        public static JourneyModels MapEntityModel(List<FligthsModels> fligthsModels, JourneyModels journeyModels)
        {

            return new JourneyModels()
            {
                Destination = journeyModels.Destination,
                Origin = journeyModels.Origin,
                Fligths = fligthsModels,
                Price = fligthsModels.Sum(x => x.Price)
            };
        }
        public static JourneyModels Map(JourneyFligthModel journeyFligthModel)
        {
            return new JourneyModels();
        }
    }
}
