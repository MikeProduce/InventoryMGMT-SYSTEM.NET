using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using InventoryMGMT_SYSTEM.NET.Models;

namespace InventoryMGMT_SYSTEM.NET.Data;

public partial class InventoryMGMTDbContext : DbContext
{
    public InventoryMGMTDbContext()
    {
    }

    public InventoryMGMTDbContext(DbContextOptions<InventoryMGMTDbContext> options)
            : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<RentalOrder> RentalOrders { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=InventoryMGMTConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__3FB50F949A8F0955");

            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemCost)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("Item_Cost");
            entity.Property(e => e.ItemDetails)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Item_Details");
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Item_Name");
            entity.Property(e => e.ItemStatusId).HasColumnName("Item_Status_ID");
            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");

            entity.HasOne(d => d.ItemStatus).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemStatusId)
                .HasConstraintName("FK__Item__Item_Statu__04E4BC85");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK__Item__Item_Type___03F0984C");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.ItemTypeId).HasName("PK__Item_Typ__335FBDF248E18D61");

            entity.ToTable("Item_Type");

            entity.Property(e => e.ItemTypeId).HasColumnName("Item_Type_ID");
            entity.Property(e => e.ItemTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Item_Type_Name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__8C1160B5CE770171");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");
            entity.Property(e => e.NotificationDate)
                .HasColumnType("datetime")
                .HasColumnName("Notification_Date");
            entity.Property(e => e.NotificationTypeId).HasColumnName("Notification_Type_ID");
            entity.Property(e => e.RentalOrderId).HasColumnName("Rental_Order_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .HasConstraintName("FK__Notificat__Notif__10566F31");

            entity.HasOne(d => d.RentalOrder).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.RentalOrderId)
                .HasConstraintName("FK__Notificat__Renta__0F624AF8");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__User___0E6E26BF");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.NotificationTypeId).HasName("PK__Notifica__7732B56108420CCE");

            entity.ToTable("Notification_Type");

            entity.Property(e => e.NotificationTypeId).HasColumnName("Notification_Type_ID");
            entity.Property(e => e.NotificationTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Notification_Type_Name");
        });

        modelBuilder.Entity<RentalOrder>(entity =>
        {
            entity.HasKey(e => e.RentalOrderId).HasName("PK__Rental_O__AB32D1ABDCEAAD35");

            entity.ToTable("Rental_Order");

            entity.Property(e => e.RentalOrderId).HasColumnName("Rental_Order_ID");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("Total_Cost");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.RentalOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Rental_Or__User___07C12930");

            entity.HasMany(d => d.Items).WithMany(p => p.RentalOrders)
                .UsingEntity<Dictionary<string, object>>(
                    "RentalOrderItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Rental_Or__Item___0B91BA14"),
                    l => l.HasOne<RentalOrder>().WithMany()
                        .HasForeignKey("RentalOrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Rental_Or__Renta__0A9D95DB"),
                    j =>
                    {
                        j.HasKey("RentalOrderId", "ItemId").HasName("PK__Rental_O__F8C98152F0112091");
                        j.ToTable("Rental_Order_Item");
                        j.IndexerProperty<int>("RentalOrderId").HasColumnName("Rental_Order_ID");
                        j.IndexerProperty<int>("ItemId").HasColumnName("Item_ID");
                    });
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__519009AC522F7CB6");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D9190B98B7B29");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("User_Type");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
