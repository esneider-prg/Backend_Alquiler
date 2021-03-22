﻿// <auto-generated />
using Backend_Alquiler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend_Alquiler.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20210322222305_pruebas3")]
    partial class pruebas3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend_Alquiler.Models.Alquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("FechaAlquiler")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValorAlquiler")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Alquileres");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Cd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TituloId")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TituloId");

                    b.ToTable("Cds");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("DireccionCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaInscripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemaInteres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.DetalleAlquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("CdId")
                        .HasColumnType("int");

                    b.Property<int>("DiasPrestamo")
                        .HasColumnType("int");

                    b.Property<string>("FechaDevolucion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.HasIndex("CdId");

                    b.ToTable("DetalleAlquileres");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Sancion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("DiasSancion")
                        .HasColumnType("int");

                    b.Property<string>("TipoSancion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.ToTable("Sanciones");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Titulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Interprete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTitulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Alquiler", b =>
                {
                    b.HasOne("Backend_Alquiler.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Cd", b =>
                {
                    b.HasOne("Backend_Alquiler.Models.Titulo", "Titulo")
                        .WithMany()
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.DetalleAlquiler", b =>
                {
                    b.HasOne("Backend_Alquiler.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Alquiler.Models.Cd", "Cd")
                        .WithMany()
                        .HasForeignKey("CdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");

                    b.Navigation("Cd");
                });

            modelBuilder.Entity("Backend_Alquiler.Models.Sancion", b =>
                {
                    b.HasOne("Backend_Alquiler.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");
                });
#pragma warning restore 612, 618
        }
    }
}
