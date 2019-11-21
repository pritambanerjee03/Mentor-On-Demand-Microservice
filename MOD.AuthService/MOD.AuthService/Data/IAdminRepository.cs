using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Model;

namespace MOD.AuthService.Data
{
    public interface IAdminRepository
    {
        bool AddCourses(Course course);
        bool UpdateCourse(Course course);
        object GetCourse(int id);
        bool DeleteCourse(object course);
        object GetUsersList();
        object GetMentorsList();
        object BlockUser(string id);
        object GetEnrolledCourses();
    }
}
