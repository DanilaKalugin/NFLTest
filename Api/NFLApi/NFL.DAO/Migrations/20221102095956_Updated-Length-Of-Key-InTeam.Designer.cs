﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NFL.DAO;

#nullable disable

namespace NFL.DAO.Migrations
{
    [DbContext(typeof(NFLApplicationContext))]
    [Migration("20221102095956_Updated-Length-Of-Key-InTeam")]
    partial class UpdatedLengthOfKeyInTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Tables.Division", b =>
                {
                    b.Property<byte>("Number")
                        .HasColumnType("tinyint")
                        .HasColumnName("DivisionNumber");

                    b.Property<string>("DivisionTitle")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Number");

                    b.ToTable("Divisions", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Stadium", b =>
                {
                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint");

                    b.Property<string>("StadiumLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StadiumTitle")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("StadiumId");

                    b.HasAlternateKey("StadiumTitle");

                    b.ToTable("Stadiums", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Team", b =>
                {
                    b.Property<string>("TeamAbbreviation")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("DivisionID")
                        .HasColumnType("tinyint")
                        .HasColumnName("TeamDivision");

                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("TeamRegion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamAbbreviation");

                    b.HasIndex("DivisionID");

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Team", b =>
                {
                    b.HasOne("Entities.Tables.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionID")
                        .IsRequired();

                    b.HasOne("Entities.Tables.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Entities.Tables.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Entities.Tables.Stadium", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
