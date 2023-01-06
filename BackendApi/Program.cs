using ScoreGathering.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoreGathering(builder.Configuration["ScoreGathering:AppName"]!, 
    typeof(Program).Assembly.GetName().Version!, 
    builder.Configuration["ScoreGathering:ScoreSaberApiUrl"]!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(settings =>
{
    settings.AllowAnyMethod();
    settings.AllowAnyHeader();
    settings.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();