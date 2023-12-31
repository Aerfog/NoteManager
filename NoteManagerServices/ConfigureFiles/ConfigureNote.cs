﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagerServices.Entities;

namespace NoteManagerServices.ConfigureFiles;

public class ConfigureNote : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");
        builder.Property(n => n.Title).HasColumnName("Title").HasMaxLength(70);
        builder.Property(n => n.NoteId).HasColumnName("NoteId");
        builder.HasKey(n => n.NoteId );
        builder.HasIndex(n => n.NoteId ).IsUnique();
        builder.Property(n => n.Body).HasColumnName("Body");
        builder.Property(n => n.UserId).HasColumnName("UserId");
        builder.Property(n => n.CreateDateTime).HasColumnName("CreatedDateTime").ValueGeneratedOnAdd();
        builder.Property(n => n.EditDateTime).HasColumnName("EditDateTime").ValueGeneratedOnAddOrUpdate();
    }
}