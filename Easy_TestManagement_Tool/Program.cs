global using Easy_TestManagement_Tool.Models;
global using Microsoft.EntityFrameworkCore;
global using Easy_TestManagement_Tool.Enums;
global using Easy_TestManagement_Tool;
using Easy_TestManagement_Tool.Data;
using Easy_TestManagement_Tool.Services.TestCaseService;
using Easy_TestManagement_Tool.Services.TestRunService;
using Easy_TestManagement_Tool.Services.TestStepService;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using Your.Namespace;
using Easy_TestManagement_Tool.Services.ReportService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<EnumSchemaFilter>();
});
builder.Services.AddScoped<ITestCaseService, TestCaseService>();
builder.Services.AddScoped<ITestRunService, TestRunService>();
builder.Services.AddScoped<ITestStepService, TestStepService>();
builder.Services.AddScoped<IReportService, ReportService>();


builder.Services.AddControllers(/*Other config*/).AddJsonOptions(options =>
{

    /*
    .. Other config
    */
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddDbContext<DataContext>(); ;

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


