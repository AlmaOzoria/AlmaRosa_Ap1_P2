﻿// <auto-generated />
using System;
using AlmaRosa_Ap1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlmaRosa_Ap1_P2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241119041409_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlmaRosa_Ap1_P2.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 1000.0m,
                            Descripcion = "Teclado",
                            Existencia = 100m,
                            Precio = 1500.0m
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 20000.0m,
                            Descripcion = "Tarjeta Grafica",
                            Existencia = 50m,
                            Precio = 30000.0m
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 30000.0m,
                            Descripcion = "Memoria Ram",
                            Existencia = 60m,
                            Precio = 50000.0m
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 120000.0m,
                            Descripcion = "Cpu",
                            Existencia = 70m,
                            Precio = 140000.0m
                        });
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P2.Models.Combos", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("ComboId");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P2.Models.CombosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ComboId");

                    b.ToTable("CombosDetalle");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P2.Models.CombosDetalle", b =>
                {
                    b.HasOne("AlmaRosa_Ap1_P2.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlmaRosa_Ap1_P2.Models.Combos", "Combos")
                        .WithMany("CombosDetalles")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Combos");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P2.Models.Combos", b =>
                {
                    b.Navigation("CombosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
