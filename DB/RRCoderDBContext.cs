using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DB
{
    public partial class RRCoderDBContext : DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;

        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Bemerkung> Bemerkungen { get; set; }
        public DbSet<CodeSnippet> CodeSnippets { get; set; }
        public DbSet<CodeContent> CodeContents { get; set; }

        public RRCoderDBContext(DbContextOptions<RRCoderDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(schema: "rrCoder");

            modelBuilder.Entity<CodeSnippet>(entity =>
            {
                entity.ToTable("CodeSnippet");

                entity.HasOne(d => d.Erstellt_User)
                    .WithMany(p => p.Erstellt_CodeSnippets);

                entity.HasOne(c => c.Geaendert_User)
                    .WithMany(b => b.Geaenderte_CodeSnippets);
            });

            modelBuilder.Entity<CodeContent>(entity =>
            {
                entity.ToTable("CodeContent");

                entity.HasOne(d => d.Erstellt_User)
                    .WithMany(p => p.Erstellt_CodeContents);

                entity.HasOne(c => c.Geaendert_User)
                    .WithMany(b => b.Geaenderte_CodeContents);
            });

            modelBuilder.Entity<Bemerkung>(entity =>
            {
                entity.ToTable("Bemerkung");

                entity.HasOne(d => d.Erstellt_User)
                    .WithMany(p => p.Erstellt_Bemerkungen);

                entity.HasOne(c => c.Geaendert_User)
                    .WithMany(b => b.Geaenderte_Bemerkungen);

                entity.HasOne(d => d.CodeSnippet)
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

            var entries = ChangeTracker.Entries().Where(x => x.Entity is ModifiablEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = ((ModifiablEntity)entry.Entity);

                if (entry.State == EntityState.Added)
                {
                    if (user != null)
                    {
                        entity.Erstellt_User = user;
                        entity.Erstellt_Datum = DateTime.UtcNow;
                    }
                }

                if (user != null)
                {
                    entity.Geaendert_User = user;
                }

                entity.Geaendert_Datum = DateTime.UtcNow;
            }
        }
    }
}
