using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskApiSample;
using TaskApiSample.AppUsers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OurTaskContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("OurTasks")));

const string AllowedOrigins = "AllowedOrigins";
builder.Services.AddCors(options =>
    {
        options.AddPolicy(AllowedOrigins,
            builder =>
            {
                builder.WithOrigins("http://localhost:5173", "http://localhost:5155")
                       .AllowAnyHeader() // ヘッダーの許可
                       .AllowAnyMethod(); // メソッドの許可
            });
    });
builder.Services.AddIdentity<AppUser, IdentityRole<long>>()
                .AddEntityFrameworkStores<OurTaskContext>()
                .AddDefaultTokenProviders();

var app = builder.Build();
app.UseCors(AllowedOrigins);
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
