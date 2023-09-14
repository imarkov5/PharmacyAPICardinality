﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyAPICardinality.Repository;

#nullable disable

namespace PharmacyAPICardinality.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230914180041_ClinicianRemoved")]
    partial class ClinicianRemoved
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmacyAPICardinality.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientAddressId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.PatientAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientAddress");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Pharmacist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pharmacists");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFilledPrescriptions")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.PharmacyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId")
                        .IsUnique()
                        .HasFilter("[PharmacyId] IS NOT NULL");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugStrength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDispensed")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PharmacistId")
                        .HasColumnType("int");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("PharmacistId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Patient", b =>
                {
                    b.HasOne("PharmacyAPICardinality.Models.PatientAddress", "Address")
                        .WithMany("Patients")
                        .HasForeignKey("PatientAddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.PharmacyAddress", b =>
                {
                    b.HasOne("PharmacyAPICardinality.Models.Pharmacy", "Pharmacy")
                        .WithOne("PharmacyAddress")
                        .HasForeignKey("PharmacyAPICardinality.Models.PharmacyAddress", "PharmacyId");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Prescription", b =>
                {
                    b.HasOne("PharmacyAPICardinality.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId");

                    b.HasOne("PharmacyAPICardinality.Models.Pharmacist", "Pharmacist")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PharmacistId");

                    b.HasOne("PharmacyAPICardinality.Models.Pharmacy", "Pharmacy")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PharmacyId");

                    b.Navigation("Patient");

                    b.Navigation("Pharmacist");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.PatientAddress", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Pharmacist", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PharmacyAPICardinality.Models.Pharmacy", b =>
                {
                    b.Navigation("PharmacyAddress")
                        .IsRequired();

                    b.Navigation("Prescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
