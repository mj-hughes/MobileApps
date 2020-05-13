using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace PersonalityQuizWithAPI
{
    public class RestService : IRestService
    {
        HttpClient _client;
        string HeroId;
        //public static string HeroId = "1010733";

        public HeroAPI heroAPI { get; private set; }

        public RestService(string heroId)
        {
            _client = new HttpClient();
            HeroId = heroId;
        }

        public async Task<HeroAPI> RefreshDataAsync()
        {
            heroAPI = new HeroAPI();

            var uri = new Uri(string.Format(Constants.HeroInfoUrl+ HeroId+ Constants.Handshake, string.Empty));
            try
            {
                
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    
                    heroAPI = JsonConvert.DeserializeObject<HeroAPI>(content);
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return heroAPI;
        }

    }
}
