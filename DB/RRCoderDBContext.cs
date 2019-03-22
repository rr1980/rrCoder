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
        public DbSet<User> Users { get; set; }

        public RRCoderDBContext(DbContextOptions<RRCoderDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema(schema: "rrCoder");

            modelBuilder.Entity<ModifiedEntity>(entity =>
            {
                entity.HasOne(d => d.ModifiedUser)
                    .WithMany(p => p.ModifiedEntity);
            });

            modelBuilder.Entity<Bemerkung>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bemerkungen);
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
            User user = null;
            var _uId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            if (!string.IsNullOrEmpty(_uId))
            {
                var uId = long.Parse(_uId);
                user = Users.FirstOrDefault(x => x.Id == uId);
            }


            var entries = ChangeTracker.Entries().Where(x => x.Entity is ModifiedEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (user != null)
                {
                    ((ModifiedEntity)entry.Entity).ModifiedUser = user;
                    //user.ModifiedEntity.Add(((ModifiedEntity)entry.Entity));
                }

                if (entry.State == EntityState.Added)
                {
                    ((ModifiedEntity)entry.Entity).Created = DateTime.UtcNow;
                }

            ((ModifiedEntity)entry.Entity).Modified = DateTime.UtcNow;

            }
        }
    }
}
