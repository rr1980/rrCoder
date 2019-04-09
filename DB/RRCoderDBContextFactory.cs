using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System;
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

            if (!context.Benutzer.Any())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "seed_users.json");
                var users = JsonConvert.DeserializeObject<List<Benutzer>>(File.ReadAllText(path));
                context.AddRange(users);
                context.SaveChanges();

                var user = users.FirstOrDefault();

                // -----

                var cs = new CodeSnippet
                {
                    Name = "C#",
                    Beschreibung = "abc",
                };

                cs.Geaendert_User = user;
                cs.Erstellt_User = user;
                cs.Erstellt_Datum = DateTime.Now;

                // -----

                var b1 = new Bemerkung
                {
                    Betreff = "Information",
                    Text = "Test",
                };

                b1.Geaendert_User = user;
                b1.Erstellt_User = user;
                b1.Erstellt_Datum = DateTime.Now;

                cs.Bemerkungen.Add(b1);

                // -----

                var cc = new CodeContent
                {
                    Name = "C#",
                    Beschreibung = "abc",
                    Content = "Test",
                };

                cc.Geaendert_User = user;
                cc.Erstellt_User = user;
                cc.Erstellt_Datum = DateTime.Now;

                cs.CodeContents.Add(cc);

                // -----

                var b2 = new Bemerkung
                {
                    Betreff = "Information",
                    Text = "Test",
                };

                b2.Geaendert_User = user;
                b2.Erstellt_User = user;
                b2.Erstellt_Datum = DateTime.Now;

                cc.Bemerkungen.Add(b2);

                // -----

                context.Add(cs);
                context.SaveChanges();
            }
        }
    }
}
