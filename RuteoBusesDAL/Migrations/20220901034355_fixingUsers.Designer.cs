﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuteoBusesDAL;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    [DbContext(typeof(RuteoBusesDbcontext))]
    [Migration("20220901034355_fixingUsers")]
    partial class fixingUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RuteoBusesDAL.Bus", b =>
                {
                    b.Property<int>("busId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("busId"), 1L, 1);

                    b.Property<int?>("choferId")
                        .HasColumnType("int");

                    b.Property<int?>("estadoId")
                        .HasColumnType("int");

                    b.Property<int?>("rutaId")
                        .HasColumnType("int");

                    b.HasKey("busId");

                    b.HasIndex("choferId");

                    b.HasIndex("estadoId");

                    b.HasIndex("rutaId");

                    b.ToTable("buses");
                });

            modelBuilder.Entity("RuteoBusesDAL.Chofer", b =>
                {
                    b.Property<int>("choferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("choferId"), 1L, 1);

                    b.Property<string>("cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("choferId");

                    b.ToTable("choferes");
                });

            modelBuilder.Entity("RuteoBusesDAL.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("RuteoBusesDAL.ParadaRuta", b =>
                {
                    b.Property<int>("paradaRutaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("paradaRutaId"), 1L, 1);

                    b.Property<int?>("busId")
                        .HasColumnType("int");

                    b.Property<string>("nombreParadaRuta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("rutaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("paradaRutaId");

                    b.HasIndex("busId");

                    b.HasIndex("rutaId");

                    b.ToTable("paradarutas");
                });

            modelBuilder.Entity("RuteoBusesDAL.Rol", b =>
                {
                    b.Property<int>("rolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rolId"), 1L, 1);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("rolId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("RuteoBusesDAL.Ruta", b =>
                {
                    b.Property<int>("rutaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rutaId"), 1L, 1);

                    b.Property<int>("cantidadDeParadas")
                        .HasColumnType("int");

                    b.Property<double>("montoEstimado")
                        .HasColumnType("float");

                    b.Property<double>("montoRecibido")
                        .HasColumnType("float");

                    b.Property<string>("nombreRuta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("rutaId");

                    b.ToTable("rutas");
                });

            modelBuilder.Entity("RuteoBusesDAL.Usuario", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rolId")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("rolId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("RuteoBusesDAL.Bus", b =>
                {
                    b.HasOne("RuteoBusesDAL.Chofer", "chofer")
                        .WithMany("buses")
                        .HasForeignKey("choferId");

                    b.HasOne("RuteoBusesDAL.Estado", "estadoUnidad")
                        .WithMany("Buses")
                        .HasForeignKey("estadoId");

                    b.HasOne("RuteoBusesDAL.Ruta", "ruta")
                        .WithMany("buses")
                        .HasForeignKey("rutaId");

                    b.Navigation("chofer");

                    b.Navigation("estadoUnidad");

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("RuteoBusesDAL.ParadaRuta", b =>
                {
                    b.HasOne("RuteoBusesDAL.Bus", "bus")
                        .WithMany("paradas")
                        .HasForeignKey("busId");

                    b.HasOne("RuteoBusesDAL.Ruta", "ruta")
                        .WithMany("paradas")
                        .HasForeignKey("rutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bus");

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("RuteoBusesDAL.Usuario", b =>
                {
                    b.HasOne("RuteoBusesDAL.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("rolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });

            modelBuilder.Entity("RuteoBusesDAL.Bus", b =>
                {
                    b.Navigation("paradas");
                });

            modelBuilder.Entity("RuteoBusesDAL.Chofer", b =>
                {
                    b.Navigation("buses");
                });

            modelBuilder.Entity("RuteoBusesDAL.Estado", b =>
                {
                    b.Navigation("Buses");
                });

            modelBuilder.Entity("RuteoBusesDAL.Ruta", b =>
                {
                    b.Navigation("buses");

                    b.Navigation("paradas");
                });
#pragma warning restore 612, 618
        }
    }
}
