using Common;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DB
{
    public partial class RRCoderDBContext : DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;

        //public DbSet<BaseEntity> BaseEntity { get; set; }

        public DbSet<Aenderungen> Aenderungen { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Bemerkung> Bemerkungen { get; set; }
        public DbSet<CodeContent> CodeContents { get; set; }

        public RRCoderDBContext(DbContextOptions<RRCoderDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(schema: "rrCoder");

            modelBuilder.Ignore<BaseEntity>();

            modelBuilder.Entity<Aenderungen>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.AusgefuehrteAenderungen);

                entity.HasOne(d => d.CodeContent)
                    .WithMany(p => p.Aenderungen);

                entity.HasOne(d => d.Bemerkung)
                    .WithMany(p => p.Aenderungen);
            });

            modelBuilder.Entity<CodeContent>(entity =>
            {
                entity.ToTable("CodeContent");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CodeContent);
            });

            modelBuilder.Entity<Bemerkung>(entity =>
            {
                entity.ToTable("Bemerkung");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bemerkungen);

                entity.HasOne(d => d.CodeContent)
                    .WithMany(p => p.Bemerkungen);
            });

            modelBuilder.Entity<Benutzer>(entity =>
            {
                entity.ToTable("User");
            });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            AddAuitInfo();
            await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            Benutzer user = null;
            var _uId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;
            if (!string.IsNullOrEmpty(_uId))
            {
                var uId = long.Parse(_uId);
                user = Benutzer.FirstOrDefault(x => x.Id == uId);
            }

            var entries = ChangeTracker.Entries().Where(x => x.Entity is IModifiable<Aenderungen, Benutzer> && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = ((IModifiable<Aenderungen, Benutzer>)entry.Entity);

                if (entry.State == EntityState.Added)
                {
                    entity.AddAenderung(EntityAenderungenType.Erstellt, user);
                }
                else
                {
                    entity.AddAenderung(EntityAenderungenType.Modifiziert, user);
                }
                //((Aenderungen)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
