using FirstMicroService.Todos.WebAPI.Context;
using FirstMicroService.Todos.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseInMemoryDatabase("MyDb");
});

var app = builder.Build();

app.MapGet("/todos/creat", (string work, AppDbContext context) =>
{
	Todo todo = new Todo()
	{
		Work = work,
	};

	context.Add(todo);
	context.SaveChanges();

	return new { Message = "Todo Create is succesfull" };
});

app.MapGet("/todos/getall", (AppDbContext appDbContext) => { 

	var todos = appDbContext.Todos.ToList();
	return todos;
});

app.Run();
