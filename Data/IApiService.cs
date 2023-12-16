using Interfaz_Login.Models;

namespace Interfaz_Login.Data
{
    public interface IApiService
    {
        public Task<List<Emisor>> emisors();
        public Task<Usuario> login(int user, string contrasenia);
    }
}
