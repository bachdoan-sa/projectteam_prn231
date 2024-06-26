﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Repository.Infaustructure;

#nullable disable

namespace WebApp.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240221090659_UpdateBaseEntity0")]
    partial class UpdateBaseEntity0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Repository.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Birthdate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OtpCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OtpExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BeginDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("StaffId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AuctionEvents");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionState", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionEventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionStateStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<double?>("ExpectedPrice")
                        .HasColumnType("float");

                    b.Property<double?>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<double?>("MaxRaise")
                        .HasColumnType("float");

                    b.Property<double?>("MinRaise")
                        .HasColumnType("float");

                    b.Property<string>("OrchidId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<double?>("StartingPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AuctionEventId");

                    b.HasIndex("OrchidId");

                    b.ToTable("AuctionStates");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.DealHanger", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionStateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Currency")
                        .HasColumnType("float");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DealStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AuctionStateId");

                    b.HasIndex("CustomerId");

                    b.ToTable("DealHangers");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Mutation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MutationPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mutations");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Orchid", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrchidCategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrchidStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductOwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrchidCategoryId");

                    b.HasIndex("ProductOwnerId");

                    b.ToTable("Orchids");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrchidCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("OrchidsCategories");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrchidMutation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MutationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrchidId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Shape")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MutationId");

                    b.HasIndex("OrchidId");

                    b.ToTable("OrchidsMutations");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrderDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("OrchidId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderDetailStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrchidId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReponseTime")
                        .HasColumnType("bigint");

                    b.Property<string>("TransactionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Balance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WalletType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Account", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionEvent", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Account", "Account")
                        .WithMany("AuctionEvents")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionState", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.AuctionEvent", "AuctionEvent")
                        .WithMany("AuctionStates")
                        .HasForeignKey("AuctionEventId");

                    b.HasOne("WebApp.Repository.Entities.Orchid", "Orchid")
                        .WithMany("AuctionStates")
                        .HasForeignKey("OrchidId");

                    b.Navigation("AuctionEvent");

                    b.Navigation("Orchid");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.DealHanger", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.AuctionState", "AuctionState")
                        .WithMany("DealHangers")
                        .HasForeignKey("AuctionStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Repository.Entities.Account", "Account")
                        .WithMany("DealHangers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("AuctionState");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Orchid", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.OrchidCategory", "OrchidCategory")
                        .WithMany("Orchids")
                        .HasForeignKey("OrchidCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Repository.Entities.Account", "Account")
                        .WithMany("Orchids")
                        .HasForeignKey("ProductOwnerId");

                    b.Navigation("Account");

                    b.Navigation("OrchidCategory");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrchidMutation", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Mutation", "Mutation")
                        .WithMany("OrchidMutations")
                        .HasForeignKey("MutationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Repository.Entities.Orchid", "Orchid")
                        .WithMany("OrchidMutations")
                        .HasForeignKey("OrchidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mutation");

                    b.Navigation("Orchid");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Order", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrderDetail", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Orchid", "Orchid")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrchidId");

                    b.HasOne("WebApp.Repository.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orchid");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Transaction", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Wallet", b =>
                {
                    b.HasOne("WebApp.Repository.Entities.Account", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Account", b =>
                {
                    b.Navigation("AuctionEvents");

                    b.Navigation("DealHangers");

                    b.Navigation("Orchids");

                    b.Navigation("Orders");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionEvent", b =>
                {
                    b.Navigation("AuctionStates");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.AuctionState", b =>
                {
                    b.Navigation("DealHangers");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Mutation", b =>
                {
                    b.Navigation("OrchidMutations");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Orchid", b =>
                {
                    b.Navigation("AuctionStates");

                    b.Navigation("OrchidMutations");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.OrchidCategory", b =>
                {
                    b.Navigation("Orchids");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebApp.Repository.Entities.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
