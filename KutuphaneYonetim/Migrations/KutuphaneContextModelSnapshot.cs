﻿// <auto-generated />
using System;
using KutuphaneYonetim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KutuphaneYonetim.Migrations
{
    [DbContext(typeof(KutuphaneContext))]
    partial class KutuphaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KutuphaneYonetim.Models.Favori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KitapID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KitapID");

                    b.ToTable("Favoriler");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.Kitap", b =>
                {
                    b.Property<int>("KitapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitapID"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("MusaitMi")
                        .HasColumnType("bit");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("YayimYili")
                        .HasColumnType("int");

                    b.Property<string>("Yayinevi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Yazar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KitapID");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"));

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UyariSayisi")
                        .HasColumnType("int");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.OduncIslem", b =>
                {
                    b.Property<int>("IslemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IslemID"));

                    b.Property<DateTime>("AlisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("CezaTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("IadeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KitapID")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.HasKey("IslemID");

                    b.HasIndex("KitapID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("OduncIslemler");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.Favori", b =>
                {
                    b.HasOne("KutuphaneYonetim.Models.Kitap", "Kitap")
                        .WithMany("Favoriler")
                        .HasForeignKey("KitapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitap");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.OduncIslem", b =>
                {
                    b.HasOne("KutuphaneYonetim.Models.Kitap", "Kitap")
                        .WithMany("OduncIslemleri")
                        .HasForeignKey("KitapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KutuphaneYonetim.Models.Kullanici", "Kullanici")
                        .WithMany("OduncIslemleri")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kitap");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.Kitap", b =>
                {
                    b.Navigation("Favoriler");

                    b.Navigation("OduncIslemleri");
                });

            modelBuilder.Entity("KutuphaneYonetim.Models.Kullanici", b =>
                {
                    b.Navigation("OduncIslemleri");
                });
#pragma warning restore 612, 618
        }
    }
}
