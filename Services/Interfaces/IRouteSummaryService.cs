using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IRouteSummaryService
    {
        public Task<List<RouteSummary>> FetchRouteSummariesAsync(string departureIcao, string arrivalIcao);
    }
}
