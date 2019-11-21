using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.AuthService.Data;
using MOD.AuthService.Dtos;
using MOD.AuthService.Models;

namespace MOD.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository repository;
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("studentProfile/{email}")]
        [Authorize(Roles = "Student")]
        public IActionResult studentProfileDetails(string email)
        {
            var result = repository.studentProfileDetails(email);
            return Ok(result);
        }

        [HttpPut("studentProfile/{studentId}")]
        [Authorize(Roles = "Student")]
        public IActionResult UpdateStudentDetails(string studentId, [FromBody] ProfileDto studentData)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.UpdateStudentDetails(studentData, studentId);
                if (result)
                {
                    return Created("UpdatedProfie", null);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ListOfCourse/{modelEmail}")]
        [Authorize(Roles = "Student")]
        public IActionResult GetEnrolledCoursesByStudent(string modelEmail)
        {
            var result = repository.GetEnrolledCoursesByStudent(modelEmail);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult Post([FromBody] EnrolledCourse enrolledCourse)
        {
            if (ModelState.IsValid)
            {

                bool result = repository.AddEnrolledCourses(enrolledCourse);
                if (result)
                {
                    return Created("AddCoursesEnrolled", enrolledCourse);
                }
                return BadRequest(new { Message = "You have already Enrolled for This Course." });

                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("ChangeEnrolledCourseStatus/{id}/{UserEmail}")]
        [Authorize(Roles = "Student")]
        public IActionResult ChangeCourseStatus(int id, string UserEmail, [FromBody] EnrolledCourse enrolledCourse)
        {
            if (ModelState.IsValid && id == enrolledCourse.Id)
            {
                bool result = repository.ChangeCourseStatus(enrolledCourse, UserEmail);
                if (result)
                {
                    return Created("UpdatedCourse", enrolledCourse.Id);
                }
            }
            return BadRequest(ModelState);
        }





        // GET: api/Student
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
