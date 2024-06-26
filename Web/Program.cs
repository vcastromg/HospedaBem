using Application.Repositories;
using Application.Services;
using Application.Services.Implementations;
using DataGeneration;
using DataGeneration.Implementations;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infra;
using Infra.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(
        options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<RoomRepository, RoomRepositoryImp>();
builder.Services.AddScoped<RoomService, RoomServiceImp>();
builder.Services.AddScoped<HotelRepository, HotelRepositoryImp>();
builder.Services.AddScoped<HotelService, HotelServiceImp>();
builder.Services.AddScoped<ReviewRepository, ReviewRepositoryImp>();
builder.Services.AddScoped<ReviewService, ReviewServiceImp>();
builder.Services.AddScoped<AppUserRepository, AppUserRepositoryImp>();
builder.Services.AddScoped<AppUserService, AppUserServiceImp>();
// builder.Services.AddScoped<UserManager<AppUser>, AppUserServiceImp>();
builder.Services.AddScoped<BookingRepository, BookingRepositoryImp>();
builder.Services.AddScoped<BookingService, BookingServiceImp>();
builder.Services.AddScoped<Generator, GeneratorImp>();

builder.Services.AddSwaggerGen();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.Run();