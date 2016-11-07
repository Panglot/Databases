using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        private ICollection<Image> images;
        private ICollection<Message> messages;
        private ICollection<Post> posts;

        public User()
        {
            this.images = new HashSet<Image>();
            this.messages = new HashSet<Message>();
            this.posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        [Index(IsUnique = true)]
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }
        [StringLength(50,ErrorMessage ="name is too big", MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage ="Name is out of range",MinimumLength =2)]
        public string LastName { get; set; }
        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

    }
}
