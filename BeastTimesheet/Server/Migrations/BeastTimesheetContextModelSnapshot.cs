﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeastTimesheet.Server.Migrations
{
    [DbContext(typeof(BeastTimesheetContext))]
    partial class BeastTimesheetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateOnly>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<bool>("Payed")
                        .HasColumnType("boolean");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("TimesheetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TimesheetId")
                        .IsUnique();

                    b.ToTable("Bills");
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

                    b.Property<TimeOnly>("BreaksTime")
                        .HasColumnType("time without time zone");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("StopTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("TimesheetId")
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

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Bill", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Project", null)
                        .WithMany("Bills")
                        .HasForeignKey("ProjectId");

                    b.HasOne("BeastTimesheet.Shared.Model.Timesheet", "Timesheet")
                        .WithOne("Bill")
                        .HasForeignKey("BeastTimesheet.Shared.Model.Bill", "TimesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Session", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Timesheet", "Timesheet")
                        .WithMany("Sessions")
                        .HasForeignKey("TimesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Timesheet", b =>
                {
                    b.HasOne("BeastTimesheet.Shared.Model.Project", "Project")
                        .WithMany("Timesheets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Project", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("BeastTimesheet.Shared.Model.Timesheet", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
