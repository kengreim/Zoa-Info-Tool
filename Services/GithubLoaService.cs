﻿using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZOAHelper.Models;
using ZOAHelper.Services.Interfaces;

namespace ZOAHelper.Services
{
    public class GithubLoaService : ILoaRulesService
    {
        private readonly HttpClient _httpClient;

        public GithubLoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LoaRule>> FetchLoaRulesAsync()
        {
            string responseBody = await _httpClient.GetStringAsync(Constants.LoaRulesCsvUrl);

            var returnList = new List<LoaRule>();
            using (var csv = new CsvReader(new StringReader(responseBody), CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<LoaRuleMap>();
                var records = csv.GetRecords<LoaRule>();

                foreach (var record in records)
                {
                    returnList.Add(record);
                }

                return returnList;
            }
        }
    }

    internal class LoaRuleMap : ClassMap<LoaRule>
    {
        public LoaRuleMap()
        {
            Map(m => m.DepartureAirportRegex).Convert(args => new Regex(args.Row.GetField("Departure_Regex")));
            Map(m => m.ArrivalAirportRegex).Convert(args => new Regex(args.Row.GetField("Arrival_Regex")));
            Map(m => m.Route).Name("Route");
            Map(m => m.IsRnavRequired).Name("RNAV Required");
            Map(m => m.Notes).Name("Notes");
        }
    }
}
