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
        object mentorProfileDetails(string email);
        object GetEnrolledCoursesByMentor(string modelEmail);
        bool UpdateMentorDetails(ProfileDto mentorData, string mentorId);
        bool ChangeCourseStatus(EnrolledCourse enrolledCourse, string userEmail);
    }
}
