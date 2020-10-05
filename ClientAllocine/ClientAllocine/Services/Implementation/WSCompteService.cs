using ClientAllocine.Model;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.Services.Implementation
{
    public class WSCompteService : IWSService<Compte>
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly IWSBingMapService _mapService;
        public WSCompteService()
        {
            _client.BaseAddress = new Uri("http://localhost:5000/api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _mapService = SimpleIoc.Default.GetInstance<WSBingMapService>();
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

        public async Task UpdateCompteAsync(Compte compte)
        {
            HttpResponseMessage response = null;
            var content = new StringContent(JsonConvert.SerializeObject(compte), Encoding.UTF8, "application/json");
            try
            {
                response = await _client.PutAsync($"compte/{compte.CompteId}", content);
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
            return;
        }

        public async Task<Compte> CreateCompteAsync(Compte compte)
        {
            HttpResponseMessage response = null;
            if(!string.IsNullOrEmpty(compte.Pwd))
            {
                compte.Pwd = this.GetMd5(compte.Pwd);
            }

            //Generate Creation date
            compte.DateCreation = DateTime.Now;
            Rootobject coordinates = await _mapService.GetCoordinates(compte);
            compte.Latitude = coordinates.resourceSets.FirstOrDefault().resources.FirstOrDefault().point.coordinates[0];
            compte.Longitude = coordinates.resourceSets.FirstOrDefault().resources.FirstOrDefault().point.coordinates[1];
            var content = new StringContent(JsonConvert.SerializeObject(compte), Encoding.UTF8, "application/json");
            try
            {
                response = await _client.PostAsync($"compte", content);
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
            return compte;
        }

        private string GetMd5(string input)
        {
            var hash = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashValue = hash.ComputeHash(bytes);

            return BitConverter.ToString(hashValue).Replace("-", String.Empty);
        }
    }
}
