using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
});

var todoItems = app.MapGroup("/todoitems");
CTodo cTodo = new CTodo();

todoItems.MapGet("/", cTodo.GetAllTodos);
todoItems.MapGet("/complete", cTodo.GetCompleteTodos);
todoItems.MapGet("/{id}", cTodo.GetTodo);
todoItems.MapPost("/", cTodo.CreateTodo);
todoItems.MapPut("/{id}", cTodo.UpdateTodo);
todoItems.MapDelete("/{id}", cTodo.DeleteTodo);

app.Run();
