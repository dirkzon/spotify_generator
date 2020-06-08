using System.Threading.Tasks;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface ITokenAccess
    {
        public Task<string> GetAccessToken(string code, string redirect);
    }
}
