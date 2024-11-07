using Microsoft.EntityFrameworkCore;
using TaskApiSample;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("OurTasks"));

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

var app = builder.Build();
app.UseCors(AllowedOrigins);
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
