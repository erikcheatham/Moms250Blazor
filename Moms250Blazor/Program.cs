using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moms250Blazor.Common;
using Moms250Blazor.Components;
using Moms250Blazor.Components.Account;
using Moms250Blazor.Data;
using Moms250Blazor.Data.Repository;
using Moms250Blazor.Services;

namespace Moms250Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SMTP"));
            builder.Services.Configure<AzureBlobStorageConfig>(builder.Configuration.GetSection("AzureBlobStorageConfig"));

            // Initialize Context Links
            var cdn = builder.Configuration["AppSettings:CdnURL"]?.ToString() ?? "";
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
            var weburl = builder.Configuration["AppSettings:WebsiteURL"]?.ToString() ?? "";
            ContextSettings.Configure(cdn, connectionString, weburl);

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ContextSettings.DBConnection));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            //builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            // Add application repositories
            builder.Services.AddTransient<IAssignmentsRepo, AssignmentsRepo>();
            builder.Services.AddTransient<IAttachmentsRepo, AttachmentsRepo>();
            builder.Services.AddTransient<IAttachmentsForAllRepo, AttachmentsForAllRepo>();
            builder.Services.AddTransient<IExceptionLogRepo, ExceptionLogRepo>();
            builder.Services.AddTransient<IStatesRepo, StatesRepo>();
            builder.Services.AddTransient<IVolunteersRepo, VolunteersRepo>();
            builder.Services.AddTransient<IUsersRepo, UsersRepo>();

            // Add outside services 
            builder.Services.AddTransient<IAzureBlobService, AzureBlobService>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
