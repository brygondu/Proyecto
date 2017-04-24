using Proyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Proyecto.Services
{
    public class ApiService
    {

        public async Task<List<Geolocations>> GetAllGeolocation()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://apirestproyectoxam.azurewebsites.net/tables/Geolocation";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Geolocations>>(data);
                }
                else
                    return new List<Geolocations>();
            }
        }

        public async Task<Geolocations> CreateGeolocation(Geolocations newGeolocations)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://apirestproyectoxam.azurewebsites.net/tables/Geolocation";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                string content = JsonConvert.SerializeObject(newGeolocations);

                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(url, body);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Geolocations>(data);
                }
                else
                    return null;

            }
        }

    }
}
