using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UserAPI.Models;
using System.Text;
using UserAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var connectionString = builder.Configuration.GetConnectionString("UserDbConnection");
//builder.Services.AddDbContext<DigitalBooksContext>(x => x.UseSqlServer(connectionString));
//builder.Services.AddSwaggerGen(x =>
//{
//    x.SwaggerDoc("v2", new OpenApiInfo { Title = "UserApp", Version = "v2" });
//    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "Please enter token enter 'bearer' [space] <token>"
//    });
//    x.AddSecurityRequirement(new OpenApiSecurityRequirement {
//                    {
//                        new OpenApiSecurityScheme
//                        {
//                            Reference=new OpenApiReference
//                            {
//                                Type=ReferenceType.SecurityScheme,
//                                Id="Bearer"
//                            }
//                        },
//                        new string[]{ }
//                    }
//                });
//});
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
//               AddJwtBearer(options =>
//               {
//                   options.TokenValidationParameters = new TokenValidationParameters
//                   {
//                       ValidateIssuer = false,
//                       ValidateAudience = false,
//                       ValidateLifetime = true,
//                       ValidateIssuerSigningKey = true,
//                       ValidIssuer = builder.Configuration["jwt:Issuer"],
//                       ValidAudience = builder.Configuration["jwt:Audience"],
//                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"]))
//                   };
//               });
//builder.Services.AddAuthorization();
//builder.Services.AddCors();
//builder.Services.AddScoped<IUser, UserService>();

await using var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v2/swagger.json", "UserApp v2"); });
}

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
