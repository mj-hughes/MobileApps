using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using FillInFables.Models;
using Newtonsoft.Json;

namespace FillInFables
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public MadLibz madLibz { private set; get; }


        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<MadLibz> RefreshDataAsync()
        {
            var uri = new Uri(string.Format(Constants.MadLibzInfo, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    madLibz = JsonConvert.DeserializeObject<MadLibz>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return madLibz;
        }
    }
}
