﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MonDbContext))]
    [Migration("20200626151228_AvisCleEtrangere")]
    partial class AvisCleEtrangere
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Avis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Commentaire")
                        .HasMaxLength(2000);

                    b.Property<int>("FormationId");

                    b.Property<string>("NomUtilisateur")
                        .IsRequired();

                    b.Property<double>("Note");

                    b.HasKey("Id");

                    b.HasIndex("FormationId");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("Data.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<string>("NomSeo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Formations");
                });

            modelBuilder.Entity("Data.Avis", b =>
                {
                    b.HasOne("Data.Formation", "Formation")
                        .WithMany("Avis")
                        .HasForeignKey("FormationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}