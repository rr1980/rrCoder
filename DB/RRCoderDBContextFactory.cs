using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DB
{
    public class RRCoderDBContextFactory
    {
        public RRCoderDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RRCoderDBContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=rrCoderDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RRCoderDBContext(builder.Options, null);
        }
    }

    public static class RRCoderDBContextExtension
    {

        public static bool AllMigrationsApplied(this RRCoderDBContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this RRCoderDBContext context)
        {

            if (!context.Users.Any())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "seed_users.json");
                var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
