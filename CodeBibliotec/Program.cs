using CodeBibliotec.Context;
using CodeBibliotec.Interfaces;
using CodeBibliotec.Repositories;
using CodeBibliotec.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);


// Pegando a string de conexão do appsettings.json para configurar o contexto do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BibliotecContext>(options => options.UseSqlServer(connectionString));

// Registra dependecias (injeção de dependencias)
// onde AddScoped define que uma nova instância do serviço será criada para cada requisição HTTP,
// também é feita a associação entre as interfaces e suas respectivas implementações,
// garantindo que as camadas de repositório e serviço sejam injetadas corretamente nas camadas superiores (serviço e controle, respectivamente).

builder.Services.AddScoped<ILivroRepository, LivroRepository>(); // injetar a camada de repositório na camada de serviço
builder.Services.AddScoped<ILivroService, LivroService>(); 

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>(); 
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Add services to the container.
// adicionando serialização para evitar erros de ciclos
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = 
    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; // para evitar o erro de referência dos ciclos, ignorando eles
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add JWT authentication to Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Input your Bearer token in this format - Bearer {your token here} to access this API"
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });


});

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
