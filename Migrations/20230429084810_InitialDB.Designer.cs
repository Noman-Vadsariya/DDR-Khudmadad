﻿// <auto-generated />
using DDR_Khudmadad.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDR_Khudmadad.Migrations
{
    [DbContext(typeof(Ef_DataContext))]
    [Migration("20230429084810_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Gig", b =>
                {
                    b.Property<int>("gigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("gigId"));

                    b.Property<int>("creatorId")
                        .HasColumnType("integer");

                    b.Property<string>("deadline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gigName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("pay")
                        .HasColumnType("double precision");

                    b.HasKey("gigId");

                    b.HasIndex("creatorId");

                    b.ToTable("Gig");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Offers", b =>
                {
                    b.Property<int>("gigId")
                        .HasColumnType("integer");

                    b.Property<int>("freelancerId")
                        .HasColumnType("integer");

                    b.Property<double>("pay")
                        .HasColumnType("double precision");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("gigId", "freelancerId");

                    b.HasIndex("freelancerId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Roles", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("roleId"));

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Users", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("dob")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<int>("roleId")
                        .HasColumnType("integer");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("userId");

                    b.HasIndex("roleId");

                    b.HasIndex("userName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Gig", b =>
                {
                    b.HasOne("DDR_Khudmadad.BusinessObjects.Users", "Creator")
                        .WithMany("gig")
                        .HasForeignKey("creatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Offers", b =>
                {
                    b.HasOne("DDR_Khudmadad.BusinessObjects.Users", "freelancer")
                        .WithMany("offer")
                        .HasForeignKey("freelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDR_Khudmadad.BusinessObjects.Gig", "gig")
                        .WithMany("offer")
                        .HasForeignKey("gigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("freelancer");

                    b.Navigation("gig");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Users", b =>
                {
                    b.HasOne("DDR_Khudmadad.BusinessObjects.Roles", "Role")
                        .WithMany("users")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Gig", b =>
                {
                    b.Navigation("offer");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Roles", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("DDR_Khudmadad.BusinessObjects.Users", b =>
                {
                    b.Navigation("gig");

                    b.Navigation("offer");
                });
#pragma warning restore 612, 618
        }
    }
}
