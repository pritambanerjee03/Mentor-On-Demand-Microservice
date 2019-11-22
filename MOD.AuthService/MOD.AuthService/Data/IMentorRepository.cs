using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Dtos;
using MOD.AuthService.Models;

namespace MOD.AuthService.Data
{
    public interface IMentorRepository
    {
        UserDto mentorProfileDetails(string email);
        List<EnrolledCourse> GetEnrolledCoursesByMentor(string modelEmail);
        bool ChangeCourseStatus(EnrolledCourse enrolledCourse, string UserEmail);
        bool UpdateMentorDetails(ProfileDto modUser, string mentorId);
    }
}
