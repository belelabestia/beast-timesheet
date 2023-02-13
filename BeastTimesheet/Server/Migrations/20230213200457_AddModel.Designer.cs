﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeastTimesheet.Server.Migrations
{
    [DbContext(typeof(BeastTimesheetContext))]
    [Migration("20230213200457_AddModel")]
    partial class AddModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Payed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("HourlyFee")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("BreaksTime")
                        .HasColumnType("interval");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("StopTime")
                        .HasColumnType("time without time zone");

                    b.Property<int?>("TimesheetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TimesheetId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Post", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Session", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Timesheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("TimesheetId");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Timesheet", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
