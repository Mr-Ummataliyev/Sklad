using Sklad.Application;
using Sklad.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureDepencyInjection(builder.Configuration);
builder.Services.AddApplicationDepencyInjection();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("MobileCors", 
          policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
    }
    
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()|| app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MobileCors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
