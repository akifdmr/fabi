using AutoMapper;
using Fabi.Core;
using Fabi.Core.appsettings;
using Fabi.Core.Entities.Models;
using Fabi.EF.Data;
using Fabi.Services.Helpers.FilesHnadler;
using Fabi.Services.Helpers.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movies.EF.Seeding;
using Net6_Controller_And_VIte;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var env = builder.Environment;
var configuration = builder.Configuration;



services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
services.AddScoped<global::Fabi.Core.Interfaces.ITokenHandler, global::Fabi.Services.Helpers.TokenHandler>();

//register unitOfWork for our program 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileHandler, FileHandler>();

//builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


//add AutoMapper
var mapperConfig = new MapperConfiguration(mc => {
    //mc.AddProfile(new MovieMappingProfile());
    mc.AddProfile(new AuthMappingProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());



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



services.AddCors();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MoviesApi",
        Description = "Build API with ASP.Net Core (.Net 6) that secured with JWT.",
        Contact = new OpenApiContact
        {
            Name = "Nada Mahmoud",
            Email = "nada.mhmudd@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/nada-mhmudd/")
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



services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
        spa.UseViteDevelopmentServer(sourcePath: "ClientApp");
});
//seed database 
//SeedDatabase();

//add core before authorization
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//----------------Helper Method-----------------------------


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
//app.UseSpa(spa =>
//{
//    if (app.Environment.IsDevelopment())
//        spa.UseViteDevelopmentServer(sourcePath: "ClientApp");
//});

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    };
}