using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IRouteSummaryService
    {
        public Task<List<RouteSummary>> FetchRouteSummariesAsync(string departureIcao, string arrivalIcao);
    }
}
