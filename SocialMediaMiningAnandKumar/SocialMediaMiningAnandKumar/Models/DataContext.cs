namespace SocialMediaMiningAnandKumar.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SocialMedia;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Phrase> Phrases { get; set; }
        public virtual DbSet<Word> Words { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<V_NumberOfLikes> V_NumberOfLikes { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasMany(e => e.Phrases)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);
        }
    }
}
