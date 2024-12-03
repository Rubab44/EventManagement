using BlazorAuthPolicy;
using BlazorAuthPolicy.Components;
using BlazorAuthPolicy.Components.Pages.Account;
using BlazorAuthPolicy.Data;
using BlazorAuthPolicy.Service;
using BlazorAuthPolicy.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();
builder.Services.AddAuthorization(config =>
{
	foreach (var userPolicy in UserPolicy.GetPolicies())
	{
		config.AddPolicy(userPolicy, cfg => cfg.RequireClaim(userPolicy, "true"));
	}
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "auth_token";
		options.LoginPath = "/login";
		options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
		options.AccessDeniedPath = "/access-denied";
	});
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventCategoryService, EventCategoryService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("ConnString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
