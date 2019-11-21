using MOD.AuthService.Dtos;
using MOD.AuthService.Model;
using MOD.AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Data
{
    public interface IRepository
    {
        IEnumerable<Course> GetCourses();
        bool AddCourses(Course course);
        Course GetCourse(int id);
        List<Course> SearchCourse(string criteria);
        bool UpdateCourse(Course course);
        bool DeleteCourse(Course course);
        IEnumerable<EnrolledCourse> GetEnrolledCourses();
        bool AddEnrolledCourses(EnrolledCourse enrolledCourse);
        List<EnrolledCourse> GetEnrolledCoursesByStudent(string modelEmail);
        List<EnrolledCourse> GetEnrolledCoursesByMentor(string modelEmail);
        bool ChangeCourseStatus(EnrolledCourse enrolledCourse,string UserEmail);
        IEnumerable<UserDto> GetMentorsList();
        IEnumerable<UserDto> GetUsersList();
        bool BlockUser(string id);
        UserDto mentorProfileDetails(string email);
        bool UpdateMentorDetails(ProfileDto modUser,string mentorId);
        UserDto studentProfileDetails(string email);
        bool UpdateStudentDetails(ProfileDto studentData, string studentId);
    }
}
