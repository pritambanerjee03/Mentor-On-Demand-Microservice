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
    public class MentorController : ControllerBase
    {
        IMentorRepository repository;
        public MentorController(IMentorRepository repository)
        {
            this.repository = repository;
        }




        [HttpGet("mentorProfile/{email}")]
        [Authorize(Roles = "Mentor")]
        public IActionResult mentorProfileDetails(string email)
        {
            var result = repository.mentorProfileDetails(email);
            return Ok(result);
        }

        [HttpPut("mentorProfile/{mentorId}")]
        [Authorize(Roles = "Mentor")]
        public IActionResult UpdateMentorDetails(string mentorId, [FromBody] ProfileDto mentorData)
        {
            if (ModelState.IsValid)
            {
                bool result = repository.UpdateMentorDetails(mentorData, mentorId);
                if (result)
                {
                    return Created("UpdatedProfie", null);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ListOfCourseMentor/{modelEmail}")]
        [Authorize(Roles = "Mentor")]
        public IActionResult GetEnrolledCoursesByMentor(string modelEmail)
        {
            var result = repository.GetEnrolledCoursesByMentor(modelEmail);
            return Ok(result);
        }
        [HttpPut("ChangeEnrolledCourseStatus/{id}/{UserEmail}")]
        [Authorize(Roles = "Mentor")]
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


        // GET: api/Mentor
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mentor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mentor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mentor/5
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
