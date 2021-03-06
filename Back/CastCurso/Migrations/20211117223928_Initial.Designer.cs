// <auto-generated />
using System;
using CastCurso.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CastCurso.Migrations
{
    [DbContext(typeof(CastCursoContext))]
    [Migration("20211117223928_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastCurso.Models.Categorias", b =>
                {
                    b.Property<int>("CategoriasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriasNome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoriasId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CastCurso.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoCurso")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DtTermino")
                        .HasColumnType("DateTime");

                    b.Property<int>("QtdAlunos")
                        .HasColumnType("int");

                    b.HasKey("CursoId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("CastCurso.Models.TabelaLog", b =>
                {
                    b.Property<int>("TabelaLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DtInclusao")
                        .HasColumnType("DateTime");

                    b.Property<string>("UsuarioResponsavel")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("dtUltimaAtt")
                        .HasColumnType("DateTime");

                    b.HasKey("TabelaLogId");

                    b.ToTable("TabelaLog");
                });

            modelBuilder.Entity("CastCurso.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
