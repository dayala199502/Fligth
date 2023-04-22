using Business.HttpServices;
using Business.Mapper;
using Business.Models;
using Business.ModelServices;
using DataAccess;
using DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Business
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class FlightsServices : IFlightsInterfaces
    {
        private readonly string url;
        private readonly ClientServices clientServices;
        private readonly FligtDataAccess _fligtDataAccess;
        public FlightsServices()
        {
            url = WebConfigurationManager.AppSettings["ApiFlights"];
            clientServices = new ClientServices();
            _fligtDataAccess = new FligtDataAccess();

        }
        public async Task<List<FligthsModels>> GetFligths()
        {
            List<FligthsModelServices> FligthsEntities = JsonConvert.DeserializeObject<List<FligthsModelServices>>(await clientServices.ExecuteRequestByGet(url,
                "GET", "application/json"));

            return FlightsMappers.MapEntityModel(FligthsEntities);
        }
        public async Task<JourneyModels> GetFligthsSearch(JourneyModels journeyModels)
        {
            JourneyFligthModel journeyFligthModels = GetFligts(journeyModels);
            if (journeyFligthModels.JourneyModels == null && journeyFligthModels.FligthsModels.Count == 0)
            {
                List<FligthsModelServices> FligthsEntities = JsonConvert.DeserializeObject<List<FligthsModelServices>>(await clientServices.ExecuteRequestByGet(url,
                "GET", "application/json"));

                List<FligthsModels> fligths = FlightsMappers.MapEntityModel(FligthsEntities);
                List<FligthsModels> filterOrigin = fligths.Where(x => x.Origin == journeyModels.Origin).ToList();
                List<FligthsModels> filterDestination = fligths.Where(x => x.Destination == journeyModels.Destination).ToList();
                

                List<FligthsModels> filter = fligths.Where(x => x.Origin == journeyModels.Origin 
                                                        || x.Destination == journeyModels.Destination).ToList();
                journeyModels.Price = filter.Sum(x => x.Price);
                if (filter.Count > 0)
                {
                    int Journey = await _fligtDataAccess.SaveJourney(FligthsMapperEntities.MapEntityModel(journeyModels));
                    foreach (FligthsModels fligthsModels in filter)
                    {
                        int transport = await _fligtDataAccess.SaveTransport(FligthsMapperEntities.MapEntitiesModel(fligthsModels.Transport));
                        fligthsModels.Transport.Id = transport;
                        int flights = await _fligtDataAccess.SaveFlight(FligthsMapperEntities.MapEntitiesModel(fligthsModels));
                        int JourneyFligth = await _fligtDataAccess.SaveJourneyFlight(FligthsMapperEntities.MapEntitiesModel(flights, Journey));

                    }
                }
                return FlightsMappers.MapEntityModel(filter, journeyModels);
            }
            return new JourneyModels()
            {
                Destination = journeyFligthModels.JourneyModels.Destination,
                Fligths = journeyFligthModels.FligthsModels,
                Origin = journeyFligthModels.JourneyModels.Origin,
                Price = journeyFligthModels.JourneyModels.Price
            };
        }
        private JourneyFligthModel GetFligts(JourneyModels journeyModels)
        {
            return FliggerMapperModel.MapModelEntitis(_fligtDataAccess.GetFligthEntities(FligthsMapperEntities.MapEntityModel(journeyModels)));
        }
    }
}
