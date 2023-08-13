using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagerServices.Entities;

namespace NoteManagerServices.ConfigureFiles;

public class ConfigureUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.Property(u => u.Login)
            .HasColumnName("Login");
        
        builder.Property(u => u.Password)
            .HasColumnName("Password");
        
        builder.HasKey(u => u.Login);
        
        builder.HasMany(u => u.Notes)
            .WithOne(n => n.NoteUser)
            .HasPrincipalKey(u => u.Login)
            .HasForeignKey(n => n.UserLogin);
    }
}