using Ecommorce.Model.IdentityModel;
using Ecommorce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommorce.API.Controllers;
using Ecommorce.Application.Repository;
using Ecommorce.Infrastructure.Repository;
using Ecommorce.Infrastructure.Services;
using Ecommorce.Model.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommorce.Application.ILogger;
using Ecommorce.Infrastructure.Logger;
using Ecommorce.Infrastructure.Extension;
using Ecommorce.API.Extentions;

namespace Ecommorce.API
{
    public class Startup
    {

        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }
        //public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        //     builder.AddMvcOptions(config => config.OutputFormatters.Add(new
        //    CsvOutputFormatter()));

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(opts =>
             opts.UseSqlServer(configuration.GetConnectionString("DefaulConnection"), b =>
               b.MigrationsAssembly("Ecommorce.API")));



    //        services
    //.AddDbContext<ApplicationDbContext>(
    //    b => b.UseSqlServer(connectionString)
    //          .UseLazyLoadingProxies())
    //.AddDefaultIdentity<ApplicationUser>()
    //.AddEntityFrameworkStores<ApplicationDbContext>();




            services.AddScoped<ILoggerManger, LoggerManger>();

            services.AddMvc();




            // Add services to the container.
            services.AddAutoMapper(typeof(DriverProfile));
            //This is forall automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllersWithViews();

            services.AddControllers()
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                 });

            services.AddAuthentication(options =>
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
                     ValidIssuer = configuration["Jwt:Issuer"],
                     ValidAudience = configuration["Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                 };
             });


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<UserServices>();
            services.AddScoped<MyService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();


            services.AddHttpClient<ITokenService, TokenService>();
            services.AddTransient<AuthenticatedHttpClientHandler>();
            services.AddHttpClient("AuthenticatedClient")
                 .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();



            services.AddScoped<AuthService>();
            //ambiguous between the following methods or properties:

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                         .AddEntityFrameworkStores<ApplicationDbContext>()
                         //.AddDefaultUI()
                         .AddDefaultTokenProviders();

            services.AddSingleton<TokenStorage>();


            services.AddRazorPages();
            services.AddAuthorization();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
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


        }
    }
}
