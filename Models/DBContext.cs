namespace DropTokenApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Player> Players { get; set; }
       // public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
       /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Player)
                .HasForeignKey(e => e.Player1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.Games1)
                .WithRequired(e => e.Player3)
                .HasForeignKey(e => e.Player2)
                .WillCascadeOnDelete(false);
        }
        */
    }
}
