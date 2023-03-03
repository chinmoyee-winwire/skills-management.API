using skills_management.api.Domain.Category.Queries;
using skills_management.api.Domain.Interfaces.Commands;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Domain.Practices.Queries;
using skills_management.api.Domain.ProficiencyLevel.Queries;
using skills_management.api.Domain.SkillMatrix.Commands;
using skills_management.api.Domain.SkillMatrix.Queries;
using skills_management.api.Domain.TechnologyStack.Queries;
using skills_management.api.Repository.Interfaces;
using skills_management.api.Repository;
using skills_management.api.Helpers;
using skills_management.api.Context;
using skills_management.api.Contracts;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            // .WithOrigins("http://localhost:3000")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

builder.Services.AddSingleton<SkillsManagementContext>();
builder.Services.AddScoped<IPracticesRepository, PracticesRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ITechnologyStackRepository, TechnologyStackRepository>();
builder.Services.AddScoped<IProficiencyLevelRepository, ProficiencyLevelRepository>();
builder.Services.AddScoped<ISkillMatrixRepository, SkillsMatrixRepository>();
builder.Services.AddScoped<IPractices, GetPractices>();

builder.Services.AddScoped<ICategories, GetCategories>();
builder.Services.AddScoped<IProficiencyLevel, GetProficiencyLevel>();
builder.Services.AddScoped<ITechnologyStack, GetTechnologyStack>();
builder.Services.AddScoped<ISkillMatrix, GetSkillMatrix>();
builder.Services.AddScoped<ICreateSkillMatrix, CreateSkillMatrix>();
builder.Services.AddScoped<IUpdateSkillMatrix, UpdateSkillMatrix>();
// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.Position));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();

