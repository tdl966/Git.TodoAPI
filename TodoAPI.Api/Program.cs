using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Api.AutoMapper;
using TodoAPI.BusinessLayer.Interfaces.Managers;
using TodoAPI.BusinessLayer.Interfaces.Repositories;
using TodoAPI.BusinessLayer.Interfaces.Services;
using TodoAPI.BusinessLayer.Managers;
using TodoAPI.BusinessLayer.Repositories;
using TodoAPI.BusinessLayer.Services;
using TodoAPI.DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appBuilder =>
    appBuilder.Run(async ctx =>
    {
        var ex = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;
        switch (ex)
        {
            case KeyNotFoundException knf:
                ctx.Response.StatusCode = StatusCodes.Status404NotFound;
                await ctx.Response.WriteAsJsonAsync(new { error = knf.Message });
                break;

            default:
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await ctx.Response.WriteAsJsonAsync(new { error = "Internal server error" });
                break;
        }
    })
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
