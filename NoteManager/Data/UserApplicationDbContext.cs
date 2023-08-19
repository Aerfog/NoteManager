using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NoteManager.Data;

public class UserApplicationDbContext : IdentityDbContext
{
    public UserApplicationDbContext(DbContextOptions<UserApplicationDbContext> options)
        : base(options)
    {
    }
}