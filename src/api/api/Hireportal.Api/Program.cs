using Hireportal.Api.Extensions;
using Hireportal.Common;
using Azure.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

#region Check Environment

var section = builder.Configuration.GetSection($"{nameof(Settings)}");
var settings = section.Get<Settings>();
#endregion Check Environment

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwt(settings)
                .AddData(builder.Configuration)
                .AddDataServices()
                .AddAutoMapper();

builder.Services.AddCors(option => { option.AddPolicy(builder.Environment.EnvironmentName, p => { p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); }); });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(builder.Environment.EnvironmentName);

app.UseAuthentication();
app.UseAuthorization();
app.UseClaims();
app.MapControllers();
app.Run();

public partial class Program
{ }