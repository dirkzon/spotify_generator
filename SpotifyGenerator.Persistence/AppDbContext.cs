using Microsoft.EntityFrameworkCore;
using SpotifyGenerator.Domain.DataTransferObjects;

namespace SpotifyGenerator.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
        }

        //lijst van gebruikers
        public DbSet<DbUserDTO> Users { get; set; }

        //lijst van eerder gemaakte playlists
        public DbSet<DbPlaylistDTO> Playlists { get; set; }

        //lijst van attributes
        public DbSet<DbAttribute> Attributes { get; set; }
        
        //lijst van vragen
        public DbSet<DbQuestionDTO> Questions { get; set; }
    }
}
