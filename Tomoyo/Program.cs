using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Tomoyo.Components;
using Tomoyo.Components.Account;
using Tomoyo.Core.Configurations;
using Tomoyo.Core.Models;
using Tomoyo.Core.Services;
using Tomoyo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddHttpClient();

switch (CoreSettings.ProfileStorageType)
{
    case StorageType.Local:
        builder.Services.AddSingleton<IProfileStorage, LocalProfileStorage>();
        break;
    
    case StorageType.S3:
        builder.Services.AddSingleton<IProfileStorage, S3ProfileStorage>();
        break;
    
    default:
        // TODO: Test should not initialize storage, but should still run.
        throw new InvalidOperationException($"PROFILE_STORAGE_TYPE environment variable is not set to a valid value. (Value: {CoreSettings.ProfileStorageType})\n" +
                                            $"Valid values are: {string.Join(", ", Enum.GetNames(typeof(StorageType)))}");
}

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<TomoyoDatabaseContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<TomoyoUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<TomoyoRole>()
    .AddEntityFrameworkStores<TomoyoDatabaseContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<TomoyoUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();