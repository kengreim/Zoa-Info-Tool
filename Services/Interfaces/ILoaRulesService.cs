using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface ILoaRulesService
    {
        public Task<List<LoaRule>> FetchLoaRulesAsync();
    }
}
