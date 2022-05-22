﻿// <auto-generated />
using System;
using CursoSwitcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoSwitcher.Migrations
{
    [DbContext(typeof(ModelContextManager))]
    partial class ModelContextManagerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("CoursesModelProfileModel", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfilesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoursesId", "ProfilesId");

                    b.HasIndex("ProfilesId");

                    b.ToTable("CoursesModelProfileModel");
                });

            modelBuilder.Entity("CursoSwitcher.Models.CampusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visible_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Campus");
                });

            modelBuilder.Entity("CursoSwitcher.Models.CareerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visible_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Careers");
                });

            modelBuilder.Entity("CursoSwitcher.Models.CoursesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visible_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CareerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CursoSwitcher.Models.ProfileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CampusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Is_moderator")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visible_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.HasIndex("CareerId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("CursoSwitcher.Models.ProfileModelCourseModel", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoursesId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProfilesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProfileId", "CourseId");

                    b.HasIndex("CoursesId");

                    b.HasIndex("ProfilesId");

                    b.ToTable("ProfileCourses");
                });

            modelBuilder.Entity("CursoSwitcher.Models.RequestsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("TEXT");

                    b.Property<int>("OfferedCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestedCourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("TEXT");

                    b.Property<string>("Visible_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OfferedCourseId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("RequestedCourseId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("CoursesModelProfileModel", b =>
                {
                    b.HasOne("CursoSwitcher.Models.CoursesModel", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoSwitcher.Models.ProfileModel", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CursoSwitcher.Models.CoursesModel", b =>
                {
                    b.HasOne("CursoSwitcher.Models.CareerModel", "Career")
                        .WithMany("Courses")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Career");
                });

            modelBuilder.Entity("CursoSwitcher.Models.ProfileModel", b =>
                {
                    b.HasOne("CursoSwitcher.Models.CampusModel", "Campus")
                        .WithMany("Profile")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoSwitcher.Models.CareerModel", "Career")
                        .WithMany("Profile")
                        .HasForeignKey("CareerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campus");

                    b.Navigation("Career");
                });

            modelBuilder.Entity("CursoSwitcher.Models.ProfileModelCourseModel", b =>
                {
                    b.HasOne("CursoSwitcher.Models.CoursesModel", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesId");

                    b.HasOne("CursoSwitcher.Models.ProfileModel", "Profiles")
                        .WithMany()
                        .HasForeignKey("ProfilesId");

                    b.Navigation("Courses");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("CursoSwitcher.Models.RequestsModel", b =>
                {
                    b.HasOne("CursoSwitcher.Models.CoursesModel", "OfferedCourse")
                        .WithMany()
                        .HasForeignKey("OfferedCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoSwitcher.Models.ProfileModel", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoSwitcher.Models.CoursesModel", "RequestedCourse")
                        .WithMany()
                        .HasForeignKey("RequestedCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfferedCourse");

                    b.Navigation("Profile");

                    b.Navigation("RequestedCourse");
                });

            modelBuilder.Entity("CursoSwitcher.Models.CampusModel", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("CursoSwitcher.Models.CareerModel", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
