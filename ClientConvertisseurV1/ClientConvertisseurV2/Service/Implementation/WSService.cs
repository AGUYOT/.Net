using ClientConvertisseurV2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ClientConvertisseurV2.Service.Implementation
{
    public class WSService : IWSService
    {
        private static readonly HttpClient _client = new HttpClient();
        
        public WSService()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Devise>> GetDevisesAsync()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync("devise");
                response.EnsureSuccessStatusCode();
            } catch(TimeoutException e)
            {
                throw e;
            } catch (Exception e)
            {
                throw e;
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            IEnumerable<Devise> devises = JsonConvert.DeserializeObject<IEnumerable<Devise>>(responseBody);
            return devises;
        }
    }
}
