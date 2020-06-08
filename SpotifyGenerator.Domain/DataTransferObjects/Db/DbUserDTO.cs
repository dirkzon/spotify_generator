using System.ComponentModel.DataAnnotations;

namespace SpotifyGenerator.Domain.DataTransferObjects
{
    public class DbUserDTO
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
    }
}
