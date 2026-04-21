using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicSchoolApp.Models;
using MusicSchoolApp.Data;

namespace MusicSchoolApp.Services
{
    public class DataService : IDisposable
    {
        private readonly MusicSchoolDbContext _context;

        public DataService()
        {
            _context = new MusicSchoolDbContext();
        }

        // --- Users ---
        public User GetUserByLoginPassword(string login, string password)
        {
            // Проверка на null или пустые строки
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return null;

            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public bool IsLoginExists(string login)
        {
            return _context.Users.Any(u => u.Login == login);
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Benefit)
                .FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                // Обработка NULL значений
                user.Patronymic = user.Patronymic ?? string.Empty;
                user.Number = user.Number ?? string.Empty;
                user.Email = user.Email ?? string.Empty;
            }

            return user;
        }

        public void AddUser(User user)
        {
            try
            {
                // Проверка на существование логина
                if (_context.Users.Any(u => u.Login == user.Login))
                {
                    throw new Exception("Пользователь с таким логином уже существует!");
                }

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении пользователя: {ex.Message}");
            }
        }
        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public List<Benefit> GetAllBenefits()
        {
            return _context.Benefits.ToList();
        }

        // --- Courses ---
        public List<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.CourseType).Include(c => c.Teacher).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Include(c => c.CourseType).Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
        }

        public List<Course> GetCoursesByTeacher(int teacherId)
        {
            return _context.Courses.Where(c => c.TeacherId == teacherId).Include(c => c.CourseType).ToList();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCourse(int courseId, int teacherId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId && c.TeacherId == teacherId);
            if (course != null)
            {
                var groups = _context.StudyGroups.Where(g => g.CourseId == courseId).ToList();
                foreach (var g in groups)
                {
                    _context.ClassSchedules.RemoveRange(_context.ClassSchedules.Where(cs => cs.GroupId == g.Id));
                    _context.GroupMembers.RemoveRange(_context.GroupMembers.Where(gm => gm.GroupId == g.Id));
                    _context.StudyGroups.Remove(g);
                }
                _context.Contracts.RemoveRange(_context.Contracts.Where(c => c.CourseId == courseId));
                _context.Progresses.RemoveRange(_context.Progresses.Where(p => p.CourseId == courseId));
                _context.Achievements.RemoveRange(_context.Achievements.Where(a => a.CourseId == courseId));
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public void DeleteSchedule(int scheduleId)
        {
            var schedule = _context.ClassSchedules.Find(scheduleId);
            if (schedule != null)
            {
                _context.ClassSchedules.Remove(schedule);
                _context.SaveChanges();
            }
        }

        // Получение всех групп
        public List<StudyGroup> GetAllGroups()
        {
            return _context.StudyGroups.ToList();
        }

        // Получение расписания по ID
        public ClassSchedule GetScheduleById(int id)
        {
            return _context.ClassSchedules
                .Include(s => s.Group)
                .Include(s => s.Teacher)
                .FirstOrDefault(s => s.Id == id);
        }

        // Добавление нового расписания
        public void AddSchedule(ClassSchedule schedule)
        {
            _context.ClassSchedules.Add(schedule);
            _context.SaveChanges();
        }

        // Обновление расписания
        public void UpdateSchedule(ClassSchedule schedule)
        {
            _context.Entry(schedule).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // --- Contracts & Student courses ---
        public void AddContract(int userId, int courseId, int price)
        {
            var contract = new Contract
            {
                UserId = userId,
                CourseId = courseId,
                ContractDate = DateTime.Now,
                AmountMonth = price.ToString(),
                Discount = false
            };
            _context.Contracts.Add(contract);
            _context.SaveChanges();
        }

        public List<Course> GetStudentCourses(int studentId)
        {
            var contractCourseIds = _context.Contracts.Where(c => c.UserId == studentId).Select(c => c.CourseId).ToList();
            return _context.Courses.Where(c => contractCourseIds.Contains(c.Id)).Include(c => c.CourseType).ToList();
        }

        public List<Contract> GetContractsForStudent(int studentId)
        {
            return _context.Contracts.Where(c => c.UserId == studentId).ToList();
        }

        // --- Achievements ---
        public List<Achievement> GetAchievementsByUser(int userId)
        {
            return _context.Achievements.Include(a => a.AchievementType).Where(a => a.UserId == userId).ToList();
        }

        // --- Schedule ---
        public List<ClassSchedule> GetScheduleForStudent(int studentId)
        {
            var groupIds = _context.GroupMembers.Where(gm => gm.StudentId == studentId).Select(gm => gm.GroupId).ToList();
            return _context.ClassSchedules.Include(cs => cs.Group).ThenInclude(g => g.Course)
                .Where(cs => groupIds.Contains(cs.GroupId.Value)).ToList();
        }

        public List<ClassSchedule> GetScheduleForTeacher(int teacherId)
        {
            return _context.ClassSchedules.Include(cs => cs.Group).ThenInclude(g => g.Course)
                .Where(cs => cs.TeacherId == teacherId).ToList();
        }

        public List<ClassSchedule> GetScheduleForCourse(int courseId)
        {
            var groupIds = _context.StudyGroups.Where(g => g.CourseId == courseId).Select(g => g.Id).ToList();
            return _context.ClassSchedules.Include(cs => cs.Group).Where(cs => groupIds.Contains(cs.GroupId.Value)).ToList();
        }

        // --- Admin data ---
        public List<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }

        public List<Course> GetAllCoursesForAdmin()
        {
            return _context.Courses.Include(c => c.CourseType).Include(c => c.Teacher).ToList();
        }

        public List<ClassSchedule> GetAllSchedulesForAdmin()
        {
            return _context.ClassSchedules.Include(cs => cs.Group).Include(cs => cs.Teacher).ToList();
        }

        public List<CourseType> GetCourseTypes()
        {
            return _context.CourseTypes.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public List<User> GetTeachers()
        {
            return _context.Users
                .Where(u => u.Role.RoleName == "Преподаватель")
                .Select(u => new User
                {
                    Id = u.Id,
                    Surname = u.Surname,
                    Name = u.Name,
                    Patronymic = u.Patronymic
                })
                .ToList();
        }
    }
}