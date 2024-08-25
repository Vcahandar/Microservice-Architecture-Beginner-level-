using FirstMicroService.Categories.WebAPI.Context;
using FirstMicroService.Categories.WebAPI.Dtos;
using FirstMicroService.Categories.WebAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

var app = builder.Build();

app.MapGet("/categories/getall",async (AppDbContext context,CancellationToken cancellationToken) =>
{
	var category = await context.Categories.ToListAsync(cancellationToken);

	return category;
});

app.MapPost("/categories/create", async ([FromBody] CreateCategoryDto request, [FromServices] AppDbContext context, CancellationToken cancellationToken) =>
{
	bool isNameExists = await context.Categories.AnyAsync(p => p.Name == request.Name, cancellationToken);

	if (isNameExists)
	{
		return Results.BadRequest(new { Message = "Category already exists" });
	}

	Category category = new()
	{
		Name = request.Name,
	};

	await context.Categories.AddAsync(category);
	await context.SaveChangesAsync(cancellationToken);

	return Results.Ok(new { Message = "Category creation is successful" });
});

app.Run();
