using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Dtos;
using MOD.AuthService.Model;
using MOD.AuthService.Models;

namespace MOD.AuthService.Data
{
    public interface IAdminRepository
    {
        bool AddCourses(Course course);
        bool UpdateCourse(Course course);
        Course GetCourse(int id);
        bool DeleteCourse(Course course);
        IEnumerable<UserDto> GetMentorsList();
        IEnumerable<UserDto> GetUsersList();
        bool BlockUser(string id);
        IEnumerable<EnrolledCourse> GetEnrolledCourses();
    }
}
