using Tomoyo.Core.Models;

namespace Tomoyo.Core.Utilities.Data;

/// <summary>
/// Starter data for seeding the database
/// </summary>
public static class StarterData
{
    public static TomoyoRole[] Roles { get; } = new[]
    {
        new TomoyoRole
        {
            Id = "1",
            Name = "Superuser",
            NormalizedName = "SUPERUSER"
        },
        new TomoyoRole
        {
            Id = "2",
            Name = "Staff",
            NormalizedName = "Staff"
        },
        new TomoyoRole
        {
            Id = "3",
            Name = "User",
            NormalizedName = "USER"
        }
    };
}