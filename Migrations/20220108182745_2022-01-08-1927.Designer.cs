// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TentaPApi.Data;

namespace TentaPApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220108182745_2022-01-08-1927")]
    partial class _202201081927
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TentaPApi.Data.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TentaPApi.Data.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.Property<int?>("SolutionImageId")
                        .HasColumnType("integer");

                    b.Property<int?>("SourceId")
                        .HasColumnType("integer");

                    b.Property<int?>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("SolutionImageId");

                    b.HasIndex("SourceId");

                    b.HasIndex("TagId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("TentaPApi.Data.ExerciseImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("ExerciseImage");
                });

            modelBuilder.Entity("TentaPApi.Data.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("TentaPApi.Data.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("TentaPApi.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TentaPApi.Data.Exercise", b =>
                {
                    b.HasOne("TentaPApi.Data.ExerciseImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("TentaPApi.Data.ExerciseImage", "SolutionImage")
                        .WithMany()
                        .HasForeignKey("SolutionImageId");

                    b.HasOne("TentaPApi.Data.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("TentaPApi.Data.Tag", null)
                        .WithMany("Exercises")
                        .HasForeignKey("TagId");

                    b.Navigation("Image");

                    b.Navigation("SolutionImage");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("TentaPApi.Data.Module", b =>
                {
                    b.HasOne("TentaPApi.Data.Course", null)
                        .WithMany("Modules")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("TentaPApi.Data.Tag", b =>
                {
                    b.HasOne("TentaPApi.Data.Module", null)
                        .WithMany("Tags")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("TentaPApi.Data.Course", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("TentaPApi.Data.Module", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("TentaPApi.Data.Tag", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
