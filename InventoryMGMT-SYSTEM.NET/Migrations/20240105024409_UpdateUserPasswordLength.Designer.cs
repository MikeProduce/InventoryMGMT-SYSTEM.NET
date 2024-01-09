﻿// <auto-generated />
using System;
using InventoryMGMT_SYSTEM.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryMGMT_SYSTEM.NET.Migrations
{
    [DbContext(typeof(InventoryMGMTDbContext))]
    [Migration("20240105024409_UpdateUserPasswordLength")]
    partial class UpdateUserPasswordLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Item_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<decimal?>("ItemCost")
                        .HasColumnType("decimal(19, 4)")
                        .HasColumnName("Item_Cost");

                    b.Property<string>("ItemDetails")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Item_Details");

                    b.Property<string>("ItemName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Item_Name");

                    b.Property<int?>("ItemStatusId")
                        .HasColumnType("int")
                        .HasColumnName("Item_Status_ID");

                    b.Property<int?>("ItemTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Item_Type_ID");

                    b.HasKey("ItemId")
                        .HasName("PK__Item__3FB50F949A8F0955");

                    b.HasIndex("ItemStatusId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Item_Type_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemTypeId"));

                    b.Property<string>("ItemTypeName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Item_Type_Name");

                    b.HasKey("ItemTypeId")
                        .HasName("PK__Item_Typ__335FBDF248E18D61");

                    b.ToTable("Item_Type", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<DateTime?>("NotificationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Notification_Date");

                    b.Property<int?>("NotificationTypeId")
                        .HasColumnType("int")
                        .HasColumnName("Notification_Type_ID");

                    b.Property<int?>("RentalOrderId")
                        .HasColumnType("int")
                        .HasColumnName("Rental_Order_ID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("NotificationId")
                        .HasName("PK__Notifica__8C1160B5CE770171");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("RentalOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.NotificationType", b =>
                {
                    b.Property<int>("NotificationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_Type_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationTypeId"));

                    b.Property<string>("NotificationTypeName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Notification_Type_Name");

                    b.HasKey("NotificationTypeId")
                        .HasName("PK__Notifica__7732B56108420CCE");

                    b.ToTable("Notification_Type", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.RentalOrder", b =>
                {
                    b.Property<int>("RentalOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Rental_Order_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalOrderId"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("End_Date");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Start_Date");

                    b.Property<decimal?>("TotalCost")
                        .HasColumnType("decimal(19, 4)")
                        .HasColumnName("Total_Cost");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("RentalOrderId")
                        .HasName("PK__Rental_O__AB32D1ABDCEAAD35");

                    b.HasIndex("UserId");

                    b.ToTable("Rental_Order", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Status_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Status_Name");

                    b.HasKey("StatusId")
                        .HasName("PK__Status__519009AC522F7CB6");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserType")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("User_Type");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId")
                        .HasName("PK__User__206D9190B98B7B29");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("RentalOrderItem", b =>
                {
                    b.Property<int>("RentalOrderId")
                        .HasColumnType("int")
                        .HasColumnName("Rental_Order_ID");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("Item_ID");

                    b.HasKey("RentalOrderId", "ItemId")
                        .HasName("PK__Rental_O__F8C98152F0112091");

                    b.HasIndex("ItemId");

                    b.ToTable("Rental_Order_Item", (string)null);
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Item", b =>
                {
                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.Status", "ItemStatus")
                        .WithMany("Items")
                        .HasForeignKey("ItemStatusId")
                        .HasConstraintName("FK__Item__Item_Statu__04E4BC85");

                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .HasConstraintName("FK__Item__Item_Type___03F0984C");

                    b.Navigation("ItemStatus");

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Notification", b =>
                {
                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.NotificationType", "NotificationType")
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTypeId")
                        .HasConstraintName("FK__Notificat__Notif__10566F31");

                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.RentalOrder", "RentalOrder")
                        .WithMany("Notifications")
                        .HasForeignKey("RentalOrderId")
                        .HasConstraintName("FK__Notificat__Renta__0F624AF8");

                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Notificat__User___0E6E26BF");

                    b.Navigation("NotificationType");

                    b.Navigation("RentalOrder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.RentalOrder", b =>
                {
                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.User", "User")
                        .WithMany("RentalOrders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Rental_Or__User___07C12930");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentalOrderItem", b =>
                {
                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK__Rental_Or__Item___0B91BA14");

                    b.HasOne("InventoryMGMT_SYSTEM.NET.Models.RentalOrder", null)
                        .WithMany()
                        .HasForeignKey("RentalOrderId")
                        .IsRequired()
                        .HasConstraintName("FK__Rental_Or__Renta__0A9D95DB");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.ItemType", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.NotificationType", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.RentalOrder", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.Status", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("InventoryMGMT_SYSTEM.NET.Models.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("RentalOrders");
                });
#pragma warning restore 612, 618
        }
    }
}