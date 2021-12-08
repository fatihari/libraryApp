using System.Text.Json;
using LibraryApp.Business.Abstract;
using LibraryApp.Business.Abstract.Dtos;
using LibraryApp.Business.Concrete;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Concrete.EFCore;
using LibraryApp.WebAPI.Extensions;
using LibraryApp.WebAPI.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllers(o =>{
    o.Filters.Add(new ValidationFilter()); // A validation filter will be automatically added to each check. 
});
// Learn more about configuring Swagger/OpemnAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// via dbcontext provide connection 
builder.Services.AddDbContext<LibraryContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"), o => {
        o.MigrationsAssembly("LibraryApp.DataAccess");
    });
});

//  Now transforming objects will be done with Automapper.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//  If "more than one" IUnitOfWork interface is encountered in a class's constructor, 
//  it will get an object instance from EFCoreUnitOfWork. 
builder.Services.AddScoped<IUnitOfWork, EFCoreUnitOfWork>(); // transient every time that is not one time run.
builder.Services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Manager<>));
builder.Services.AddScoped<IAuthorService, AuthorManager>(); // These are not generics, Hence no use of "typeof". 
builder.Services.AddScoped<IBookService, BookManager>();

//  The developer will handle the API's error display method. 
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Don't check the filters, I'll do it. We will create ErrorDTO
});
builder.Services.AddScoped<NotFoundFilter>(); // add notfoundfilter as service.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException(); // we use custom exception method in UseUseCustomExceptionHandler.cs in the extensions folder

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
