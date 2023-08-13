using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagerServices.Entities;

namespace NoteManagerServices.ConfigureFiles;

public class ConfigureNote : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("Notes");
        builder.Property(n => n.Title).HasColumnName("Title");
        builder.Property(n => n.Body).HasColumnName("Body");
        builder.Property(n => n.NoteId).HasColumnName("NoteId").ValueGeneratedOnAdd();
        builder.Property(n => n.UserLogin).HasColumnName("UserLogin");
        builder.Property(n => n.CreateDateTime).HasColumnName("CreatedDateTime").ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Property(n => n.EditDateTime).HasColumnName("EditDateTime").ValueGeneratedOnAddOrUpdate().HasDefaultValue(DateTime.Now);
        builder.HasKey(n => new { n.UserLogin, n.NoteId });
        builder.HasOne(n => n.NoteUser)
            .WithMany(u => u.Notes)
            .HasPrincipalKey(u => u.Login)
            .HasForeignKey(n => n.UserLogin);
    }
}