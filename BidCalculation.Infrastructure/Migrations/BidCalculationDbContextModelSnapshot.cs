﻿// <auto-generated />
using System;
using BidCalculation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BidCalculation.Infrastructure.Migrations
{
    [DbContext(typeof(BidCalculationDbContext))]
    partial class BidCalculationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("BidCalculation.Domain.Entities.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("BidCalculation.Domain.Entities.Bid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BasePriceId")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("BasePriceId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("BidCalculation.Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BidCalculation.Domain.ValueObjects.Money", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("BidCalculation.Domain.Entities.Bid", b =>
                {
                    b.HasOne("BidCalculation.Domain.Entities.Auction", "Auction")
                        .WithMany("Bids")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BidCalculation.Domain.ValueObjects.Money", "BasePrice")
                        .WithMany()
                        .HasForeignKey("BasePriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("BasePrice");
                });

            modelBuilder.Entity("BidCalculation.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("BidCalculation.Domain.Entities.Auction", "Auction")
                        .WithMany("Vehicles")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("BidCalculation.Domain.Entities.Auction", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
