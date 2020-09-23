using ClientConvertisseurV1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Service.Implementation
{
    public class WSService : IWSService
    {
        private static WSService _instance;
        private static readonly HttpClient _client = new HttpClient();
        
        public WSService()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WSService GetInstance()
        {
            if(_instance == null)
            {
                _instance = new WSService();
            }
            return _instance;
        }

        public async Task<IEnumerable<Devise>> GetDevisesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("devise");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            IEnumerable<Devise> devises = JsonConvert.DeserializeObject<IEnumerable<Devise>>(responseBody);
            return devises;
        }
    }
}
