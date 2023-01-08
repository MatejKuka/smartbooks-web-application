using Application.DTOs;
using Application.Interfaces.services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SmartBooksAPI.Controllers;

[ApiController]
[Route("personalstatistics")]
public class PersonalStatisticsController : ControllerBase
{
    private IPersonalStatisticsService _personalStatisticsService;

    public PersonalStatisticsController(IPersonalStatisticsService personalStatisticsService)
    {
        _personalStatisticsService = personalStatisticsService;
    }

    [HttpGet]
    [Route("{idLesson}")]
    public JsonResult GetAllPersonalStatisticsByLessonId(int idLesson)
    {
        return new JsonResult(_personalStatisticsService.GetAllPersonalStatisticsByLessonId(idLesson));
    }
    
    [HttpPost]
    [Route("")]
    public JsonResult CreateLesson(PostPSDTO psDto)
    {
        try
        {
            var newLessonReturn = _personalStatisticsService.CreatePersonalStatistics(psDto);
            return new JsonResult(newLessonReturn);
        }
        catch (ValidationException v)
        {
            return new JsonResult(BadRequest(v.Message));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.Message));
        }
    }
    
    [HttpDelete]
    [Route("{idPersonalStatistics}")]
    public JsonResult DeletePersonalStatistics(int idPS)
    {
        try
        {
            return new JsonResult(_personalStatisticsService.DeletePersonalStatistics(idPS));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No personal statistics found with ID " + idPS));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }
    
    [HttpGet]
    [Route("lesson/{idCourse}")]
    public JsonResult GetAllPersonalStatisticsWithLessonsByCourseId(int idCourse)
    {
        return new JsonResult(_personalStatisticsService.GetAllPersonalStatisticsWithLessonsByCourseId(idCourse));
    }
}