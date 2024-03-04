using AuditService.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region CustomMiddleware

// automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// database
builder.Services.AddDbContext<AuditDbContext>(options =>
{
    options.UseSqlite("Data Source=AuditDb.sqlite");
});

// custom service injection

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();