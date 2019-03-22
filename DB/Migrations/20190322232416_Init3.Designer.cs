﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(RRCoderDBContext))]
    [Migration("20190322232416_Init3")]
    partial class Init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("rrCoder")
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.ModifiedEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<DateTime?>("Modified");

                    b.Property<int?>("ModifiedUserId");

                    b.HasKey("Id");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("ModifiedEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ModifiedEntity");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Bemerkung", b =>
                {
                    b.HasBaseType("Entities.ModifiedEntity");

                    b.Property<string>("Betreff");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Bemerkung");
                });

            modelBuilder.Entity("Entities.ModifiedEntity", b =>
                {
                    b.HasOne("Entities.User", "ModifiedUser")
                        .WithMany("ModifiedEntity")
                        .HasForeignKey("ModifiedUserId");
                });

            modelBuilder.Entity("Entities.Bemerkung", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Bemerkungen")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
