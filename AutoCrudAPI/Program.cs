using AutoCrudAPI.GenericControllerMapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add generic controller mapping to generate all controller from Libraries' BaseModels
builder.Services.AddMvc(o => o.Conventions.Add(new ControllerRouteMap()))
    .ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new ControllerMap()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
