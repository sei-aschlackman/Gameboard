﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Gameboard.Api.Data.Migrations.PostgreSQL.GameboardDb
{
    [DbContext(typeof(GameboardDbContextPostgreSQL))]
    partial class GameboardDbContextPostgreSQLModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gameboard.Api.Data.ArchivedChallenge", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Events")
                        .HasColumnType("text");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GameName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<bool>("HasGamespaceDeployed")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastScoreTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastSyncTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("PlayerName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Submissions")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("TeamMembers")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

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
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GraderKey")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<bool>("HasDeployedGamespace")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastScoreTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastSyncTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<string>("SpecId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("WhenCreated")
                        .HasColumnType("timestamp with time zone");

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
                        .HasColumnType("character varying(40)");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Text")
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.ToTable("ChallengeEvents");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeGate", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("RequiredId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<double>("RequiredScore")
                        .HasColumnType("double precision");

                    b.Property<string>("TargetId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ChallengeGates");
                });

            modelBuilder.Entity("Gameboard.Api.Data.ChallengeSpec", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("AverageDeploySeconds")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<float>("R")
                        .HasColumnType("real");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

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
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Answers")
                        .HasColumnType("text");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("ChallengeSpecId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("Submitted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

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
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("AllowPreview")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllowReset")
                        .HasColumnType("boolean");

                    b.Property<string>("Background")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("CardText1")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("CardText2")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("CardText3")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("CertificateTemplate")
                        .HasColumnType("text");

                    b.Property<string>("Competition")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Division")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("FeedbackConfig")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("GameEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GameMarkdown")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("GameStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GamespaceLimitPerSession")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Logo")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("MaxAttempts")
                        .HasColumnType("integer");

                    b.Property<int>("MaxTeamSize")
                        .HasColumnType("integer");

                    b.Property<int>("MinTeamSize")
                        .HasColumnType("integer");

                    b.Property<string>("Mode")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTimeOffset>("RegistrationClose")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RegistrationConstraint")
                        .HasColumnType("text");

                    b.Property<string>("RegistrationMarkdown")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("RegistrationOpen")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RegistrationType")
                        .HasColumnType("integer");

                    b.Property<bool>("RequireSponsoredTeam")
                        .HasColumnType("boolean");

                    b.Property<string>("Season")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("SessionLimit")
                        .HasColumnType("integer");

                    b.Property<int>("SessionMinutes")
                        .HasColumnType("integer");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("TestCode")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Track")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("Advanced")
                        .HasColumnType("boolean");

                    b.Property<string>("ApprovedName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("CorrectCount")
                        .HasColumnType("integer");

                    b.Property<string>("GameId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("InviteCode")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("NameStatus")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("PartialCount")
                        .HasColumnType("integer");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("SessionBegin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("SessionEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SessionMinutes")
                        .HasColumnType("integer");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("TeamSponsors")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long>("Time")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

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
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Gameboard.Api.Data.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("AssigneeId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Attachments")
                        .HasColumnType("text");

                    b.Property<string>("ChallengeId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatorId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Key"));

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PlayerId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("RequesterId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<bool>("StaffCreated")
                        .HasColumnType("boolean");

                    b.Property<string>("Status")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("TeamId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

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
                        .HasColumnType("text");

                    b.Property<string>("AssigneeId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Attachments")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("TicketId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

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
                        .HasColumnType("character varying(40)");

                    b.Property<string>("ApprovedName")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Email")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("NameStatus")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Sponsor")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Username")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

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
