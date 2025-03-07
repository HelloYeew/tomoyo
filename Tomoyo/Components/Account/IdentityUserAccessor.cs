using Microsoft.AspNetCore.Identity;
using Tomoyo.Core.Models;

namespace Tomoyo.Components.Account;

internal sealed class IdentityUserAccessor(
    UserManager<TomoyoUser> userManager,
    IdentityRedirectManager redirectManager)
{
    public async Task<TomoyoUser> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser",
                $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}