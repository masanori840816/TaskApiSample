using Microsoft.EntityFrameworkCore;
using TaskApiSample;
using TaskApiSample.AppUsers.Auth;
using TaskApiSample.AppUsers.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthorization();
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
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddUserStore<AppUserStore>()
    .AddEntityFrameworkStores<OurTaskContext>();

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
app.UseCors(AllowedOrigins);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapGroup("/account").MapIdentityApi<AppUser>();
app.MapControllers();
app.Run();
