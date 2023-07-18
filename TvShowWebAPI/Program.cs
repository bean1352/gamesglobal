using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TvShowWebAPI.Authentication;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// For Entity Framework  
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));  

// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()  
    .AddEntityFrameworkStores<ApplicationDbContext>()  
    .AddDefaultTokenProviders();  

// Adding Authentication  
builder.Services.AddAuthentication(options =>  
{  
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
})  

// Adding Jwt Bearer  
.AddJwtBearer(options =>  
{  
    options.SaveToken = true;  
    options.RequireHttpsMetadata = false;  
    options.TokenValidationParameters = new TokenValidationParameters()  
    {  
        ValidateIssuer = false,  
        ValidateAudience = false,  
        ValidAudience = Configuration["JWT:ValidAudience"],  
        ValidIssuer = Configuration["JWT:ValidIssuer"],  
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))  
    };  
});  

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins(new string [] {"http://127.0.0.1:5173"})
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
