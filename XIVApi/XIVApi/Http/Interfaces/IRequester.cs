using System.Collections.Generic;
using System.Threading.Tasks;

namespace XIVApi.Http.Interfaces
{
    public interface IRequester
    {
        Task<string> CreateGetRequestAsync(string relativeUrl, List<string> queryParameters = null);
    }
}