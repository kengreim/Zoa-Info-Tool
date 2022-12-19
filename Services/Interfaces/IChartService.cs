using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IChartService
    {
        public Task<List<Chart>> FetchChartsAsync(string airportFaaId);
    }
}
