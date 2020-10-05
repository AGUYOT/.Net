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
    public class WSCompteService : IWSService<Compte>
    {
        private static readonly HttpClient _client = new HttpClient();

        public WSCompteService()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Compte>> GetAllAsync()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync("compte");
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

            IEnumerable<Compte> comptes = JsonConvert.DeserializeObject<IEnumerable<Compte>>(responseBody);
            return comptes;
        }

        public async Task<Compte> GetByStringAsync(string param)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _client.GetAsync($"compte/GetByEmail/{param}");
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

            Compte compte = JsonConvert.DeserializeObject<Compte>(responseBody);
            return compte;
        }
    }
}
