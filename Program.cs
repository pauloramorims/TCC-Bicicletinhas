using TirandoAsRodinhas.Endpoints;
using TirandoAsRodinhas.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:BiciSemRodinhas"]);

builder.Services.AddScoped<QueryAllPessoasFisicas>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(PessoasFisGetAll.Template, PessoasFisGetAll.Methods, PessoasFisGetAll.Handle);

app.Run();
