﻿using Entities;
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

            if (!context.Benutzer.Any())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "seed_users.json");
                var users = JsonConvert.DeserializeObject<List<Benutzer>>(File.ReadAllText(path));
                context.AddRange(users);
                context.SaveChanges();
            }

            if (!context.CodeContents.Any())
            {
                var cc = new CodeContent
                {
                    Betreff = "C#",
                    Text = "Test",
                    //Benutzer = context.Benutzer.FirstOrDefault()
                };

                //cc.Bemerkungen.Add(new Bemerkung
                //{
                //    Betreff = "Information",
                //    Text = "Test",
                //    //User = context.Benutzer.FirstOrDefault()
                //});

                context.AddRange(cc);
                context.SaveChanges();
            }
        }
    }
}
