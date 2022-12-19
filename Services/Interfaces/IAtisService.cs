using System.Collections.Generic;
using System.Threading.Tasks;
using ZOAHelper.Models;

namespace ZOAHelper.Services.Interfaces
{
    public interface IAtisService
    {
        public Task<List<Atis>> GetAllAsync();
    }
}
