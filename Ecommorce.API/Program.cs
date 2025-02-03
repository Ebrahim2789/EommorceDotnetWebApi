using Ecommorce.API;
using Ecommorce.API.Controllers;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;
using Ecommorce.Model.IdentityModel;
using Ecommorce.Infrastructure.Repositories;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Infrastructure.Services;
using Ecommorce.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using NLog;
using Ecommorce.Application.ILogger;
using Ecommorce.Infrastructure.Logger;
using Ecommorce.Model.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ecommorce.Infrastructure.Extension;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Nlogs.config"));

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();


builder.Services.AddScoped<AuthService>();


builder.Services.AddIdentity<UsersIdentity ,  RoleIdentity>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cars1}/{action=Index}/{id?}")


    .WithStaticAssets();



//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    await CreateRole(service);
//}

app.Run();



async Task CreateRole(IServiceProvider serviceProvider)
{
    var roleManger = serviceProvider.GetRequiredService<RoleManager<RoleIdentity>>();
    var userManger = serviceProvider.GetRequiredService<UserManager<UsersIdentity>>();

    string roleName = "Admin";
    string userEmail = "admin@example.com";
    string userPassword = "Admin@123";

    if (!await roleManger.RoleExistsAsync(roleName))
    {

        await roleManger.CreateAsync(new RoleIdentity(roleName));
    }
    var user = await userManger.FindByEmailAsync(userEmail);
    if (user == null)
    {
        user = new UsersIdentity { UserName = userEmail, Email = userEmail };
        await userManger.CreateAsync(user, userPassword);
        await userManger.AddToRoleAsync(user, roleName);
    }


}