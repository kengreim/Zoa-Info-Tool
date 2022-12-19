using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IAircraftIcaoService
    {
        public Task<Dictionary<string, List<Aircraft>>> FetchAircraftIcaoCodesAsync();
    }
}
