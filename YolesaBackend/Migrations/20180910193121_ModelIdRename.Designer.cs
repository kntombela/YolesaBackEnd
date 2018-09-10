﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YolesaBackend.Models;

namespace YolesaBackend.Migrations
{
    [DbContext(typeof(YolesaContext))]
    [Migration("20180910193121_ModelIdRename")]
    partial class ModelIdRename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YolesaBackend.Models.Beneficiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FullNames");

                    b.Property<int>("Gender");

                    b.Property<string>("IDNumber");

                    b.Property<bool>("IsSACitizen");

                    b.Property<int>("MemberID");

                    b.Property<string>("PassportNumber");

                    b.Property<string>("Relationship");

                    b.Property<string>("Surname");

                    b.Property<int>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MemberID");

                    b.ToTable("Beneficiary");
                });

            modelBuilder.Entity("YolesaBackend.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Industry");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PolicyNumber");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("YolesaBackend.Models.GroupUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("GroupID");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("YolesaBackend.Models.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Lead");
                });

            modelBuilder.Entity("YolesaBackend.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChronicIllnessDetails");

                    b.Property<string>("ContactNumber")
                        .IsRequired();

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("DebtDetails");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Employer");

                    b.Property<string>("EmployerContactNumber");

                    b.Property<string>("FullNames")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<int>("GroupID");

                    b.Property<bool>("HasChronicIllness");

                    b.Property<string>("IDNumber")
                        .HasMaxLength(13);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsEmployed");

                    b.Property<bool>("IsSACitizen");

                    b.Property<bool>("IsUnderDebtReview");

                    b.Property<string>("OtherContactNumber");

                    b.Property<string>("PassportNumber");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("TelephoneHome");

                    b.Property<int>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("YolesaBackend.Models.Beneficiary", b =>
                {
                    b.HasOne("YolesaBackend.Models.Member", "Member")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YolesaBackend.Models.GroupUser", b =>
                {
                    b.HasOne("YolesaBackend.Models.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YolesaBackend.Models.Member", b =>
                {
                    b.HasOne("YolesaBackend.Models.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}