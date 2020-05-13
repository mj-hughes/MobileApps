using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalityQuizWithAPI
{
    public class HeroesManager
    {
        IRestService restService;

        public HeroesManager(IRestService service)
        {
            restService = service;
        }

        public Task<HeroAPI> GetTasksAsync()
        {

            return restService.RefreshDataAsync();
        }
    }
}
