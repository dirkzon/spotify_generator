using System;
using System.ComponentModel.DataAnnotations;

namespace SpotifyGenerator.Domain.DataTransferObjects
{
    public class DbPlaylistDTO
    {
        [Required]
        [MaxLength(75)]
        public string PlaylistName { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserId { get; set; }
        [Key]
        [Required]
        [MaxLength(22)]
        public string PlaylistId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
