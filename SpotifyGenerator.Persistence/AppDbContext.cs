using Microsoft.EntityFrameworkCore;
using SpotifyGenerator.Domain.DataTransferObjects;

namespace SpotifyGenerator.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
        }

        public DbSet<DbUserDTO> Users { get; set; }

        public DbSet<DbPlaylistDTO> Playlists { get; set; }

        public DbSet<DbAttribute> Attributes { get; set; }

        public DbSet<DbQuestionDTO> Questions { get; set; }
    }
}
