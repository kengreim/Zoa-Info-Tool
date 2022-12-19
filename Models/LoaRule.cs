﻿using System.Text.RegularExpressions;

namespace ZOAHelper.Models
{
    public class LoaRule
    {
        public Regex DepartureAirportRegex { get; set; }
        public Regex ArrivalAirportRegex { get; set; }
        public string Route { get; set; }
        public bool IsRnavRequired { get; set; }
        public string Notes { get; set; }
    }
}
