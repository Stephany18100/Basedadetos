﻿// <auto-generated />
using System;
using Basedadetos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Basedadetos.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20230702191454_Empleados")]
    partial class Empleados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Basedadetos.Entities.Empleado", b =>
                {
                    b.Property<int>("PKEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PKEmpleado");

                    b.ToTable("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}