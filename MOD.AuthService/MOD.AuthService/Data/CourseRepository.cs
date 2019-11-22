using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Dtos;
using MOD.AuthService.Model;
using MOD.AuthService.Models;

namespace MOD.AuthService.Data
{
    public class CourseRepository :ICourseRepository
    {
        
        MentorOnDemandContext context;
        public CourseRepository(MentorOnDemandContext context)
        {
            this.context = context;
        }
        public IEnumerable<Course> GetCourses()
        {
            return this.context.Courses.ToList();
        }
        public List<Course> SearchCourse(string criteria)
        {
            if (int.TryParse(criteria, out int result))
            {
                return (from c in context.Courses
                        where c.Id == result
                        select c).ToList();
            }

            return (from c in context.Courses   
                    where c.Name.Contains(criteria)
                    select c).ToList();

        }  
    }
}
