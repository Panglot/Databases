using SocialNetwork.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNetwork.Data
{
    public class SocialNetworkDBContext:DbContext
    {
        public SocialNetworkDBContext()
            : base("SocialNetwork")
        {        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Friendship> Friendships { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
