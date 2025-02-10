﻿// <auto-generated />
using DB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(PersicufContext))]
    [Migration("20250210071009_DomicilioActualizado")]
    partial class DomicilioActualizado
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DB.Models.Color", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ColorID"));

                    b.Property<string>("CodigoHexa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColorNombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ColorID");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("DB.Models.CorteCuello", b =>
                {
                    b.Property<int>("CCID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CCID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CCID");

                    b.ToTable("CorteCuello", (string)null);
                });

            modelBuilder.Entity("DB.Models.Domicilio", b =>
                {
                    b.Property<int>("DomicilioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DomicilioID"));

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Depto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LocalidadID")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Piso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("integer");

                    b.HasKey("DomicilioID");

                    b.HasIndex("LocalidadID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Domicilio", (string)null);
                });

            modelBuilder.Entity("DB.Models.Imagen", b =>
                {
                    b.Property<int>("ImagenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImagenID"));

                    b.Property<string>("ImagenPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UbicacionID")
                        .HasColumnType("integer");

                    b.HasKey("ImagenID");

                    b.HasIndex("UbicacionID");

                    b.ToTable("Imagen", (string)null);
                });

            modelBuilder.Entity("DB.Models.Largo", b =>
                {
                    b.Property<int>("LargoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LargoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("LargoID");

                    b.ToTable("Largo", (string)null);
                });

            modelBuilder.Entity("DB.Models.Localidad", b =>
                {
                    b.Property<int>("LocalidadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocalidadID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProvinciaID")
                        .HasColumnType("integer");

                    b.HasKey("LocalidadID");

                    b.HasIndex("ProvinciaID");

                    b.ToTable("Localidad", (string)null);
                });

            modelBuilder.Entity("DB.Models.Manga", b =>
                {
                    b.Property<int>("MangaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MangaID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("MangaID");

                    b.ToTable("Manga", (string)null);
                });

            modelBuilder.Entity("DB.Models.Material", b =>
                {
                    b.Property<int>("MaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MaterialID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("MaterialID");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("DB.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PedidoID"));

                    b.Property<int>("DomicilioID")
                        .HasColumnType("integer");

                    b.Property<float>("PrecioTotal")
                        .HasColumnType("real");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("integer");

                    b.HasKey("PedidoID");

                    b.HasIndex("DomicilioID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("DB.Models.PedidoPrenda", b =>
                {
                    b.Property<int>("PPID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PPID"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<int>("PedidoID")
                        .HasColumnType("integer");

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.HasKey("PPID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("PrendaID");

                    b.ToTable("PedidoPrenda", (string)null);
                });

            modelBuilder.Entity("DB.Models.Permiso", b =>
                {
                    b.Property<int>("PermisoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PermisoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PermisoID");

                    b.ToTable("Permiso", (string)null);
                });

            modelBuilder.Entity("DB.Models.Prenda", b =>
                {
                    b.Property<int>("PrendaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrendaID"));

                    b.Property<int>("ColorID")
                        .HasColumnType("integer");

                    b.Property<int?>("EstampadoID")
                        .HasColumnType("integer");

                    b.Property<int?>("ImagenID")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialID")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PostID")
                        .HasColumnType("integer");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("RubroID")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("integer");

                    b.HasKey("PrendaID");

                    b.HasIndex("ColorID");

                    b.HasIndex("EstampadoID");

                    b.HasIndex("ImagenID");

                    b.HasIndex("MaterialID");

                    b.HasIndex("RubroID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Prenda", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DB.Models.Provincia", b =>
                {
                    b.Property<int>("ProvinciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProvinciaID"));

                    b.Property<string>("ProvinciaNombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProvinciaID");

                    b.ToTable("Provincia", (string)null);
                });

            modelBuilder.Entity("DB.Models.Rubro", b =>
                {
                    b.Property<int>("RubroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RubroID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RubroID");

                    b.ToTable("Rubro", (string)null);
                });

            modelBuilder.Entity("DB.Models.TalleAlfabetico", b =>
                {
                    b.Property<int>("TAID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TAID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TAID");

                    b.ToTable("TalleAlfabetico", (string)null);
                });

            modelBuilder.Entity("DB.Models.TalleNumerico", b =>
                {
                    b.Property<int>("TNID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TNID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TNID");

                    b.ToTable("TalleNumerico", (string)null);
                });

            modelBuilder.Entity("DB.Models.Ubicacion", b =>
                {
                    b.Property<int>("UbicacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UbicacionID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("PosX")
                        .HasColumnType("real");

                    b.Property<float>("PosY")
                        .HasColumnType("real");

                    b.HasKey("UbicacionID");

                    b.ToTable("Ubicacion", (string)null);
                });

            modelBuilder.Entity("DB.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PermisoID")
                        .HasColumnType("integer");

                    b.HasKey("UsuarioID");

                    b.HasIndex("PermisoID");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("DB.Models.Campera", b =>
                {
                    b.HasBaseType("DB.Models.Prenda");

                    b.Property<int>("TAID")
                        .HasColumnType("integer");

                    b.HasIndex("TAID");

                    b.ToTable("Campera", (string)null);
                });

            modelBuilder.Entity("DB.Models.Pantalon", b =>
                {
                    b.HasBaseType("DB.Models.Prenda");

                    b.Property<int>("LargoID")
                        .HasColumnType("integer");

                    b.Property<int>("TAID")
                        .HasColumnType("integer");

                    b.HasIndex("LargoID");

                    b.HasIndex("TAID");

                    b.ToTable("Pantalon", (string)null);
                });

            modelBuilder.Entity("DB.Models.Remera", b =>
                {
                    b.HasBaseType("DB.Models.Prenda");

                    b.Property<int>("CCID")
                        .HasColumnType("integer");

                    b.Property<int>("MangaID")
                        .HasColumnType("integer");

                    b.Property<int>("TAID")
                        .HasColumnType("integer");

                    b.HasIndex("CCID");

                    b.HasIndex("MangaID");

                    b.HasIndex("TAID");

                    b.ToTable("Remera", (string)null);
                });

            modelBuilder.Entity("DB.Models.Zapato", b =>
                {
                    b.HasBaseType("DB.Models.Prenda");

                    b.Property<bool>("PuntaMetalica")
                        .HasColumnType("boolean");

                    b.Property<int>("TNID")
                        .HasColumnType("integer");

                    b.HasIndex("TNID");

                    b.ToTable("Zapato", (string)null);
                });

            modelBuilder.Entity("DB.Models.Domicilio", b =>
                {
                    b.HasOne("DB.Models.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localidad");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.Models.Imagen", b =>
                {
                    b.HasOne("DB.Models.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionID");

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("DB.Models.Localidad", b =>
                {
                    b.HasOne("DB.Models.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("DB.Models.Pedido", b =>
                {
                    b.HasOne("DB.Models.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.Models.PedidoPrenda", b =>
                {
                    b.HasOne("DB.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Prenda");
                });

            modelBuilder.Entity("DB.Models.Prenda", b =>
                {
                    b.HasOne("DB.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Imagen", "Estampado")
                        .WithMany()
                        .HasForeignKey("EstampadoID");

                    b.HasOne("DB.Models.Imagen", "Imagen")
                        .WithMany()
                        .HasForeignKey("ImagenID");

                    b.HasOne("DB.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Rubro", "Rubro")
                        .WithMany()
                        .HasForeignKey("RubroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Estampado");

                    b.Navigation("Imagen");

                    b.Navigation("Material");

                    b.Navigation("Rubro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.Models.Usuario", b =>
                {
                    b.HasOne("DB.Models.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("DB.Models.Campera", b =>
                {
                    b.HasOne("DB.Models.Prenda", null)
                        .WithOne()
                        .HasForeignKey("DB.Models.Campera", "PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.TalleAlfabetico", "TalleAlfabetico")
                        .WithMany()
                        .HasForeignKey("TAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TalleAlfabetico");
                });

            modelBuilder.Entity("DB.Models.Pantalon", b =>
                {
                    b.HasOne("DB.Models.Largo", "Largo")
                        .WithMany()
                        .HasForeignKey("LargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Prenda", null)
                        .WithOne()
                        .HasForeignKey("DB.Models.Pantalon", "PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.TalleAlfabetico", "TalleAlfabetico")
                        .WithMany()
                        .HasForeignKey("TAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Largo");

                    b.Navigation("TalleAlfabetico");
                });

            modelBuilder.Entity("DB.Models.Remera", b =>
                {
                    b.HasOne("DB.Models.CorteCuello", "CorteCuello")
                        .WithMany()
                        .HasForeignKey("CCID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Prenda", null)
                        .WithOne()
                        .HasForeignKey("DB.Models.Remera", "PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.TalleAlfabetico", "TalleAlfabetico")
                        .WithMany()
                        .HasForeignKey("TAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorteCuello");

                    b.Navigation("Manga");

                    b.Navigation("TalleAlfabetico");
                });

            modelBuilder.Entity("DB.Models.Zapato", b =>
                {
                    b.HasOne("DB.Models.Prenda", null)
                        .WithOne()
                        .HasForeignKey("DB.Models.Zapato", "PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.TalleNumerico", "TalleNumerico")
                        .WithMany()
                        .HasForeignKey("TNID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TalleNumerico");
                });
#pragma warning restore 612, 618
        }
    }
}
