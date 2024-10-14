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
    [Migration("20241012185223_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DB.Campera", b =>
                {
                    b.Property<int>("CamperaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CamperaID"));

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.Property<int>("TAID")
                        .HasColumnType("integer");

                    b.HasKey("CamperaID");

                    b.HasIndex("PrendaID");

                    b.HasIndex("TAID");

                    b.ToTable("Campera", (string)null);
                });

            modelBuilder.Entity("DB.Color", b =>
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

            modelBuilder.Entity("DB.CorteCuello", b =>
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

            modelBuilder.Entity("DB.Domicilio", b =>
                {
                    b.Property<int>("DomicilioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DomicilioID"));

                    b.Property<int>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LocalidadID")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("integer");

                    b.HasKey("DomicilioID");

                    b.HasIndex("LocalidadID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Domicilio", (string)null);
                });

            modelBuilder.Entity("DB.Imagen", b =>
                {
                    b.Property<int>("ImagenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImagenID"));

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ImagenID");

                    b.ToTable("Imagen", (string)null);
                });

            modelBuilder.Entity("DB.Largo", b =>
                {
                    b.Property<int>("LargoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LargoID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LargoID");

                    b.ToTable("Largo", (string)null);
                });

            modelBuilder.Entity("DB.Localidad", b =>
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

            modelBuilder.Entity("DB.Manga", b =>
                {
                    b.Property<int>("MangaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MangaID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MangaID");

                    b.ToTable("Manga", (string)null);
                });

            modelBuilder.Entity("DB.Material", b =>
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

            modelBuilder.Entity("DB.Pantalon", b =>
                {
                    b.Property<int>("PantalonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PantalonID"));

                    b.Property<int>("LargoID")
                        .HasColumnType("integer");

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.HasKey("PantalonID");

                    b.HasIndex("LargoID");

                    b.HasIndex("PrendaID");

                    b.ToTable("Pantalon", (string)null);
                });

            modelBuilder.Entity("DB.Pedido", b =>
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

            modelBuilder.Entity("DB.PedidoPrenda", b =>
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

            modelBuilder.Entity("DB.Permiso", b =>
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

            modelBuilder.Entity("DB.Prenda", b =>
                {
                    b.Property<int>("PrendaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrendaID"));

                    b.Property<int>("ColorID")
                        .HasColumnType("integer");

                    b.Property<int>("ImagenID")
                        .HasColumnType("integer");

                    b.Property<int>("MaterialID")
                        .HasColumnType("integer");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("RubroID")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("integer");

                    b.HasKey("PrendaID");

                    b.HasIndex("ColorID");

                    b.HasIndex("ImagenID");

                    b.HasIndex("MaterialID");

                    b.HasIndex("RubroID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Prenda", (string)null);
                });

            modelBuilder.Entity("DB.PrendaEstampado", b =>
                {
                    b.Property<int>("PEID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PEID"));

                    b.Property<int>("ImagenID")
                        .HasColumnType("integer");

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.Property<int>("UbicacionID")
                        .HasColumnType("integer");

                    b.HasKey("PEID");

                    b.HasIndex("ImagenID");

                    b.HasIndex("PrendaID");

                    b.HasIndex("UbicacionID");

                    b.ToTable("PrendaEstampado", (string)null);
                });

            modelBuilder.Entity("DB.Provincia", b =>
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

            modelBuilder.Entity("DB.Remera", b =>
                {
                    b.Property<int>("RemeraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RemeraID"));

                    b.Property<int>("CCID")
                        .HasColumnType("integer");

                    b.Property<int>("MangaID")
                        .HasColumnType("integer");

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.Property<int>("TAID")
                        .HasColumnType("integer");

                    b.HasKey("RemeraID");

                    b.HasIndex("CCID");

                    b.HasIndex("MangaID");

                    b.HasIndex("PrendaID");

                    b.HasIndex("TAID");

                    b.ToTable("Remera", (string)null);
                });

            modelBuilder.Entity("DB.Rubro", b =>
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

            modelBuilder.Entity("DB.TalleAlfabetico", b =>
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

            modelBuilder.Entity("DB.TalleNumerico", b =>
                {
                    b.Property<int>("TNID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TNID"));

                    b.Property<int>("Descripcion")
                        .HasColumnType("integer");

                    b.HasKey("TNID");

                    b.ToTable("TalleNumerico", (string)null);
                });

            modelBuilder.Entity("DB.Ubicacion", b =>
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

            modelBuilder.Entity("DB.Usuario", b =>
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

            modelBuilder.Entity("DB.Zapato", b =>
                {
                    b.Property<int>("ZapatoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ZapatoID"));

                    b.Property<int>("PrendaID")
                        .HasColumnType("integer");

                    b.Property<bool>("PuntaMetalica")
                        .HasColumnType("boolean");

                    b.Property<int>("TNID")
                        .HasColumnType("integer");

                    b.HasKey("ZapatoID");

                    b.HasIndex("PrendaID");

                    b.HasIndex("TNID");

                    b.ToTable("Zapato", (string)null);
                });

            modelBuilder.Entity("DB.Campera", b =>
                {
                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.TalleAlfabetico", "TalleAlfabetico")
                        .WithMany()
                        .HasForeignKey("TAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenda");

                    b.Navigation("TalleAlfabetico");
                });

            modelBuilder.Entity("DB.Domicilio", b =>
                {
                    b.HasOne("DB.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localidad");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.Localidad", b =>
                {
                    b.HasOne("DB.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("DB.Pantalon", b =>
                {
                    b.HasOne("DB.Largo", "Largo")
                        .WithMany()
                        .HasForeignKey("LargoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Largo");

                    b.Navigation("Prenda");
                });

            modelBuilder.Entity("DB.Pedido", b =>
                {
                    b.HasOne("DB.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.PedidoPrenda", b =>
                {
                    b.HasOne("DB.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Prenda");
                });

            modelBuilder.Entity("DB.Prenda", b =>
                {
                    b.HasOne("DB.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Imagen", "Imagen")
                        .WithMany()
                        .HasForeignKey("ImagenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Rubro", "Rubro")
                        .WithMany()
                        .HasForeignKey("RubroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Imagen");

                    b.Navigation("Material");

                    b.Navigation("Rubro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DB.PrendaEstampado", b =>
                {
                    b.HasOne("DB.Imagen", "Imagen")
                        .WithMany()
                        .HasForeignKey("ImagenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagen");

                    b.Navigation("Prenda");

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("DB.Remera", b =>
                {
                    b.HasOne("DB.CorteCuello", "CorteCuello")
                        .WithMany()
                        .HasForeignKey("CCID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.TalleAlfabetico", "TalleAlfabetico")
                        .WithMany()
                        .HasForeignKey("TAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorteCuello");

                    b.Navigation("Manga");

                    b.Navigation("Prenda");

                    b.Navigation("TalleAlfabetico");
                });

            modelBuilder.Entity("DB.Usuario", b =>
                {
                    b.HasOne("DB.Permiso", "Permiso")
                        .WithMany()
                        .HasForeignKey("PermisoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");
                });

            modelBuilder.Entity("DB.Zapato", b =>
                {
                    b.HasOne("DB.Prenda", "Prenda")
                        .WithMany()
                        .HasForeignKey("PrendaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.TalleNumerico", "TalleNumerico")
                        .WithMany()
                        .HasForeignKey("TNID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prenda");

                    b.Navigation("TalleNumerico");
                });
#pragma warning restore 612, 618
        }
    }
}
