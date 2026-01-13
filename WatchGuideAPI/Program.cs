using WatchGuideAPI.Services;
using Microsoft.EntityFrameworkCore;
using WatchGuideAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsql =>
        {
            npgsql.EnableRetryOnFailure();
            npgsql.CommandTimeout(60);
        }
    )
);

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IWatchmodeService, WatchGuideAPI.Services.WatchmodeService>();
builder.Services.AddHttpClient<ITMDBService, WatchGuideAPI.Services.TMDBService>();

builder.Services.AddScoped<IAuthService, WatchGuideAPI.Services.AuthService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IWatchmodeService, WatchGuideAPI.Services.WatchmodeService>();
builder.Services.AddScoped<ITMDBService, WatchGuideAPI.Services.TMDBService>();
builder.Services.AddScoped<ITrendingService, WatchGuideAPI.Services.TrendingService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();