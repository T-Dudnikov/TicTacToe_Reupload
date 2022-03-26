﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToe_Reupload.Data;

#nullable disable

namespace TicTacToe_Reupload.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicTacToe_Reupload.TicTacToeMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Box1")
                        .HasColumnType("int");

                    b.Property<int>("Box2")
                        .HasColumnType("int");

                    b.Property<int>("Box3")
                        .HasColumnType("int");

                    b.Property<int>("Box4")
                        .HasColumnType("int");

                    b.Property<int>("Box5")
                        .HasColumnType("int");

                    b.Property<int>("Box6")
                        .HasColumnType("int");

                    b.Property<int>("Box7")
                        .HasColumnType("int");

                    b.Property<int>("Box8")
                        .HasColumnType("int");

                    b.Property<int>("Box9")
                        .HasColumnType("int");

                    b.Property<int>("win")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicTacToeMoves");
                });
#pragma warning restore 612, 618
        }
    }
}
