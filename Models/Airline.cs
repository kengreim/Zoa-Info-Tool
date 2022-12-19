using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOAHelper.Models
{
    public class Airline
    {
        public string IcaoId { get; set; }
        public string? Callsign { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Airline() { }
        
        public Airline(string icaoID, string? callsign, string name)
        {
            IcaoId = icaoID;
            Callsign = callsign;
            Name = name;
        }
    }
}
