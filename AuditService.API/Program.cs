using AuditService.DbContexts;
using AuditService.Entities.Entities.AuditEvents;
using AuditService.Entities.Models.OutgoingDtos.AuditEventDtos;
using AuditService.ModelBinders;
using AuditService.Services;
using AuditService.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    {
        options.ModelBinderProviders.Insert(0, new AuditServiceForCreationModelBinderProvider());
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
    });

#region CustomMiddleware

// add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add database & dbContext
builder.Services.AddDbContext<AuditDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:DbConnectionString"]);
});

// add custom services
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventMappingService<AuditEvent, AuditEventDto>, EventMappingService>();

builder.Services.AddScoped<ITrackedFileService, TrackedFileService>();
builder.Services.AddScoped<ITrackedUserService, TrackedUserService>();

builder.Services.AddScoped<IAuditEventBuilder, AuditEventBuilder>();
builder.Services.AddScoped<IAuditEventService, AuditEventService>();

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