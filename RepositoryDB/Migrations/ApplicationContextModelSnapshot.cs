﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryDB;

namespace RepositoryDB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TecnoComponents.BaseInfoObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TypeNode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseInfoObjects");

                    b.HasDiscriminator<int>("TypeNode");
                });

            modelBuilder.Entity("TecnoComponents.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InfoId")
                        .HasColumnType("int");

                    b.Property<int>("LinkParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("LinkParentId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("TecnoComponents.AssemblyNode", b =>
                {
                    b.HasBaseType("TecnoComponents.BaseInfoObject");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeNode = 1,
                            Description = "Система магнитная",
                            Name = "СМТШ.684127.064",
                            Number = "СМТШ.684127.064"
                        },
                        new
                        {
                            Id = 5,
                            TypeNode = 1,
                            Description = "Полоса прессующая",
                            Name = "СМТШ.301714.081",
                            Number = "СМТШ.301714.081"
                        },
                        new
                        {
                            Id = 6,
                            TypeNode = 1,
                            Description = "Маслоканал",
                            Name = "СМТШ.686469.442",
                            Number = "СМТШ.686469.442"
                        });
                });

            modelBuilder.Entity("TecnoComponents.DetailNode", b =>
                {
                    b.HasBaseType("TecnoComponents.BaseInfoObject");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            TypeNode = 2,
                            Description = "Прокладка",
                            Name = "СМТШ.754152.133",
                            Number = "СМТШ.754152.133"
                        },
                        new
                        {
                            Id = 3,
                            TypeNode = 2,
                            Description = "Прокладка",
                            Name = "СМТШ.754152.133-001",
                            Number = "СМТШ.754152.133-001"
                        },
                        new
                        {
                            Id = 4,
                            TypeNode = 2,
                            Description = "Кронштейн",
                            Name = "СМТШ.745226.006",
                            Number = "СМТШ.745226.006"
                        },
                        new
                        {
                            Id = 7,
                            TypeNode = 2,
                            Description = "Полоса изоляционная",
                            Name = "СМТШ.741521.439",
                            Number = "СМТШ.741521.439"
                        },
                        new
                        {
                            Id = 8,
                            TypeNode = 2,
                            Description = "Планка",
                            Name = "СМТШ.741291.167",
                            Number = "СМТШ.741291.167"
                        },
                        new
                        {
                            Id = 9,
                            TypeNode = 2,
                            Description = "Полоса прессующая",
                            Name = "СМТШ.741138.156",
                            Number = "СМТШ.741138.156"
                        },
                        new
                        {
                            Id = 10,
                            TypeNode = 2,
                            Description = "Стержень",
                            Name = "СМТШ.711111.069",
                            Number = "СМТШ.711111.069"
                        },
                        new
                        {
                            Id = 11,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042",
                            Number = "СМТШ.741171.042"
                        },
                        new
                        {
                            Id = 12,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-001",
                            Number = "СМТШ.741171.042-001"
                        },
                        new
                        {
                            Id = 13,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-002",
                            Number = "СМТШ.741171.042-002"
                        },
                        new
                        {
                            Id = 14,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-004",
                            Number = "СМТШ.741171.042-004"
                        },
                        new
                        {
                            Id = 15,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-005",
                            Number = "СМТШ.741171.042-005"
                        },
                        new
                        {
                            Id = 16,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-007",
                            Number = "СМТШ.741171.042-007"
                        },
                        new
                        {
                            Id = 17,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-010",
                            Number = "СМТШ.741171.042-010"
                        },
                        new
                        {
                            Id = 18,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-011",
                            Number = "СМТШ.741171.042-011"
                        },
                        new
                        {
                            Id = 19,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-012",
                            Number = "СМТШ.741171.042-012"
                        },
                        new
                        {
                            Id = 20,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-013",
                            Number = "СМТШ.741171.042-013"
                        },
                        new
                        {
                            Id = 21,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-015",
                            Number = "СМТШ.741171.042-015"
                        },
                        new
                        {
                            Id = 22,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-016",
                            Number = "СМТШ.741171.042-016"
                        },
                        new
                        {
                            Id = 23,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-017",
                            Number = "СМТШ.741171.042-017"
                        },
                        new
                        {
                            Id = 24,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-020",
                            Number = "СМТШ.741171.042-020"
                        },
                        new
                        {
                            Id = 25,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-023",
                            Number = "СМТШ.741171.042-023"
                        },
                        new
                        {
                            Id = 26,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-026",
                            Number = "СМТШ.741171.042-026"
                        },
                        new
                        {
                            Id = 27,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-028",
                            Number = "СМТШ.741171.042-028"
                        },
                        new
                        {
                            Id = 28,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-030",
                            Number = "СМТШ.741171.042-030"
                        },
                        new
                        {
                            Id = 29,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-035",
                            Number = "СМТШ.741171.042-035"
                        },
                        new
                        {
                            Id = 30,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-041",
                            Number = "СМТШ.741171.042-041"
                        },
                        new
                        {
                            Id = 31,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-045",
                            Number = "СМТШ.741171.042-045"
                        },
                        new
                        {
                            Id = 32,
                            TypeNode = 2,
                            Description = "Полоса",
                            Name = "СМТШ.741171.042-052",
                            Number = "СМТШ.741171.042-052"
                        });
                });

            modelBuilder.Entity("TecnoComponents.Link", b =>
                {
                    b.HasOne("TecnoComponents.BaseInfoObject", "InfoDB")
                        .WithMany("DirectLinkDB")
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TecnoComponents.Link", "ParentDB")
                        .WithMany("ChildrenDB")
                        .HasForeignKey("LinkParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
