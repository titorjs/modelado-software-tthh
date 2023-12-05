using Interfaz_Login.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Interfaz_Login.Data
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiRoute = "http://apiservicios.ecuasolmovsa.com:3009";

        public ApiService() { 
            _httpClient = new HttpClient();

        }
        public async Task<List<Emisor>> emisors()
        {
            List<Emisor> emisores;
            try
            {
                emisores = await _httpClient.GetFromJsonAsync<List<Emisor>>("http://apiservicios.ecuasolmovsa.com:3009/api/Varios/GetEmisor");
                if(emisores == null)
                {
                    return new List<Emisor>();
                }
                return emisores;
            } 
            catch (Exception ex)
            {
                return new List<Emisor>();
            }
        }
    }
}
