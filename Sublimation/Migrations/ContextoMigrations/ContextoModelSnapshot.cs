﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sublimation.DAL;

#nullable disable

namespace Sublimation.Migrations.ContextoMigrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Library.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Library.Models.Compras", b =>
                {
                    b.Property<int>("ComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ComprasId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Library.Models.ComprasDetalle", b =>
                {
                    b.Property<int>("ComprasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComprasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InsumoId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ComprasDetalleId");

                    b.HasIndex("ComprasId");

                    b.ToTable("ComprasDetalle");
                });

            modelBuilder.Entity("Library.Models.Insumos", b =>
                {
                    b.Property<int>("InsumosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreInsumo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("TEXT");

                    b.HasKey("InsumosId");

                    b.ToTable("Insumos");
                });

            modelBuilder.Entity("Library.Models.Reclamos", b =>
                {
                    b.Property<int>("ReclamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccionTomada")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaReclamo")
                        .HasColumnType("TEXT");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReclamoId");

                    b.ToTable("Reclamos");
                });

            modelBuilder.Entity("Library.Models.Servicios", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("CostoServicio")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoServicio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Library.Models.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("Library.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Library.Models.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<double>("MontoTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("ServicioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Library.Models.VentasDetalle", b =>
                {
                    b.Property<int>("VentasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaEstimadaEntrega")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Instalacion")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ServicioGrua")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VentasDetalleId");

                    b.HasIndex("VentaId");

                    b.ToTable("VentasDetalle");
                });

            modelBuilder.Entity("Library.Models.ComprasDetalle", b =>
                {
                    b.HasOne("Library.Models.Compras", null)
                        .WithMany("ComprasDetalle")
                        .HasForeignKey("ComprasId");
                });

            modelBuilder.Entity("Library.Models.VentasDetalle", b =>
                {
                    b.HasOne("Library.Models.Ventas", null)
                        .WithMany("VentasDetalle")
                        .HasForeignKey("VentaId");
                });

            modelBuilder.Entity("Library.Models.Compras", b =>
                {
                    b.Navigation("ComprasDetalle");
                });

            modelBuilder.Entity("Library.Models.Ventas", b =>
                {
                    b.Navigation("VentasDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
