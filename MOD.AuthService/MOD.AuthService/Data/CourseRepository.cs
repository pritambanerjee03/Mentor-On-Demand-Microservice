using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.AuthService.Dtos;
using MOD.AuthService.Model;
using MOD.AuthService.Models;

namespace MOD.AuthService.Data
{
    public class CourseRepository :IRepository
    {
        
        MentorOnDemandContext context;
        public CourseRepository(MentorOnDemandContext context)
        {
            this.context = context;
        }

        public bool AddCourses(Course course)
        {
            try
            {
                context.Courses.Add(course);
                int result = context.SaveChanges(); 
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool AddEnrolledCourses(EnrolledCourse enrolledCourse)
        {
            try
            {
                var result1 = from c in context.EnrolledCourses
                              where c.StudentEmail == enrolledCourse.StudentEmail 
                                    && c.Name == enrolledCourse.Name
                              select c;
                if(result1.Count() == 0)
                {
                    context.EnrolledCourses.Add(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)    
                    {
                        return true;
                    }
                }
                
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool BlockUser(string id)
        {
            {
                var userblock = context.MODUsers.SingleOrDefault(u => u.Id == id);
                userblock.Active = !userblock.Active;
            }
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool ChangeCourseStatus(EnrolledCourse enrolledCourse,string UserEmail)
        {
            try
            {
                if(UserEmail ==  enrolledCourse.MentorEmail)
                {
                    if(enrolledCourse.Status == "Requested")
                    {
                        enrolledCourse.Status = "Request Accepted";
                    }
                    else if (enrolledCourse.Status == "In Progress")
                    {
                        enrolledCourse.Status = "Completed";
                    }
                    context.EnrolledCourses.Update(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }
                else if (UserEmail == enrolledCourse.StudentEmail && enrolledCourse.Status == "Request Accepted")
                {
                    enrolledCourse.Status = "In Progress";
                    context.EnrolledCourses.Update(enrolledCourse);
                    int result = context.SaveChanges();
                    if (result > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool DeleteCourse(Course course)
        {
            try
            {
                context.Courses.Remove(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Course GetCourse(int id)
        {
            var result = from a in context.Courses
                         where a.Id == id
                         select a;
            return result.SingleOrDefault();
        }

        public IEnumerable<Course> GetCourses()
        {
            return this.context.Courses.ToList();
        }

        public IEnumerable<EnrolledCourse> GetEnrolledCourses()
        {
            
            return this.context.EnrolledCourses.ToList();
        }

        public List<EnrolledCourse> GetEnrolledCoursesByMentor(string modelEmail)
        {
            var result = from c in context.EnrolledCourses
                         where c.MentorEmail == modelEmail
                         select c;
            return result.ToList();
        }

        public List<EnrolledCourse> GetEnrolledCoursesByStudent(string modelEmail)
        {
            var result = from c in context.EnrolledCourses
                         where c.StudentEmail == modelEmail
                         select c;
            return result.ToList();
        }

        public IEnumerable<UserDto> GetMentorsList()
        {
            var mentor = from a in context.MODUsers
                         join ma in context.UserRoles on a.Id equals ma.UserId
                         where ma.RoleId == "2"
                         select new UserDto
                         {
                             id = a.Id,
                             Active = a.Active,
                             Experience = a.Experience,
                             FirstName = a.FirstName,
                             LastName = a.LastName,
                             Skills = a.Skills,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber

                         };
            return mentor;
        }

        public IEnumerable<UserDto> GetUsersList()
        {
            var user = from a in context.MODUsers
                         join ma in context.UserRoles on a.Id equals ma.UserId
                         where ma.RoleId == "3"
                         select new UserDto
                         {
                             id = a.Id,
                             Active = a.Active,
                             FirstName = a.FirstName,
                             LastName = a.LastName,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber

                         };
            return user;
        }

        public UserDto mentorProfileDetails(string email)
        {
            var result = from a in context.MODUsers
                         where a.Email == email
                         select new UserDto
                         {
                             id = a.Id,
                             Experience = a.Experience,
                             FirstName = a.FirstName,
                             LastName = a.LastName,
                             Skills = a.Skills,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber
                         };
            return result.SingleOrDefault();
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

        public UserDto studentProfileDetails(string email)
        {
            var result = from a in context.MODUsers
                         where a.Email == email
                         select new UserDto
                         {
                             id = a.Id,
                             FirstName = a.FirstName,
                             LastName = a.LastName,
                             Email = a.Email,
                             PhoneNumber = a.PhoneNumber
                         };
            return result.SingleOrDefault();
        }

        public bool UpdateCourse(Course course)
        {
            try
            {
                context.Courses.Update(course);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool UpdateMentorDetails(ProfileDto modUser,string mentorId)
        {
            try
            {
                var user = (from a in context.MODUsers
                             where a.Id == mentorId
                             select a).SingleOrDefault();
                if(user !=null)
                {
                    user.Id = modUser.id;
                    user.Email = modUser.Email;
                    user.FirstName = modUser.FirstName;
                    user.LastName = modUser.LastName;
                    user.PhoneNumber = modUser.PhoneNumber;
                    user.Skills = modUser.Skills;
                    user.Experience = modUser.Experience;

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
                
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateStudentDetails(ProfileDto modUser, string studentId)
        {
            try
            {
                var user = (from a in context.MODUsers
                            where a.Id == studentId
                            select a).SingleOrDefault();
                if (user != null)
                {
                    user.Id = modUser.id;
                    user.Email = modUser.Email;
                    user.FirstName = modUser.FirstName;
                    user.LastName = modUser.LastName;
                    user.PhoneNumber = modUser.PhoneNumber;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
