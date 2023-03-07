using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventPlannerWebApplication.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/MyEvents"); //Pentru a nu permite sa intre sa-si creeze eveniment daca nu sunt logati
    options.Conventions.AllowAnonymousToPage("/Drinks/Edit"); //pentru a nu le permite utilizatorilor la edit in Drinks
   } ); 
builder.Services.AddDbContext<EventPlannerWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventPlannerWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'EventPlannerWebApplicationContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("EventPlannerWebApplicationContext") ?? throw new InvalidOperationException("Connectionstring 'EventPlannerWebApplicationContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = true) 
    .AddRoles<IdentityRole>()  //serviciile de autorizare bazate pe roluri
    .AddEntityFrameworkStores<LibraryIdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
