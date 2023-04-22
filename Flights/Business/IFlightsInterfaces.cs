using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    [ServiceContract]
    public interface IFlightsInterfaces
    {
        [OperationContract]
        Task<List<FligthsModels>> GetFligths();
        [OperationContract]
        Task<JourneyModels> GetFligthsSearch(JourneyModels journeyModels);
    }
}
