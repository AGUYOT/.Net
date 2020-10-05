using ClientAllocine.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.Services.Implementation
{
    public class WSBingMapService : IWSBingMapService
    {
        private static readonly HttpClient _client = new HttpClient();

        public WSBingMapService()
        {
            _client.BaseAddress = new Uri("http://dev.virtualearth.net/REST/v1/Locations/FR/");
        }
        public async Task<Rootobject> GetCoordinates(Compte compte)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync(ConstructUrl(compte));
                response.EnsureSuccessStatusCode();
            }
            catch (TimeoutException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            Rootobject coordinates = JsonConvert.DeserializeObject<Rootobject>(responseBody);
            return coordinates;
        }

        private string ConstructUrl(Compte compte)
        {
            return $"{compte.CodePostal}/{compte.Ville}/{compte.Rue}?key=Ag7KBEIMrvvjF2Kpz9Ze9UaNNoj1jkizmw-_bxWFpRaLJEXzBGNW-IFl4aHj5jd1";
        }
    }
}
