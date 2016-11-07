using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int FriendshipId { get; set; }
        public virtual Friendship Friendship { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        [Required]
        public string Content { get; set; }
        [Index]
        public DateTime SentOn { get; set; }
        public DateTime? SeenOn { get; set; }
    }
}