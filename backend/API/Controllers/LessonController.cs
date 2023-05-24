using Application.DTOs;
using Application.Interfaces.services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SmartBooksAPI.Controllers;

[ApiController]
[Route("")]
public class LessonController : ControllerBase
{
    private ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    [Route("lessons/{idCourse}")]
    public JsonResult GetAllLessonsByCourseId(int idCourse)
    {
        return new JsonResult(_lessonService.GetAllLessonsByCourseId(idCourse));
    }

    [HttpGet]
        [Route("")]
        public JsonResult TestMethod()
        {
            return new JsonResult("Hello");
        }

    [HttpPost]
    [Route("lessons")]
    public JsonResult CreateLesson(PostLessonDTO lessonDto)
    {
        try
        {
            var newLessonReturn = _lessonService.CreateLesson(lessonDto);
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
    [Route("lessons/{idLesson}")]
    public JsonResult DeleteLesson(int idLesson)
    {
        try
        {
            return new JsonResult(_lessonService.DeleteLesson(idLesson));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No lesson found with ID " + idLesson));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }
    
}