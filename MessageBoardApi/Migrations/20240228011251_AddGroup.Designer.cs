﻿// <auto-generated />
using System;
using MessageBoardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MessageBoardAPI.Migrations
{
    [DbContext(typeof(MessageBoardApiContext))]
    [Migration("20240228011251_AddGroup")]
    partial class AddGroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MessageBoardApi.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            Name = "Group 1"
                        },
                        new
                        {
                            GroupId = 2,
                            Name = "Group 2"
                        },
                        new
                        {
                            GroupId = 3,
                            Name = "Group 3"
                        });
                });

            modelBuilder.Entity("MessageBoardApi.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("MessageDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            MessageDateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MessageId = 2,
                            Group = "Group 1",
                            MessageDateTime = new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "example text"
                        },
                        new
                        {
                            MessageId = 3,
                            Group = "Group 2",
                            MessageDateTime = new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "example text"
                        },
                        new
                        {
                            MessageId = 4,
                            Group = "Group 3",
                            MessageDateTime = new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "example text"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
