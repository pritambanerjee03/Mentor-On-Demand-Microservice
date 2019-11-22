using MOD.AuthService.Dtos;
using MOD.AuthService.Model;
using MOD.AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Data
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        List<Course> SearchCourse(string criteria);   
    }
}
