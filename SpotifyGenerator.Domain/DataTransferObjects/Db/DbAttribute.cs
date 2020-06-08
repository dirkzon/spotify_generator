using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpotifyGenerator.Domain.DataTransferObjects
{
    public class DbAttribute
    {
        [Key]
        [Required]
        public string Attribute { get; set; }
    }
}
