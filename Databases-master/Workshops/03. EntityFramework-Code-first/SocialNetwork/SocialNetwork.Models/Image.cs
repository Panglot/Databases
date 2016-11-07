using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [MaxLength(4)]
        [Required]
        public string FileExtension { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}