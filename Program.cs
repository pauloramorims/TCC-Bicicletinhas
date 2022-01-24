using TirandoAsRodinhas.Endpoints;
using TirandoAsRodinhas.Endpoints.Financeiro;
using TirandoAsRodinhas.Endpoints.Parceiros;
using TirandoAsRodinhas.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:BiciSemRodinhas"]);

builder.Services.AddScoped<QueryAllParceiros>();
builder.Services.AddScoped<QueryParceiros>();
builder.Services.AddScoped<QueryAllDocsFinanceiros>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(ParceirosGetAll.Template, ParceirosGetAll.Methods, ParceirosGetAll.Handle);

app.MapMethods(ParceirosGet.Template, ParceirosGet.Methods, ParceirosGet.Handle);

app.MapMethods(DocFinanceirosGetAll.Template, DocFinanceirosGetAll.Methods, DocFinanceirosGetAll.Handle);

app.Run();
