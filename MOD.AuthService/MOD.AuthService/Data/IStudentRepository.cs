﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Dtos;
using MOD.AuthService.Models;

namespace MOD.AuthService.Data
{
    public interface IStudentRepository
    {
        bool UpdateStudentDetails(ProfileDto studentData, string studentId);
        UserDto studentProfileDetails(string email);
        List<EnrolledCourse> GetEnrolledCoursesByStudent(string modelEmail);
        bool AddEnrolledCourses(EnrolledCourse enrolledCourse);
        bool ChangeCourseStatus(EnrolledCourse enrolledCourse, string UserEmail);
    }
}
