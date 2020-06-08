using SpotifyGenerator.Domain.DataTransferObjects;

namespace SpotifyGenerator.Domain.interfaces
{
    public interface ISqlUserRepository
    {
        DbUserDTO GetUser(string id);
        DbUserDTO SaveUser(DbUserDTO user);
    }
}
