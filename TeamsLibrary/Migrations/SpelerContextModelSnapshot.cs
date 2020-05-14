﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamsLibrary;

namespace TeamsLibrary.Migrations
{
    [DbContext(typeof(SpelerContext))]
    partial class SpelerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamsLibrary.Speler", b =>
                {
                    b.Property<int>("SpelerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RugNummer")
                        .HasColumnType("int");

                    b.Property<int>("TeamStamNummer")
                        .HasColumnType("int");

                    b.Property<int>("TransferWaarde")
                        .HasColumnType("int");

                    b.HasKey("SpelerID");

                    b.HasIndex("TeamStamNummer");

                    b.ToTable("Spelers");
                });

            modelBuilder.Entity("TeamsLibrary.Team", b =>
                {
                    b.Property<int>("StamNummer")
                        .HasColumnType("int");

                    b.Property<string>("Bijnaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trainer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StamNummer");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TeamsLibrary.Transfer", b =>
                {
                    b.Property<int>("TransferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NieuwTeamStamNummer")
                        .HasColumnType("int");

                    b.Property<int>("OudTeamStamNummer")
                        .HasColumnType("int");

                    b.Property<int>("SpelerID")
                        .HasColumnType("int");

                    b.Property<int>("TransferPrijs")
                        .HasColumnType("int");

                    b.HasKey("TransferID");

                    b.HasIndex("NieuwTeamStamNummer");

                    b.HasIndex("OudTeamStamNummer");

                    b.HasIndex("SpelerID");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("TeamsLibrary.Speler", b =>
                {
                    b.HasOne("TeamsLibrary.Team", "Team")
                        .WithMany("Spelers")
                        .HasForeignKey("TeamStamNummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamsLibrary.Transfer", b =>
                {
                    b.HasOne("TeamsLibrary.Team", "NieuwTeam")
                        .WithMany()
                        .HasForeignKey("NieuwTeamStamNummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamsLibrary.Team", "OudTeam")
                        .WithMany()
                        .HasForeignKey("OudTeamStamNummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamsLibrary.Speler", "Speler")
                        .WithMany()
                        .HasForeignKey("SpelerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
