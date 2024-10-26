using System;
using System.Collections.Generic;
using Kazino.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Kazino.Server.Data;

public partial class KazinoContext : DbContext
{
    public KazinoContext()
    {
    }

    public KazinoContext(DbContextOptions<KazinoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPromo> UserPromos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("promo_pkey");

            entity.ToTable("promo");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.EndDatime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_datime");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Kod)
                .HasMaxLength(50)
                .HasColumnName("kod");
            entity.Property(e => e.LikeCount).HasColumnName("like_count");
            entity.Property(e => e.PromoText).HasColumnName("promo_text");
            entity.Property(e => e.ShortDiscription)
                .HasMaxLength(100)
                .HasColumnName("short_discription");
            entity.Property(e => e.StartDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_datetime");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Promos)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("promo_category_id_fkey");

            entity.HasOne(d => d.Tag).WithMany(p => p.Promos)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("promo_tag_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pkey");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.RoleId, "fki_role_id_fkey");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_id_fkey");
        });

        modelBuilder.Entity<UserPromo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_promo_pkey");

            entity.ToTable("user_promo");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.PromoId).HasColumnName("promo_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Promo).WithMany(p => p.UserPromos)
                .HasForeignKey(d => d.PromoId)
                .HasConstraintName("promo_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserPromos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("user_promo_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
