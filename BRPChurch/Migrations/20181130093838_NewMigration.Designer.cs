﻿// <auto-generated />
using BRPChurch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BRPChurch.Migrations
{
    [DbContext(typeof(BRPChurchContext))]
    [Migration("20181130093838_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BRPChurch.Models.Activities", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("BRPChurch.Models.ActivityTag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TagID");

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<int>("ActivityTypeId")
                        .HasColumnName("ActivityTypeID");

                    b.HasKey("TagId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ActivityTypeId");

                    b.ToTable("ActivityTag");
                });

            modelBuilder.Entity("BRPChurch.Models.ActivityType", b =>
                {
                    b.Property<int>("ActivityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityTypeID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ActivityTypeId");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BRPChurch.Models.Events", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EventID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BRPChurch.Models.FinanceEntry", b =>
                {
                    b.Property<int>("FinanceEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FinanceEntryID");

                    b.Property<double>("Amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("FinanceTypeId")
                        .HasColumnName("FinanceTypeID");

                    b.HasKey("FinanceEntryId");

                    b.HasIndex("FinanceTypeId");

                    b.ToTable("FinanceEntry");
                });

            modelBuilder.Entity("BRPChurch.Models.FinanceType", b =>
                {
                    b.Property<int>("FinanceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FinanceTypeID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("Type");

                    b.HasKey("FinanceTypeId");

                    b.ToTable("FinanceType");
                });

            modelBuilder.Entity("BRPChurch.Models.Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MemberID");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("PhoneNo");

                    b.Property<int>("PostNo");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserId");

                    b.HasKey("MemberId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("BRPChurch.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date");

                    b.Property<string>("description");

                    b.Property<string>("email");

                    b.Property<string>("path");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("BRPChurch.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ServiceID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Leader")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ServiceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("BRPChurch.Models.ServiceWorship", b =>
                {
                    b.Property<int>("ServiceWorshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ServiceWorshipID");

                    b.Property<int>("ServiceId")
                        .HasColumnName("ServiceID");

                    b.Property<int>("WorshipId")
                        .HasColumnName("WorshipID");

                    b.HasKey("ServiceWorshipId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("WorshipId");

                    b.ToTable("ServiceWorship");
                });

            modelBuilder.Entity("BRPChurch.Models.Worship", b =>
                {
                    b.Property<int>("WorshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorshipID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("WorshipTypeId")
                        .HasColumnName("WorshipTypeID");

                    b.HasKey("WorshipId");

                    b.HasIndex("WorshipTypeId");

                    b.ToTable("Worship");
                });

            modelBuilder.Entity("BRPChurch.Models.WorshipType", b =>
                {
                    b.Property<int>("WorshipTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorshipTypeID");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("WorshipTypeId");

                    b.ToTable("WorshipType");
                });

            modelBuilder.Entity("BRPChurch.Models.ActivityTag", b =>
                {
                    b.HasOne("BRPChurch.Models.Activities", "Activity")
                        .WithMany("ActivityTag")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_259");

                    b.HasOne("BRPChurch.Models.ActivityType", "ActivityType")
                        .WithMany("ActivityTag")
                        .HasForeignKey("ActivityTypeId")
                        .HasConstraintName("FK_262");
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("BRPChurch.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("BRPChurch.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("BRPChurch.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRPChurch.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("BRPChurch.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BRPChurch.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BRPChurch.Models.FinanceEntry", b =>
                {
                    b.HasOne("BRPChurch.Models.FinanceType", "FinanceType")
                        .WithMany("FinanceEntry")
                        .HasForeignKey("FinanceTypeId")
                        .HasConstraintName("FK_288");
                });

            modelBuilder.Entity("BRPChurch.Models.Members", b =>
                {
                    b.HasOne("BRPChurch.Models.AspNetUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BRPChurch.Models.ServiceWorship", b =>
                {
                    b.HasOne("BRPChurch.Models.Service", "Service")
                        .WithMany("ServiceWorship")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_280");

                    b.HasOne("BRPChurch.Models.Worship", "Worship")
                        .WithMany("ServiceWorship")
                        .HasForeignKey("WorshipId")
                        .HasConstraintName("FK_277");
                });

            modelBuilder.Entity("BRPChurch.Models.Worship", b =>
                {
                    b.HasOne("BRPChurch.Models.WorshipType", "WorshipType")
                        .WithMany("Worship")
                        .HasForeignKey("WorshipTypeId")
                        .HasConstraintName("FK_269");
                });
#pragma warning restore 612, 618
        }
    }
}
