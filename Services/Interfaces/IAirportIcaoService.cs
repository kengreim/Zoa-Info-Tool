using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IAirportIcaoService
    {
        public Task<Dictionary<string, Airport>> FetchAirportsAsync();
    }
}
