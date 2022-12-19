using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IAliasRouteService
    {
        public Task<Dictionary<string, List<AliasRoute>>> FetchAliasRoutesAsync();
    }
}
