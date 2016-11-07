using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int FriendshipId { get; set; }
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }
        public int RecieverId { get; set; }
        public virtual User Reciever { get; set; }
        [Index]
        public bool Approved { get; set; }
        public DateTime FriendsSince { get; set; }
        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }
    }
}