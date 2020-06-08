using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface ITokenService
    {
        public Task<string> GetToken(string code, string redirect);
    }
}
