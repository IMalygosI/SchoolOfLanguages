using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolOfLanguages.Models;

namespace SchoolOfLanguages.Context;

public partial class User738Context : DbContext
{
    public User738Context()
    {
    }

    public User738Context(DbContextOptions<User738Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<LinkingToFile> LinkingToFiles { get; set; }

    public virtual DbSet<ListTag> ListTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<VisitList> VisitLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.159;Database=user738;Username=user738;password=14053");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pk");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClientPhoto)
                .HasMaxLength(50)
                .HasColumnName("Client photo");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date of birth");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last name");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.RegistrationDate).HasColumnName("Registration date");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_gender_fk");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("file_pk");

            entity.ToTable("file");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NameGender)
                .HasColumnType("character varying")
                .HasColumnName("name gender");
        });

        modelBuilder.Entity<LinkingToFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("linking_to_files_pk");

            entity.ToTable("linking_to_files");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdFile).HasColumnName("id_file");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.LinkingToFiles)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("linking_to_files_client_fk");

            entity.HasOne(d => d.IdFileNavigation).WithMany(p => p.LinkingToFiles)
                .HasForeignKey(d => d.IdFile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("linking_to_files_file_fk");
        });

        modelBuilder.Entity<ListTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_tag_pk");

            entity.ToTable("list_tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdTag).HasColumnName("id_tag");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ListTags)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_tag_client_fk");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.ListTags)
                .HasForeignKey(d => d.IdTag)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_tag_tag_fk");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pk");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VisitList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_list_pk");

            entity.ToTable("visit_list");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Client).WithMany(p => p.VisitLists)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visit_list_client_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
