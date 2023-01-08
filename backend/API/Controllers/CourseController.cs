using Application.DTOs;
using Application.Interfaces.services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SmartBooksAPI.Controllers;

[ApiController]
[Route("")]
public class CourseController : ControllerBase
{
    private ICourseService _courseService;
        
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    [Route("courses")]
    public JsonResult GetAllCoursesWithoutLessons()
    {
        return new JsonResult(_courseService.GetAllCoursesWithoutLessons());
    }

    [HttpPost]
    [Route("courses")]
    public JsonResult CreateNewCourse(PostCourseDTO courseDto)
    {
        try
        {
            var newCourseReturn = _courseService.CreateNewCourse(courseDto);
            return new JsonResult(newCourseReturn);
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
    [Route("courses/{idCourse}")]
    public JsonResult DeleteCourseById(int idCourse)
    {
        try
        {
            return new JsonResult(_courseService.DeleteCourse(idCourse));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No course found with ID " + idCourse));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }
}