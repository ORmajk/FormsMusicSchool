using Microsoft.EntityFrameworkCore;
using MusicSchoolApp.Data;
using MusicSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicSchoolApp.Services
{
    public class DataService : IDisposable
    {
        private MusicSchoolDbContext context;

        public DataService()
        {
            context = new MusicSchoolDbContext();
        }

        // Аутентификация
        public User GetUserByLoginPassword(string login, string password)
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.Benefit)
                .FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        // Пользователи
        public List<User> GetAllUsers()
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.Benefit)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.Benefit)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsersByRole(string roleName)
        {
            return context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.RoleName == roleName)
                .ToList();
        }

        public Benefit GetBenefitById(int benefitId)
        {
            return new MusicSchoolDbContext().Benefits.FirstOrDefault(b => b.Id == benefitId);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            try
            {
                var existingUser = context.Users.Find(user.Id);

                if (existingUser != null)
                {
                    context.Entry(existingUser).CurrentValues.SetValues(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении пользователя: {ex.Message}", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        // Роли
        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        // Льготы
        public List<Benefit> GetAllBenefits()
        {
            return context.Benefits.ToList();
        }

        // Курсы
        public List<Course> GetAllCourses()
        {
            return context.Courses
                .Include(c => c.CourseType)
                .Include(c => c.Teacher)
                .ToList();
        }

        public Course GetCourseById(int id)
        {
            return context.Courses
                .Include(c => c.CourseType)
                .Include(c => c.Teacher)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetCoursesByTeacher(int teacherId)
        {
            return context.Courses
                .Include(c => c.CourseType)
                .Where(c => c.TeacherId == teacherId)
                .ToList();
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            return context.GroupMembers
                .Include(gm => gm.Group)
                .ThenInclude(g => g.Course)
                .ThenInclude(c => c.CourseType)
                .Where(gm => gm.StudentId == studentId)
                .Select(gm => gm.Group.Course)
                .Distinct()
                .ToList();
        }

        public List<CourseType> GetCourseTypes()
        {
            return context.CourseTypes.ToList();
        }

        public void AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                // Найти существующую запись
                var existingCourse = context.Courses.Find(course.Id);

                if (existingCourse != null)
                {
                    // Обновить свойства
                    context.Entry(existingCourse).CurrentValues.SetValues(course);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Курс не найден");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении курса: {ex.Message}", ex);
            }
        }

        
        public void DeleteCourse(int courseId, int userId)
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        // Расписание
        public List<ClassSchedule> GetAllSchedules()
        {
            return context.ClassSchedules
                .Include(cs => cs.Group)
                .ThenInclude(g => g.Course)
                .Include(cs => cs.Teacher)
                .ToList();
        }

        public List<ClassSchedule> GetScheduleForStudent(int studentId)
        {
            return context.ClassSchedules
                .Include(cs => cs.Group)
                .ThenInclude(g => g.Course)
                .Where(cs => cs.Group.Members.Any(m => m.StudentId == studentId))
                .OrderBy(cs => cs.DayOfWeek)
                .ThenBy(cs => cs.StartTime)
                .ToList();
        }

        public List<ClassSchedule> GetScheduleForTeacher(int teacherId)
        {
            return context.ClassSchedules
                .Include(cs => cs.Group)
                .ThenInclude(g => g.Course)
                .Where(cs => cs.TeacherId == teacherId)
                .OrderBy(cs => cs.DayOfWeek)
                .ThenBy(cs => cs.StartTime)
                .ToList();
        }

        public void DeleteSchedule(int scheduleId)
        {
            var schedule = context.ClassSchedules.Find(scheduleId);
            if (schedule != null)
            {
                context.ClassSchedules.Remove(schedule);
                context.SaveChanges();
            }
        }

        public List<Achievement> GetAchievementsByUser(int userId)
        {
            return context.Achievements
                .Include(a => a.AchievementType)
                .Include(a => a.Course)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.AchievementDate)
                .ToList();
        }

        public void Dispose()
        {
            context?.Dispose();
        }


        public bool IsLoginExists(string login)
        {
            return context.Users.Any(u => u.Login == login);
        }

        public List<StudyGroup> GetAllGroups()
        {
            return context.StudyGroups
                .Include(g => g.Course)
                .Include(g => g.Teacher)
                .ToList();
        }

        public List<User> GetTeachers()
        {
            return context.Users
                .Include(u => u.Role)
                .Where(u => u.RoleId.HasValue && u.RoleId >= 4 && u.RoleId <= 7)
                .ToList();
        }

        public ClassSchedule GetScheduleById(int id)
        {
            return context.ClassSchedules
                .Include(cs => cs.Group)
                .Include(cs => cs.Teacher)
                .FirstOrDefault(cs => cs.Id == id);
        }

        public void AddSchedule(ClassSchedule schedule)
        {
            context.ClassSchedules.Add(schedule);
            context.SaveChanges();
        }

        public void UpdateSchedule(ClassSchedule schedule)
        {
            context.ClassSchedules.Update(schedule);
            context.SaveChanges();
        }

        public void AddContract(Contract contract)
        {
            context.Contracts.Add(contract);
            context.SaveChanges();
        }
    }
}