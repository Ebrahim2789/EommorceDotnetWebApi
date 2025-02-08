using Ecommorce.API.Controllers;
using Ecommorce.Application.Repository;
using Ecommorce.Model.IdentityModel;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Infrastructure.Services;
using Ecommorce.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NLog;
using Ecommorce.Application.ILogger;
using Ecommorce.Infrastructure.Logger;
using Ecommorce.Model.Profiles;
using Ecommorce.Infrastructure.Extension;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/Nlogs.config"));

builder.Services.AddDbContext<ApplicationDbContext>(opts => 
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"),b =>
b.MigrationsAssembly("Ecommorce.API")));

    builder.Services.AddScoped<ILoggerManger, LoggerManger>();

//AutoMapper injection

// Add services to the container.
 builder.Services.AddAutoMapper(typeof(DriverProfile));
//This is forall automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped< IRepositoryManager , RepositoryManager > ();



builder.Services.AddScoped<AuthService>();
 //ambiguous between the following methods or properties:
 //'Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions

builder.Services.AddIdentity<UsersIdentity ,  RoleIdentity>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddRazorPages();
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();


app.ConfigureExceptionHandler();


app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();

app.UseDefaultFiles(); // index.html, default.html, and so on
app.UseStaticFiles();

app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

//app.MapControllerRoute(name: "default",pattern: "{controller=Cars1}/{action=Index}/{id?}").WithStaticAssets();




app.Run();


