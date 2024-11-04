var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
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
