using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebionLibraryAPI;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
using WebionLibraryAPI.Service;
using WebionLibraryAPI.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebionLibraryAPI",
        Version = "v1"
    });
    c.DocumentFilter<SwaggerTagDescriptions>();
});

// Add services to the container.
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebionLibraryAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
