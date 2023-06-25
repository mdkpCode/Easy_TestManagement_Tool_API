﻿// <auto-generated />
using System;
using Easy_TestManagement_Tool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230624134803_NewTablesHasBeenAddedFix")]
    partial class NewTablesHasBeenAddedFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Precondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TestCaseOnTestRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseOnTestRunId");

                    b.ToTable("TB_TestCases");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCaseOnTestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TestRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestRunId");

                    b.ToTable("TestRunTestCases");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_TestRuns");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpectedResults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestCaseId")
                        .HasColumnType("int");

                    b.Property<int?>("TestCaseOnTestRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestCaseId");

                    b.HasIndex("TestCaseOnTestRunId");

                    b.ToTable("TB_TestSteps");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestStepOnTestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActualResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("TestRunTestCasesOnTestRun");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCase", b =>
                {
                    b.HasOne("Easy_TestManagement_Tool.Models.TestCaseOnTestRun", null)
                        .WithMany("TestCase")
                        .HasForeignKey("TestCaseOnTestRunId");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCaseOnTestRun", b =>
                {
                    b.HasOne("Easy_TestManagement_Tool.Models.TestRun", null)
                        .WithMany("TestCases")
                        .HasForeignKey("TestRunId");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestStep", b =>
                {
                    b.HasOne("Easy_TestManagement_Tool.Models.TestCase", null)
                        .WithMany("Steps")
                        .HasForeignKey("TestCaseId");

                    b.HasOne("Easy_TestManagement_Tool.Models.TestCaseOnTestRun", null)
                        .WithMany("Step")
                        .HasForeignKey("TestCaseOnTestRunId");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestStepOnTestRun", b =>
                {
                    b.HasOne("Easy_TestManagement_Tool.Models.TestStep", "Step")
                        .WithMany()
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCase", b =>
                {
                    b.Navigation("Steps");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestCaseOnTestRun", b =>
                {
                    b.Navigation("Step");

                    b.Navigation("TestCase");
                });

            modelBuilder.Entity("Easy_TestManagement_Tool.Models.TestRun", b =>
                {
                    b.Navigation("TestCases");
                });
#pragma warning restore 612, 618
        }
    }
}
