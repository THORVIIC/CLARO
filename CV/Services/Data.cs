using CV.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CV.Services
{
    public class Data
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://api.jsonbin.io/v3/b/6670b55be41b4d34e404c04d";

        public async Task<MovieResponse> ObtenerDatosAsync(string url = ApiUrl)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(content);
                    return movieResponse;
                }
                else
                {
                    throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al obtener los datos: {ex.Message}", ex);
            }
        }
    }
}
