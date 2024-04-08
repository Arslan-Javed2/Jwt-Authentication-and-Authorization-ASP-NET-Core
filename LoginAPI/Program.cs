using LoginAPI.Data;
using LoginAPI.Repositories.Implementations;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
//this is to test the JSON web token authorization by sending the token in the header
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authorzation (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
    


builder.Services.AddDbContext<MyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal"))
);

builder.Services.AddScoped<IUserAPI, UserAPIRepository>();
builder.Services.AddScoped<IStudentAPI, StudentAPIRepository>();
builder.Services.AddScoped<ICategoryAPI, CategoryAPIRepository>();
builder.Services.AddScoped<IEmail, IEmailRepository>();
builder.Services.AddScoped<IPaymentDetailsAPI, PaymentDetailsAPIRepository>();


//this thing is necessary to read the JSON web token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey=true,
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("GHJJvhgghBVHGJH67867*^&8678t767VHHJVJHvkhjh")),
        ValidateIssuer=false,
        ValidateAudience=false

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//Attribute Routing (Routes are defined in the controller at controller or at action level)
app.MapControllers();

app.Run();
