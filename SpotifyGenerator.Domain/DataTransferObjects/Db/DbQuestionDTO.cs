using System.ComponentModel.DataAnnotations;

namespace SpotifyGenerator.Domain.DataTransferObjects
{
    public class DbQuestionDTO
    {
        [Key]
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public string Attribute { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
