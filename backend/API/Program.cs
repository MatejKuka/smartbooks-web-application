using System.Text.Json.Serialization;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<PostCourseDTO, Course>();
    configuration.CreateMap<Course, CourseExistDTO>();

    configuration.CreateMap<PostLessonDTO, Lesson>();
    configuration.CreateMap<Lesson, LessonExistDTO>();
    
    configuration.CreateMap<PostPSDTO, PersonalStatistics>();
    configuration.CreateMap<PersonalStatistics, PSExistDTO>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(
    "Data source=db.db"
));

Application.DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);

Infrastructure.DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructure(builder.Services);

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();