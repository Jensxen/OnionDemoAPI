using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application;
using OnionDemo.Application.Command;
using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Query;
using OnionDemo.Infrastructure;
using OnionDemo.Infrastructure.Queries;
using OnionDemo.Api.Controllers;
using OnionDemo.Application.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application and Infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IAddressValidationCommand, AddressValidationCommand>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IDawaQuery, DawaQuery>();
builder.Services.AddHostedService<PendingAddressChecker>();
builder.Services.AddScoped<IAddressValidationQuery, AddressValidationQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
app.MapGet("/hello", () => "Hello World");

app.MapGet("/booking", (IBookingQuery query) => query.GetBookings());
app.MapGet("/booking/{id}", (int id, IBookingQuery query) => query.GetBooking(id));
app.MapPost("/booking", (CreateBookingDto booking, IBookingCommand command) => command.CreateBooking(booking));
app.MapPut("/booking", (UpdateBookingDto booking, IBookingCommand command) => command.UpdateBooking(booking));
app.MapDelete("/Delete", ([FromBody] DeleteBookingDto booking, IBookingCommand command) => command.DeleteBooking(booking));


//Accommodation endpoints
//app.MapGet("/accommodation", (IAccommodationQuery query) => query.GetAccommodation());
//app.MapGet("/accommodation/{id}", (int id, IAccommodationQuery query) => query.GetAccommodation(id));
//app.MapGet("/accommodation/host/{hostId}", (int hostId, IAccommodationQuery query) => query.GetAccommodations(hostId));

app.MapControllers();

app.Run();
