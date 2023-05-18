﻿// <auto-generated />
using System;
using Coursework.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NFL.DAO;

#nullable disable

namespace NFL.DAO.Migrations
{
    [DbContext(typeof(CourseworkApplicationContext))]
    [Migration("20230508161611_AddedProperty-FavoriteTeam")]
    partial class AddedPropertyFavoriteTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Tables.City", b =>
                {
                    b.Property<short>("CityCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("CityCode"), 1L, 1);

                    b.Property<string>("CityStateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("CityTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityCode");

                    b.HasIndex("CityStateId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Conference", b =>
                {
                    b.Property<byte>("ConferenceId")
                        .HasColumnType("tinyint");

                    b.Property<string>("ConferenceColor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<byte?>("ConferenceLevel")
                        .HasColumnType("tinyint");

                    b.Property<string>("ConferenceName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("ConferenceId");

                    b.HasAlternateKey("ConferenceName");

                    b.HasIndex("ConferenceLevel");

                    b.ToTable("Conferences", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MatchID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"), 1L, 1);

                    b.Property<string>("AwayTeamCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("AwayTeam");

                    b.Property<string>("HomeTeamCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("HomeTeam");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("date");

                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint")
                        .HasColumnName("Stadium");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayTeamCode");

                    b.HasIndex("HomeTeamCode");

                    b.HasIndex("StadiumId");

                    b.ToTable("Matches", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.MatchResult", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<string>("MatchLoserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("MatchWinnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<byte>("OvertimesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)0);

                    b.HasKey("MatchId");

                    b.HasIndex("MatchLoserId");

                    b.HasIndex("MatchWinnerId");

                    b.ToTable("ResultsOfMatches", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.NationalDivision", b =>
                {
                    b.Property<byte>("DivisionId")
                        .HasColumnType("tinyint");

                    b.Property<string>("DivisionTitle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("DivisionId");

                    b.ToTable("NationalDivisions", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.SocialNetworkAccount", b =>
                {
                    b.Property<string>("TeamAbbreviation")
                        .HasColumnType("nvarchar(5)");

                    b.Property<byte>("AccountTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("AccountAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeamAbbreviation", "AccountTypeId");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("SocialNetworkAccounts", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.SocialNetworkAccountType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Description");

                    b.ToTable("SocialNetworkAccountTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Description = "TeamSite"
                        },
                        new
                        {
                            Id = (byte)2,
                            Description = "TwitterAccount"
                        },
                        new
                        {
                            Id = (byte)3,
                            Description = "FacebookPage"
                        });
                });

            modelBuilder.Entity("Entities.Tables.Stadium", b =>
                {
                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint");

                    b.Property<short>("StadiumLocationId")
                        .HasColumnType("smallint")
                        .HasColumnName("StadiumLocation");

                    b.Property<string>("StadiumTitle")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("StadiumId");

                    b.HasAlternateKey("StadiumTitle", "StadiumLocationId");

                    b.HasIndex("StadiumLocationId");

                    b.ToTable("Stadiums", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.State", b =>
                {
                    b.Property<string>("StateCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("StateTitle")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("StateCode");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.Team", b =>
                {
                    b.Property<string>("TeamAbbreviation")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("ConferenceId")
                        .HasColumnType("tinyint");

                    b.Property<short>("StadiumId")
                        .HasColumnType("smallint");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<short?>("TeamRank")
                        .HasColumnType("smallint");

                    b.Property<string>("TeamRegion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamAbbreviation");

                    b.HasIndex("ConferenceId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.TeamColor", b =>
                {
                    b.Property<string>("TeamAbbreviation")
                        .HasColumnType("nvarchar(5)");

                    b.Property<byte>("ColorNumber")
                        .HasColumnType("tinyint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("TeamAbbreviation", "ColorNumber");

                    b.ToTable("teamColors", (string)null);
                });

            modelBuilder.Entity("Entities.Tables.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FavoriteTeamAbbreviation")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("FavoriteTeam");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UserId");

                    b.HasAlternateKey("Email");

                    b.HasIndex("FavoriteTeamAbbreviation");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Entities.Views.TeamStandings", b =>
                {
                    b.Property<int>("L")
                        .HasColumnType("int");

                    b.Property<string>("TeamAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("W")
                        .HasColumnType("int");

                    b.ToView("TeamStandings");
                });

            modelBuilder.Entity("Entities.Tables.City", b =>
                {
                    b.HasOne("Entities.Tables.State", "CityState")
                        .WithMany("Cities")
                        .HasForeignKey("CityStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityState");
                });

            modelBuilder.Entity("Entities.Tables.Conference", b =>
                {
                    b.HasOne("Entities.Tables.NationalDivision", "Division")
                        .WithMany("Conferences")
                        .HasForeignKey("ConferenceLevel");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("Entities.Tables.Match", b =>
                {
                    b.HasOne("Entities.Tables.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Tables.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Tables.Stadium", "Stadium")
                        .WithMany("MatchesPlayedInThisStadium")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Entities.Tables.MatchResult", b =>
                {
                    b.HasOne("Entities.Tables.Match", "Match")
                        .WithOne("MatchResult")
                        .HasForeignKey("Entities.Tables.MatchResult", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Tables.Team", "MatchLoser")
                        .WithMany("MatchLosers")
                        .HasForeignKey("MatchLoserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Tables.Team", "MatchWinner")
                        .WithMany("MatchWinners")
                        .HasForeignKey("MatchWinnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("MatchLoser");

                    b.Navigation("MatchWinner");
                });

            modelBuilder.Entity("Entities.Tables.SocialNetworkAccount", b =>
                {
                    b.HasOne("Entities.Tables.SocialNetworkAccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Tables.Team", "Team")
                        .WithMany("SocialNetworkAccounts")
                        .HasForeignKey("TeamAbbreviation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Entities.Tables.Stadium", b =>
                {
                    b.HasOne("Entities.Tables.City", "StadiumLocation")
                        .WithMany("Stadiums")
                        .HasForeignKey("StadiumLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StadiumLocation");
                });

            modelBuilder.Entity("Entities.Tables.Team", b =>
                {
                    b.HasOne("Entities.Tables.Conference", "Conference")
                        .WithMany("Teams")
                        .HasForeignKey("ConferenceId")
                        .IsRequired();

                    b.HasOne("Entities.Tables.Stadium", "Stadium")
                        .WithMany("Teams")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Entities.Tables.TeamColor", b =>
                {
                    b.HasOne("Entities.Tables.Team", "Team")
                        .WithMany("Colors")
                        .HasForeignKey("TeamAbbreviation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Entities.Tables.User", b =>
                {
                    b.HasOne("Entities.Tables.Team", "FavoriteTeam")
                        .WithMany("Users")
                        .HasForeignKey("FavoriteTeamAbbreviation")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("FavoriteTeam");
                });

            modelBuilder.Entity("Entities.Tables.City", b =>
                {
                    b.Navigation("Stadiums");
                });

            modelBuilder.Entity("Entities.Tables.Conference", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Entities.Tables.Match", b =>
                {
                    b.Navigation("MatchResult")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Tables.NationalDivision", b =>
                {
                    b.Navigation("Conferences");
                });

            modelBuilder.Entity("Entities.Tables.SocialNetworkAccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Entities.Tables.Stadium", b =>
                {
                    b.Navigation("MatchesPlayedInThisStadium");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Entities.Tables.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Entities.Tables.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("Colors");

                    b.Navigation("HomeMatches");

                    b.Navigation("MatchLosers");

                    b.Navigation("MatchWinners");

                    b.Navigation("SocialNetworkAccounts");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
