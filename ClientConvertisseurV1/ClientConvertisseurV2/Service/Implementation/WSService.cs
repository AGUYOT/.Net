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
        private static WSService instance;
        private static readonly HttpClient client = new HttpClient();
        
        public WSService()
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WSService GetInstance()
        {
            if(instance == null)
            {
                instance = new WSService();
            }
            return instance;
        }

        public async Task<IEnumerable<Devise>> GetDevisesAsync()
        {
            HttpResponseMessage response = await client.GetAsync("devise");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            IEnumerable<Devise> devises = JsonConvert.DeserializeObject<IEnumerable<Devise>>(responseBody);
            return devises;
        }
    }
}
