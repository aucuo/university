using Microsoft.EntityFrameworkCore;

namespace server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientFeedback> ClientFeedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(u => u.ClientID);
                entity.Property(u => u.Name);
                entity.Property(u => u.Industry);
                entity.Property(u => u.ContactPerson);
                entity.Property(u => u.Email);
                entity.Property(u => u.Phone);
            });

            modelBuilder.Entity<ClientFeedback>(entity =>
            {
                entity.HasKey(u => u.FeedbackID);
                entity.HasKey(u => u.ProjectID);
                entity.HasKey(u => u.ClientID);
                entity.Property(u => u.Date);
                entity.Property(u => u.Text);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientFeedback)
                    .HasForeignKey(d => d.ClientID);
            });
        }
    }
}