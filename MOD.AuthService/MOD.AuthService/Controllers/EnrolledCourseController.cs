using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.AuthService.Data;
using MOD.AuthService.Models;

namespace MOD.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolledCourseController : ControllerBase
    {
        IRepository repository;
        public EnrolledCourseController(IRepository repository)
        {
            this.repository = repository;
        }
       
        

        
       
        // GET: api/EnrolledCourse/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return null;
        }

        // POST: api/EnrolledCourse
       

        // PUT: api/EnrolledCourse/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpPut("ChangeEnrolledCourseStatus/{id}/{UserEmail}")]
        [Authorize(Roles = "Student,Mentor")]
        public IActionResult ChangeCourseStatus(int id,string UserEmail,[FromBody] EnrolledCourse enrolledCourse)
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
