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
using Ecommorce.API.Extentions;
using Ecommorce.API.Extentions.ActionFilters;
using AutoMapper;
using Ecommorce.Model.DTO.Incoming;
using Ecommorce.Application.Extensions;
using ProductProfile = Ecommorce.Model.Profiles.ProductProfile;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/Nlogs.config"));



//var startup = new Startup(builder.Configuration); // My custom startup class.

//startup.ConfigureServices(builder.Services); // Add services to the container.

//var app = builder.Build();

//startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

//app.Run();


builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"), b =>
b.MigrationsAssembly("Ecommorce.API")));

builder.Services.AddScoped<ILoggerManger, LoggerManger>();

// dataReshaping only required enitity will be reterned

builder.Services.AddScoped<IDataShaper<ProductDTO>, DataShaper<ProductDTO>>();

//AutoMapper injection

// Add services to the container.
builder.Services.AddAutoMapper(typeof(DriverProfile));

builder.Services.AddAutoMapper(typeof(ProductProfile));
//This is forall automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();

builder.Services.AddControllers(configs =>
{
    configs.RespectBrowserAcceptHeader = true;
    //configs.Filters.Add(new GlobalFilterExample());

    //configs.ReturnHttpNotAcceptable = true;

})

    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

});
    
 //   .AddNewtonsoftJson()
 //.AddXmlDataContractSerializerFormatters()
 //.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));


//builder.Services.AddScoped<GlobalFilterExample>();

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<MyService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();


builder.Services.AddHttpClient<ITokenService, TokenService>();
builder.Services.AddTransient<AuthenticatedHttpClientHandler>();
builder.Services.AddHttpClient("AuthenticatedClient")
    .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();



builder.Services.AddScoped<AuthService>();
//ambiguous between the following methods or properties:

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddSingleton<TokenStorage>();


builder.Services.AddRazorPages();
builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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


