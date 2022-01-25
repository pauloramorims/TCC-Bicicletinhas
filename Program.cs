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

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("CorsPolicy");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Mapeamento dos endpoints 

                          //Parceiros
app.MapMethods(ParceirosGetAll.Template, ParceirosGetAll.Methods, ParceirosGetAll.Handle);

app.MapMethods(ParceirosGet.Template, ParceirosGet.Methods, ParceirosGet.Handle);

app.MapMethods(ParceirosPost.Template, ParceirosPost.Methods, ParceirosPost.Handle);

app.MapMethods(ParceiroDelete.Template, ParceiroDelete.Methods, ParceiroDelete.Handle);

//Documentos
app.MapMethods(DocFinanceirosGetAll.Template, DocFinanceirosGetAll.Methods, DocFinanceirosGetAll.Handle);

app.MapMethods(DocFinanceiroPost.Template, DocFinanceiroPost.Methods, DocFinanceiroPost.Handle);

app.MapMethods(DocFinanceiroDelete.Template, DocFinanceiroDelete.Methods, DocFinanceiroDelete.Handle);


app.Run();
