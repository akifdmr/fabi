using AutoMapper;
using Fabi.Core.appsettings;
using Fabi.EF.Data;
using Fabi.Services.Helpers.FilesHnadler;
using Fabi.Services.Helpers.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.EF.Seeding;
using Net6_Controller_And_VIte;
using Newtonsoft.Json.Serialization;
using System.Text;
using Serilog;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Fabi.App.Middlewares;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Application starting up...");


    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    IWebHostEnvironment environment = builder.Environment;
    IServiceCollection? services = builder.Services;

 builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    string dbConn = builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new Exception("Connection String missing!");
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(dbConn);
    });

   services.AddControllersWithViews().AddNewtonsoftJson(newtonsoftJson =>
    {
        newtonsoftJson.SerializerSettings.Converters.Add(new StringEnumConverter());
        newtonsoftJson.SerializerSettings.NullValueHandling = NullValueHandling.Include;
        newtonsoftJson.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
   
   
  services.AddCors(c =>
              {
                  c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
              });
    // services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


    //builder.Services.AddScoped<IDbInitializer, DbInitializer>();


    //add AutoMapper
    var mapperConfig = new MapperConfiguration(mc =>
    {
        //mc.AddProfile(new MovieMappingProfile());
        mc.AddProfile(new AuthMappingProfile());
    });
    services.AddSingleton(mapperConfig.CreateMapper());

    //add JWT
    services.AddAuthentication(options =>
    { //default options
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });


   services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.AddScoped<global::Fabi.Core.Interfaces.ITokenHandler, global::Fabi.Services.Helpers.TokenHandler>();
    //register unitOfWork for our program 
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IFileHandler, FileHandler>();


  if (environment.IsDevelopment())
    {
        services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Fabi App",
            Description = "Build API with ASP.Net Core (.Net 7) that secured with JWT.",
            Contact = new OpenApiContact
            {
                Name = "Mehmet Akif Demir",
                Email = "akifdmr@gmail.com"
            }
        });
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
        });
    });
      }

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList SPA API V1");
        });

#if DEBUG
        bool seed = app.Configuration.GetValue<bool>("seed");
        if (seed)
        {
            using IServiceScope scope = app.Services.CreateScope();
            ApplicationDbContext? context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            // DbInitializer.SeedDb(context!);
        }
#endif
    }
    
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    //seed database 
    //SeedDatabase();
    app.UseMiddleware<ErrorHandlerMiddleware>();

    //add core before authorization
 app.UseCors(opts =>
    {
        opts.WithOrigins("https://localhost:3000");
    });
      if (app.Environment.IsDevelopment())
        app.MapGet("/", (HttpResponse response) => response.Redirect("/swagger")).ExcludeFromDescription();
    else
        app.MapGet("/", () => "").ExcludeFromDescription();


      app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");

    app.Run();



    void SeedDatabase()
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            dbInitializer.Initialize();
        };
    }
}
catch (Exception ex)
{
    if (ex.GetType().Name.Equals("HostAbortedException", StringComparison.Ordinal))
        throw;
    Log.Fatal(ex, "Unhandled error in application. Application will now exit.");
}
finally
{
    Log.Information("Application shutting down...");
    Log.CloseAndFlush();
}