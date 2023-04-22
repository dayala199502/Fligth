using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class JourneyEntities
    {
        public int ID { get; set; }
        public string ORIGIN { get; set; }
        public string DESTINATION { get; set; }
        public Nullable<decimal> PRICE { get; set; }


    }
}
