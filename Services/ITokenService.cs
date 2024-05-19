using APIProducao.Models;

namespace APIProducao.Services
{
    public interface ITokenService
    {
        string GerarToken(string key, string issuer, string audience, Usuario user);
    }
}
