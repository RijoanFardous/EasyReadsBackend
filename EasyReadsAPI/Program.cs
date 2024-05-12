using EasyReadsAPI.Auth;
using EasyReadsBLL.Services;
using EasyReadsDAL;
using EasyReadsDAL.EF;
using EasyReadsDAL.Interfaces;
using EasyReadsDAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<EasyReadsContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<DataAccessFactory>();
//builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<LoggedAttribute>();
builder.Services.AddScoped<AuthorAttribute>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
            .AllowAnyOrigin() // Consider restricting this to your frontend URL in production
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
