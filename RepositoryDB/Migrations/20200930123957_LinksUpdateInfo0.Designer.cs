﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryDB;

namespace RepositoryDB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200930123957_LinksUpdateInfo0")]
    partial class LinksUpdateInfo0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseInfoObjects");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseInfoObject");
                });

            modelBuilder.Entity("TecnoComponents.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("TecnoComponents.AssemblyNode", b =>
                {
                    b.HasBaseType("TecnoComponents.BaseInfoObject");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AssemblyNode");
                });

            modelBuilder.Entity("TecnoComponents.DetailNode", b =>
                {
                    b.HasBaseType("TecnoComponents.BaseInfoObject");

                    b.Property<string>("Description")
                        .HasColumnName("DetailNode_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("DetailNode_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnName("DetailNode_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("DetailNode");
                });

            modelBuilder.Entity("TecnoComponents.Link", b =>
                {
                    b.HasOne("TecnoComponents.BaseInfoObject", "InfoDB")
                        .WithMany("DirectLinkDB")
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}