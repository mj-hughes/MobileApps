using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalityQuizWithAPI
{
    public interface IRestService
    {
        Task<HeroAPI> RefreshDataAsync();
    }
}
