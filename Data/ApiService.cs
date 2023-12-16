using Interfaz_Login.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Interfaz_Login.Data
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiRoute = "http://apiservicios.ecuasolmovsa.com:3009/api";

        public ApiService() { 
            _httpClient = new HttpClient();
        }
        public async Task<List<Emisor>> emisors()
        {
            List<Emisor> emisores;
            try
            {
                emisores = await _httpClient.GetFromJsonAsync<List<Emisor>>(_apiRoute + "/Varios/GetEmisor");
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

        public async Task<Usuario> login(int user, string contrasenia)
        {
            List<Usuario> usuarios;
            Usuario usuario;
            try
            {
                usuarios = await _httpClient.GetFromJsonAsync<List<Usuario>>(_apiRoute + "/Usuarios?usuario=" + user + "&password=" + contrasenia);
                usuario = usuarios.FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
