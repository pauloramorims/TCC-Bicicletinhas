using TirandoAsRodinhas.Endpoints;
using TirandoAsRodinhas.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:BiciSemRodinhas"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(RegisterGetAll.Template, RegisterGetAll.Methods, RegisterGetAll.Handle);

app.Run();
