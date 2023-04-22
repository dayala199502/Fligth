using DataAccess.Entities;
using DataAccess.EntityFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class FligthisDAOs
    {
        private readonly FligthsEntities fligthsEntities;
        private readonly EventLog eventLog;
        private readonly Random random;

        public FligthisDAOs()
        {
            fligthsEntities = new FligthsEntities();
            eventLog = new EventLog();
            random = new Random();
        }

        public async Task<int> SaveJourney(JourneyEntities journeyEntities)
        {
            try
            {
                JOURNEY jOURNEY = new JOURNEY
                {
                    DESTINATION = journeyEntities.DESTINATION,
                    ORIGIN = journeyEntities.ORIGIN,
                    PRICE = journeyEntities.PRICE,
                };
                fligthsEntities.Set<JOURNEY>().Add(jOURNEY);
                await fligthsEntities.SaveChangesAsync();
                eventLog.Source = "Application";
                eventLog.WriteEntry($"El registo se creo corretamente en el metodo {this}.{nameof(SaveJourney)}", EventLogEntryType.Information, random.Next(1, 1000 + DateTime.Now.Second));
                return jOURNEY.ID;
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);
            }

        }
        public async Task<int> UpdateJourney(JourneyEntities journeyEntities)
        {
            try
            {

                JOURNEY jOURNEY = new JOURNEY
                {
                    ID = journeyEntities.ID,
                    DESTINATION = journeyEntities.DESTINATION,
                    ORIGIN = journeyEntities.ORIGIN,
                    PRICE = journeyEntities.PRICE,
                };
                fligthsEntities.Set<JOURNEY>().AddOrUpdate(jOURNEY);
                await fligthsEntities.SaveChangesAsync();
                eventLog.WriteEntry($"El registo se creo corretamente en el Metodo {this}.{nameof(UpdateJourney)} ", 
                    EventLogEntryType.Information, random.Next(1, 1000 + DateTime.Now.Second));

                return jOURNEY.ID;

            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);
            }
        }

        public async Task<int> SaveFlight(FlightEntities flightEntities)
        {
            try
            {
                FLIGHT fLIGHT = new FLIGHT()
                {
                    DESTINATION = flightEntities.DESTINATION,
                    ORIGIN = flightEntities.ORIGIN,
                    PRICE = flightEntities.PRICE,
                    TRANSPORT_ID = flightEntities.TRANSPORT_ID
                };
                fligthsEntities.Set<FLIGHT>().Add(fLIGHT);
                await fligthsEntities.SaveChangesAsync();
                eventLog.WriteEntry($"El registo se creo corretamente en el metodo {this}.{nameof(SaveFlight)}", 
                    EventLogEntryType.Information, random.Next(1, 1000 + DateTime.Now.Second));

                return fLIGHT.ID;
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);
            }
        }
        public async Task<int> SaveTransport(TransportEntities transportEntities)
        {
            try
            {
                TRANSPORT tRANSPORT = new TRANSPORT()
                {
                    FLIGHTCARNER = transportEntities.FLIGHTCARNER,
                    FLIGHTNUMBER = transportEntities.FLIGHTNUMBER
                };
                fligthsEntities.Set<TRANSPORT>().Add(tRANSPORT);
                await fligthsEntities.SaveChangesAsync();
                eventLog.WriteEntry($"El registo se creo corretamente en el metodo {this}.{nameof(transportEntities)}",
                    EventLogEntryType.Information, random.Next(1, 1000 + DateTime.Now.Second));
                return tRANSPORT.ID;
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);
            }

        }
        public async Task<int> SaveJourneyFlight(JourneyFligthEntities journeyFligthEntities)
        {
            try
            {
                fligthsEntities.JOURNEYFLIGHTSet.Add(new JOURNEYFLIGHT
                {
                    FLIGHTID = journeyFligthEntities.FLIGHTID,
                    JOURNEYID = journeyFligthEntities.JOURNEYID
                });
                eventLog.WriteEntry($"El registo se creo corretamente en el metodo {this}.{nameof(SaveJourneyFlight)}",
                    EventLogEntryType.Information, random.Next(1, 1000 + DateTime.Now.Second));

                return await fligthsEntities.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);
            }

        }
        public JourneyFligthEntities GetFligthEntities(JourneyEntities journeyEntities)
        {
            try
            {
                List<JourneyEntities> querys = (from j in fligthsEntities.JOURNEY
                                                where j.ORIGIN == journeyEntities.ORIGIN && j.DESTINATION == journeyEntities.DESTINATION
                                                select new JourneyEntities
                                                {
                                                    ID = j.ID,
                                                    DESTINATION = j.DESTINATION,
                                                    ORIGIN = j.ORIGIN,
                                                    PRICE = j.PRICE,
                                                }).ToList();

                List<FlightEntities> query =
                                                     (from jf in fligthsEntities.JOURNEYFLIGHTSet
                                                      join f in fligthsEntities.FLIGHT on jf.FLIGHTID equals f.ID
                                                      join t in fligthsEntities.TRANSPORT on f.TRANSPORT_ID equals t.ID
                                                      join j in fligthsEntities.JOURNEY on jf.JOURNEYID equals j.ID
                                                      where j.ORIGIN == journeyEntities.ORIGIN && j.DESTINATION == journeyEntities.DESTINATION
                                                      select new FlightEntities
                                                      {
                                                          DESTINATION = f.DESTINATION,
                                                          ID = f.ID,
                                                          ORIGIN = f.ORIGIN,
                                                          PRICE = f.PRICE,
                                                          TRANSPORT_ID = f.ID,
                                                          TransportEntities = new TransportEntities()
                                                          {
                                                              FLIGHTCARNER = t.FLIGHTCARNER,
                                                              FLIGHTNUMBER = t.FLIGHTNUMBER,
                                                              ID = t.ID
                                                          }
                                                      }).ToList();

                JourneyEntities journey = null;
                if (querys.ToList().Count > 0)
                {
                    journey = new JourneyEntities();
                    journey.ID = querys.FirstOrDefault().ID;
                    journey.DESTINATION = querys.FirstOrDefault().DESTINATION;
                    journey.ORIGIN = querys.FirstOrDefault().ORIGIN;
                    journey.PRICE = querys.FirstOrDefault().PRICE;
                }

                return new JourneyFligthEntities()
                {
                    JourneyEntities = journey,
                    FlightEntities = query.ToList()
                };

            }
            catch (Exception ex)
            {
                eventLog.WriteEntry(ex.Message.ToString(), EventLogEntryType.Error, random.Next(1, 1000 + DateTime.Now.Second));
                throw new Exception(ex.ToString(), ex);

            }
        }
    }
}
