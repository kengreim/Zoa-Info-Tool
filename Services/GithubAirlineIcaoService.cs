using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOAHelper.Services.Interfaces;
using ZOAHelper.Models;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Net.Http;

namespace ZOAHelper.Services
{
    public class GithubAirlineIcaoService : IAirlineIcaoService
    {
        private readonly HttpClient _httpClient;

        public GithubAirlineIcaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dictionary<string, Airline>> FetchAirlineIcaoCodesAsync()
        {
            string responseBody = await _httpClient.GetStringAsync(Constants.AirlinesCsvUrl);
            
            var returnDict = new Dictionary<string, Airline>();
            using (var csv = new CsvReader(new StringReader(responseBody), CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<AirlineMap>();
                var records = csv.GetRecords<Airline>();

                foreach (var record in records)
                {
                    returnDict.Add(record.IcaoId, record);
                }

                return returnDict;
            }
        }
    }

    internal class AirlineMap : ClassMap<Airline>
    {
        public AirlineMap()
        {
            Map(m => m.IcaoId).Name("3Ltr");
            Map(m => m.Name).Name("Company");
            Map(m => m.Callsign).Name("Telephony");
            Map(m => m.Country).Name("Country");
        }
    }
}
