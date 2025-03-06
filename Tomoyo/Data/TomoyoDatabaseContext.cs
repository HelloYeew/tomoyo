using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
}