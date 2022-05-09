﻿// <auto-generated />
using CadastroImuno.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroImuno.Migrations
{
    [DbContext(typeof(ImunizanteDbContext))]
    [Migration("20220509151818_AdicionandoRegexAnoLote")]
    partial class AdicionandoRegexAnoLote
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CadastroImuno.Models.Imunizante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnoLote")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Imunizante");
                });
#pragma warning restore 612, 618
        }
    }
}
