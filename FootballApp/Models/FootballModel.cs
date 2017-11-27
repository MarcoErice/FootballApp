namespace FootballApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FootballModel : DbContext
    {
        public FootballModel()
            : base("name=FootballModel")
        {
        }

        public virtual DbSet<Arenas> Arenas { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arenas>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Arenas)
                .HasForeignKey(e => e.Arena_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.GuestTeam_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Matches1)
                .WithRequired(e => e.Teams1)
                .HasForeignKey(e => e.HomeTeam_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Players)
                .WithRequired(e => e.Teams)
                .HasForeignKey(e => e.Team_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
