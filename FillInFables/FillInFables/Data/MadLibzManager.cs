using System;
using System.Threading.Tasks;
using FillInFables.Models;

namespace FillInFables
{
    public class MadLibzManager
    {
        IRestService restService;

        public MadLibzManager(IRestService service)
        {
            restService = service;
        }

        public Task<MadLibz> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
