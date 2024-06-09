using System.Text;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ApiVelozesEAlugados.Infraestrutura.Repositories;
using IPessoaRepositoryNameSpace;
using ApiVelozesEAlugados.Domain.Models.UsuarioRe;
using ICarroRepositoryNameSpace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Converte entidade para DTO
//builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Higor - 27/05/2024 - Injeção de dependencias seguida instrução Vídeo 2 Filipe Brito
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ICarroRepository, CarroRepository>();

//Versionamento - Adicionar futuramente 

/*builder.Services.AddApiVersioning(options =>
{
   // Especifique a estrat�gia de versionamento desejada (por exemplo, pela URL, pelo cabe�alho da solicita��o, etc.)
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    // Adicione a vers�o padr�o
   options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});*/

builder.Services.AddSwaggerGen(c =>
{
   c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
   {
       Name = "Authorization",
       In = ParameterLocation.Header,
       Type = SecuritySchemeType.ApiKey,
       Scheme = "Bearer"
   });

   c.AddSecurityRequirement(new OpenApiSecurityRequirement()
   {
   {
       new OpenApiSecurityScheme
       {
       Reference = new OpenApiReference
           {
           Type = ReferenceType.SecurityScheme,
           Id = "Bearer"
           },
           Scheme = "oauth2",
           Name = "Bearer",
           In = ParameterLocation.Header,

       },
       new List<string>()
       }
   });


});

//Inje��o de dep�ndecia - Usar os metodos sem precisar instaciar o objeto
//builder.Services.AddTransient<IFuncionariorepository, FuncionarioRepository>();



builder.Services.AddCors(options =>
{
   options.AddPolicy(name: "MinhaPolitica",
           policy =>
           {
               policy.WithOrigins("http://localhost:8080", "http://localhost:5502", "https://localhost:7090", "http://127.0.0.1:5500")
               .AllowAnyMethod()
               .AllowAnyHeader()
           ;
           }
       );
});

var key = Encoding.ASCII.GetBytes(ApiTeste.Key.Secret);

builder.Services.AddAuthentication(x =>
{
   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
   x.RequireHttpsMetadata = false;
   x.SaveToken = true;
   x.TokenValidationParameters = new TokenValidationParameters
   {
       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(key),
       ValidateIssuer = false,
       ValidateAudience = false
   };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/error-development");
   app.UseSwagger();
   app.UseSwaggerUI();
}
else
{
   app.UseExceptionHandler("/error");
}

app.UseCors("MinhaPolitica");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
