﻿// <auto-generated />
using System;
using EzBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EzBooking.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EzBooking.Models.Feedback", b =>
                {
                    b.Property<int>("id_feedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_feedback"), 1L, 1);

                    b.Property<int?>("Reservationid_reservation")
                        .HasColumnType("int");

                    b.Property<int>("classification")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_feedback");

                    b.HasIndex("Reservationid_reservation");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("EzBooking.Models.House", b =>
                {
                    b.Property<int>("id_house")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_house"), 1L, 1);

                    b.Property<int?>("StatusHouseid")
                        .HasColumnType("int");

                    b.Property<int?>("Userid_user")
                        .HasColumnType("int");

                    b.Property<int?>("codDoor")
                        .HasColumnType("int");

                    b.Property<int>("doorNumber")
                        .HasColumnType("int");

                    b.Property<int>("floorNumber")
                        .HasColumnType("int");

                    b.Property<int>("guestsNumber")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postalCode")
                        .HasColumnType("int");

                    b.Property<double?>("price")
                        .HasColumnType("float");

                    b.Property<double?>("priceyear")
                        .HasColumnType("float");

                    b.Property<string>("propertyAssessment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("road")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("rooms")
                        .HasColumnType("int");

                    b.Property<bool>("sharedRoom")
                        .HasColumnType("bit");

                    b.HasKey("id_house");

                    b.HasIndex("StatusHouseid");

                    b.HasIndex("Userid_user");

                    b.HasIndex("postalCode");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("EzBooking.Models.Images", b =>
                {
                    b.Property<int>("id_image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_image"), 1L, 1);

                    b.Property<int>("Houseid_house")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_image");

                    b.HasIndex("Houseid_house");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EzBooking.Models.Payment", b =>
                {
                    b.Property<int>("id_payment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_payment"), 1L, 1);

                    b.Property<int>("Reservationid_reservation")
                        .HasColumnType("int");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("paymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("paymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("paymentValue")
                        .HasColumnType("real");

                    b.Property<int>("stateid_paymentStates")
                        .HasColumnType("int");

                    b.HasKey("id_payment");

                    b.HasIndex("Reservationid_reservation");

                    b.HasIndex("stateid_paymentStates");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("EzBooking.Models.PaymentStates", b =>
                {
                    b.Property<int>("id_paymentStates")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_paymentStates"), 1L, 1);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_paymentStates");

                    b.ToTable("PaymentStates");
                });

            modelBuilder.Entity("EzBooking.Models.PostalCode", b =>
                {
                    b.Property<int>("postalCode")
                        .HasColumnType("int");

                    b.Property<string>("concelho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postalCode");

                    b.ToTable("PostalCodes");
                });

            modelBuilder.Entity("EzBooking.Models.Reservation", b =>
                {
                    b.Property<int>("id_reservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_reservation"), 1L, 1);

                    b.Property<int?>("Houseid_house")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationStatesid")
                        .HasColumnType("int");

                    b.Property<int?>("Userid_user")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("guestsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("init_date")
                        .HasColumnType("datetime2");

                    b.HasKey("id_reservation");

                    b.HasIndex("Houseid_house");

                    b.HasIndex("ReservationStatesid");

                    b.HasIndex("Userid_user");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("EzBooking.Models.ReservationStates", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ReservationStates");
                });

            modelBuilder.Entity("EzBooking.Models.RevokedTokens", b =>
                {
                    b.Property<int>("id_revokedToken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_revokedToken"), 1L, 1);

                    b.Property<DateTime>("revocationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_revokedToken");

                    b.ToTable("RevokedTokens");
                });

            modelBuilder.Entity("EzBooking.Models.StatusHouse", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("StatusHouses");
                });

            modelBuilder.Entity("EzBooking.Models.User", b =>
                {
                    b.Property<int>("id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_user"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userTypeid_userType")
                        .HasColumnType("int");

                    b.HasKey("id_user");

                    b.HasIndex("userTypeid_userType");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EzBooking.Models.UserTypes", b =>
                {
                    b.Property<int>("id_userType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_userType"), 1L, 1);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_userType");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("EzBooking.Models.Feedback", b =>
                {
                    b.HasOne("EzBooking.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservationid_reservation");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("EzBooking.Models.House", b =>
                {
                    b.HasOne("EzBooking.Models.StatusHouse", "StatusHouse")
                        .WithMany()
                        .HasForeignKey("StatusHouseid");

<<<<<<< HEAD
                    b.HasOne("EzBooking.Models.User", null)
=======
                    b.HasOne("EzBooking.Models.User", "User")
>>>>>>> 7c5b44991fd4f4cc0aa53488f63f4e2698806586
                        .WithMany("Houses")
                        .HasForeignKey("Userid_user");

                    b.HasOne("EzBooking.Models.PostalCode", "PostalCode")
                        .WithMany()
                        .HasForeignKey("postalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostalCode");

                    b.Navigation("StatusHouse");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EzBooking.Models.Images", b =>
                {
                    b.HasOne("EzBooking.Models.House", "House")
                        .WithMany("Images")
                        .HasForeignKey("Houseid_house")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("EzBooking.Models.Images", b =>
                {
                    b.HasOne("EzBooking.Models.House", "House")
                        .WithMany("Images")
                        .HasForeignKey("Houseid_house")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("EzBooking.Models.Payment", b =>
                {
                    b.HasOne("EzBooking.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservationid_reservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EzBooking.Models.PaymentStates", "state")
                        .WithMany()
                        .HasForeignKey("stateid_paymentStates")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("state");
                });

            modelBuilder.Entity("EzBooking.Models.Reservation", b =>
                {
                    b.HasOne("EzBooking.Models.House", "House")
                        .WithMany("Reservations")
                        .HasForeignKey("Houseid_house");

                    b.HasOne("EzBooking.Models.ReservationStates", "ReservationStates")
                        .WithMany()
                        .HasForeignKey("ReservationStatesid");

                    b.HasOne("EzBooking.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("Userid_user");

                    b.Navigation("House");

                    b.Navigation("ReservationStates");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EzBooking.Models.User", b =>
                {
                    b.HasOne("EzBooking.Models.UserTypes", "userType")
                        .WithMany()
                        .HasForeignKey("userTypeid_userType");

                    b.Navigation("userType");
                });

            modelBuilder.Entity("EzBooking.Models.House", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("EzBooking.Models.User", b =>
                {
                    b.Navigation("Houses");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
