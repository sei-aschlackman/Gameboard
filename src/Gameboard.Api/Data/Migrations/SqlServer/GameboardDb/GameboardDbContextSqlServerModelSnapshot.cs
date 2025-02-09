﻿// <auto-generated />
using System;
using Gameboard.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gameboard.Api.Data.Migrations.SqlServer.GameboardDb
{
    [DbContext(typeof(GameboardDbContextSqlServer))]
    partial class GameboardDbContextSqlServerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gameboard.Api.Data.ArchivedChallenge", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Events")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GameName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("HasGamespaceDeployed")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastScoreTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastSyncTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PlayerName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Submissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TeamMembers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("ArchivedChallenges");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Challenge", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GraderKey")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("HasDeployedGamespace")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastScoreTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastSyncTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("SpecId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("WhenCreated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Text")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("ChallengeEvents");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeGate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RequiredId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double>("RequiredScore")
                        .HasColumnType("float");

                    b.Property<string>("TargetId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ChallengeGates");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeSpec", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("AverageDeploySeconds")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<float>("R")
                        .HasColumnType("real");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("X")
                        .HasColumnType("real");

                    b.Property<float>("Y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ChallengeSpecs");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Answers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ChallengeSpecId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Submitted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("ChallengeSpecId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("AllowPreview")
                        .HasColumnType("bit");

                    b.Property<bool>("AllowReset")
                        .HasColumnType("bit");

                    b.Property<string>("Background")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("CardText1")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("CardText2")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("CardText3")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("CertificateTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Competition")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Division")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FeedbackConfig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("GameEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("GameMarkdown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("GameStart")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("GamespaceLimitPerSession")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Logo")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("MaxAttempts")
                        .HasColumnType("int");

                    b.Property<int>("MaxTeamSize")
                        .HasColumnType("int");

                    b.Property<int>("MinTeamSize")
                        .HasColumnType("int");

                    b.Property<string>("Mode")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTimeOffset>("RegistrationClose")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RegistrationConstraint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationMarkdown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("RegistrationOpen")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RegistrationType")
                        .HasColumnType("int");

                    b.Property<bool>("RequireSponsoredTeam")
                        .HasColumnType("bit");

                    b.Property<string>("Season")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("SessionLimit")
                        .HasColumnType("int");

                    b.Property<int>("SessionMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TestCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Track")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Advanced")
                        .HasColumnType("bit");

                    b.Property<string>("ApprovedName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("CorrectCount")
                        .HasColumnType("int");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("InviteCode")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("NameStatus")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("PartialCount")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("SessionBegin")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("SessionEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("SessionMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("TeamSponsors")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Sponsor", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("AssigneeId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Attachments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatorId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Key")
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("RequesterId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("StaffCreated")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.HasIndex("PlayerId");

                    b.HasIndex("RequesterId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Gameboard.Api.Data.TicketActivity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssigneeId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Attachments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TicketId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("TicketActivity");
                });

            modelBuilder.Entity("Gameboard.Api.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ApprovedName")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("NameStatus")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Username")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Challenge", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Game", "Game")
                        .WithMany("Challenges")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gameboard.Api.Data.Player", "Player")
                        .WithMany("Challenges")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeEvent", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Challenge", "Challenge")
                        .WithMany("Events")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Challenge");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeGate", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Game", "Game")
                        .WithMany("Prerequisites")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeSpec", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Game", "Game")
                        .WithMany("Specs")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Feedback", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Challenge", "Challenge")
                        .WithMany("Feedback")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameboard.Api.Data.ChallengeSpec", "ChallengeSpec")
                        .WithMany("Feedback")
                        .HasForeignKey("ChallengeSpecId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameboard.Api.Data.Game", "Game")
                        .WithMany("Feedback")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameboard.Api.Data.Player", "Player")
                        .WithMany("Feedback")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameboard.Api.Data.User", "User")
                        .WithMany("Feedback")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Challenge");

                    b.Navigation("ChallengeSpec");

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Player", b =>
                {
                    b.HasOne("Gameboard.Api.Data.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");

                    b.HasOne("Gameboard.Api.Data.User", "User")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Ticket", b =>
                {
                    b.HasOne("Gameboard.Api.Data.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Gameboard.Api.Data.Challenge", "Challenge")
                        .WithMany("Tickets")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gameboard.Api.Data.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Gameboard.Api.Data.Player", "Player")
                        .WithMany("Tickets")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gameboard.Api.Data.User", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId");

                    b.Navigation("Assignee");

                    b.Navigation("Challenge");

                    b.Navigation("Creator");

                    b.Navigation("Player");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("Gameboard.Api.Data.TicketActivity", b =>
                {
                    b.HasOne("Gameboard.Api.Data.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Gameboard.Api.Data.Ticket", "Ticket")
                        .WithMany("Activity")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gameboard.Api.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Assignee");

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Challenge", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Feedback");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeSpec", b =>
                {
                    b.Navigation("Feedback");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Game", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("Feedback");

                    b.Navigation("Players");

                    b.Navigation("Prerequisites");

                    b.Navigation("Specs");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Player", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("Feedback");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Ticket", b =>
                {
                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Gameboard.Api.Data.User", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
