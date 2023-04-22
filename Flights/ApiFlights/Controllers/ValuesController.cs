using Business;
using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiFlights.Controllers
{
    public class ValuesController : ApiController
    { 

        // GET api/GetFligths
        public async Task<object> GetFligths([FromBody] JourneyModels journeyModels)
        {
            IFlightsInterfaces flightsInterfaces = new FlightsServices();
            var result = await flightsInterfaces.GetFligthsSearch(journeyModels);
            object error = "La sólicutud no a podido ser procesada";
            if (result.Fligths.Count == 0)
            {
                return error;
            }
            return await flightsInterfaces.GetFligthsSearch(journeyModels);
        }


        // POST api/values

        public Task<List<FligthsModels>> Post([FromBody] string value)
        {
            IFlightsInterfaces flightsInterfaces = new FlightsServices();
            return flightsInterfaces.GetFligths();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
