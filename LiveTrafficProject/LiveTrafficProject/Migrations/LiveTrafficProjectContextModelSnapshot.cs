﻿// <auto-generated />
using System;
using LiveTrafficProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiveTrafficProject.Migrations
{
    [DbContext(typeof(LiveTrafficProjectContext))]
    partial class LiveTrafficProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LiveTrafficProject.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PropertiesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertiesId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Geometry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("Coordinates")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Geometry");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("geometryId")
                        .HasColumnType("int");

                    b.Property<int>("propertiesId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("geometryId");

                    b.HasIndex("propertiesId");

                    b.ToTable("Incident");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Delay")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IconCategory")
                        .HasColumnType("int");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("MagnitudeOfDelay")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeValidity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Event", b =>
                {
                    b.HasOne("LiveTrafficProject.Models.Properties", null)
                        .WithMany("Events")
                        .HasForeignKey("PropertiesId");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Incident", b =>
                {
                    b.HasOne("LiveTrafficProject.Models.Geometry", "geometry")
                        .WithMany()
                        .HasForeignKey("geometryId");

                    b.HasOne("LiveTrafficProject.Models.Properties", "properties")
                        .WithMany()
                        .HasForeignKey("propertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("geometry");

                    b.Navigation("properties");
                });

            modelBuilder.Entity("LiveTrafficProject.Models.Properties", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}