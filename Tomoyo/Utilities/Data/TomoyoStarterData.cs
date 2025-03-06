using Tomoyo.Data;

namespace Tomoyo.Utilities.Data;

/// <summary>
/// Starter data for seeding the database
/// </summary>
public static class TomoyoStarterData
{
    public static TomoyoRole[] Roles { get; } = new[]
    {
        new TomoyoRole
        {
            Id = "1",
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN"
        },
        new TomoyoRole
        {
            Id = "2",
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new TomoyoRole
        {
            Id = "3",
            Name = "User",
            NormalizedName = "USER"
        }
    };
}