﻿// <auto-generated />
using System;
using HRApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.Migrations.Visitor
{
    [DbContext(typeof(VisitorContext))]
    partial class VisitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HRApp.API.Models.VisitorDb", b =>
                {
                    b.Property<Guid>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Appointment")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<DateTime>("SignIn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("SignInFlag")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("SignOut")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("VisitorId");

                    b.ToTable("Visitor");
                });
#pragma warning restore 612, 618
        }
    }
}
