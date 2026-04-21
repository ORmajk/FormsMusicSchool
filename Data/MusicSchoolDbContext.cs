using Microsoft.EntityFrameworkCore;
using MusicSchoolApp.Models;

namespace MusicSchoolApp.Data
{
    public class MusicSchoolDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementType> AchievementTypes { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=music_school;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasColumnName("id_user");
                entity.Property(u => u.Surname).HasColumnName("surname");
                entity.Property(u => u.Name).HasColumnName("name");
                entity.Property(u => u.Patronymic).HasColumnName("patronymic");
                entity.Property(u => u.BenefitId).HasColumnName("id_benefit");
                entity.Property(u => u.ParentId).HasColumnName("id_parent");
                entity.Property(u => u.RoleId).HasColumnName("id_role");
                entity.Property(u => u.Number).HasColumnName("number");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.Login).HasColumnName("login");
                entity.Property(u => u.Password).HasColumnName("password");

                entity.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
                entity.HasOne(u => u.Benefit).WithMany(b => b.Users).HasForeignKey(u => u.BenefitId);
                entity.HasOne(u => u.Parent).WithMany(p => p.Children).HasForeignKey(u => u.ParentId);
            });

            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).HasColumnName("id_role");
                entity.Property(r => r.RoleName).HasColumnName("role");
            });

            // Benefit
            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.ToTable("benefit");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).HasColumnName("id_benefit");
                entity.Property(b => b.BenefitName).HasColumnName("benefit");
            });

            // Parent
            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("parent");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id_parent");
                entity.Property(p => p.Surname).HasColumnName("surname");
                entity.Property(p => p.Name).HasColumnName("name");
                entity.Property(p => p.Number).HasColumnName("number");
                entity.Property(p => p.Email).HasColumnName("email");
            });

            // CourseType (corse_type)
            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.ToTable("corse_type");
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Id).HasColumnName("id_course_type");
                entity.Property(ct => ct.TypeName).HasColumnName("course_type");
            });

            // Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id_course");
                entity.Property(c => c.Name).HasColumnName("name_course");
                entity.Property(c => c.Price).HasColumnName("price");
                entity.Property(c => c.TeacherId).HasColumnName("id_user");
                entity.Property(c => c.MinAge).HasColumnName("min_age");
                entity.Property(c => c.MaxAge).HasColumnName("max_age");
                entity.Property(c => c.DurationMinutes).HasColumnName("duration_course");
                entity.Property(c => c.CourseTypeId).HasColumnName("id_course_type");

                entity.HasOne(c => c.Teacher).WithMany(u => u.Courses).HasForeignKey(c => c.TeacherId);
                entity.HasOne(c => c.CourseType).WithMany(ct => ct.Courses).HasForeignKey(c => c.CourseTypeId);
            });

            // StudyGroup
            modelBuilder.Entity<StudyGroup>(entity =>
            {
                entity.ToTable("study_group");
                entity.HasKey(sg => sg.Id);
                entity.Property(sg => sg.Id).HasColumnName("id_group");
                entity.Property(sg => sg.GroupName).HasColumnName("group_name");
                entity.Property(sg => sg.CourseId).HasColumnName("id_course");
                entity.Property(sg => sg.TeacherId).HasColumnName("id_teacher");
                entity.Property(sg => sg.MaxStudents).HasColumnName("max_students");
                entity.Property(sg => sg.CurrentStudents).HasColumnName("current_students");
                entity.Property(sg => sg.IsActive).HasColumnName("is_active");

                entity.HasOne(sg => sg.Course).WithMany(c => c.StudyGroups).HasForeignKey(sg => sg.CourseId);
                entity.HasOne(sg => sg.Teacher).WithMany().HasForeignKey(sg => sg.TeacherId);
            });

            // ClassSchedule
            modelBuilder.Entity<ClassSchedule>(entity =>
            {
                entity.ToTable("class_schedule");
                entity.HasKey(cs => cs.Id);
                entity.Property(cs => cs.Id).HasColumnName("id_schedule");
                entity.Property(cs => cs.GroupId).HasColumnName("id_group");
                entity.Property(cs => cs.DayOfWeek).HasColumnName("day_of_week");
                entity.Property(cs => cs.StartTime).HasColumnName("start_time");
                entity.Property(cs => cs.EndTime).HasColumnName("end_time");
                entity.Property(cs => cs.Classroom).HasColumnName("classroom");
                entity.Property(cs => cs.TeacherId).HasColumnName("id_user");

                entity.HasOne(cs => cs.Group).WithMany(sg => sg.Schedules).HasForeignKey(cs => cs.GroupId);
                entity.HasOne(cs => cs.Teacher).WithMany(u => u.ClassSchedules).HasForeignKey(cs => cs.TeacherId);
            });

            // GroupMember
            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.ToTable("group_members");
                entity.HasKey(gm => gm.Id);
                entity.Property(gm => gm.Id).HasColumnName("id_group_member");
                entity.Property(gm => gm.GroupId).HasColumnName("id_group");
                entity.Property(gm => gm.StudentId).HasColumnName("id_student");
                entity.Property(gm => gm.JoinDate).HasColumnName("join_date");

                entity.HasOne(gm => gm.Group).WithMany(sg => sg.Members).HasForeignKey(gm => gm.GroupId);
                entity.HasOne(gm => gm.Student).WithMany(u => u.GroupMembers).HasForeignKey(gm => gm.StudentId);
            });

            // Contract
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id_contract");
                entity.Property(c => c.CourseId).HasColumnName("id_course");
                entity.Property(c => c.ContractDate).HasColumnName("contract_date");
                entity.Property(c => c.AmountMonth).HasColumnName("amount_month");
                entity.Property(c => c.UserId).HasColumnName("id_user");
                entity.Property(c => c.Discount).HasColumnName("discount");
                entity.Property(c => c.DiscountSum).HasColumnName("discount_sum");

                entity.HasOne(c => c.Course).WithMany(cr => cr.Contracts).HasForeignKey(c => c.CourseId);
                entity.HasOne(c => c.User).WithMany(u => u.Contracts).HasForeignKey(c => c.UserId);
            });

            // AchievementType
            modelBuilder.Entity<AchievementType>(entity =>
            {
                entity.ToTable("achievement_type");
                entity.HasKey(at => at.Id);
                entity.Property(at => at.Id).HasColumnName("id_achievement_type");
                entity.Property(at => at.TypeName).HasColumnName("achievement_type");
            });

            // Achievement
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("achievement");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).HasColumnName("id_achievement");
                entity.Property(a => a.UserId).HasColumnName("id_user");
                entity.Property(a => a.CourseId).HasColumnName("id_course");
                entity.Property(a => a.AchievementTypeId).HasColumnName("id_achievement_type");
                entity.Property(a => a.AchievementDate).HasColumnName("achievement_date");
                entity.Property(a => a.Description).HasColumnName("description");

                entity.HasOne(a => a.User).WithMany(u => u.Achievements).HasForeignKey(a => a.UserId);
                entity.HasOne(a => a.Course).WithMany(c => c.Achievements).HasForeignKey(a => a.CourseId);
                entity.HasOne(a => a.AchievementType).WithMany(at => at.Achievements).HasForeignKey(a => a.AchievementTypeId);
            });

            // Progress
            modelBuilder.Entity<Progress>(entity =>
            {
                entity.ToTable("progress");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id_progress");
                entity.Property(p => p.StudentId).HasColumnName("id_student");
                entity.Property(p => p.CourseId).HasColumnName("id_course");
                entity.Property(p => p.EvaluationDate).HasColumnName("evaluation_date");
                entity.Property(p => p.SkillLevel).HasColumnName("skill_level");
                entity.Property(p => p.TeacherComment).HasColumnName("teacher_comment");
                entity.Property(p => p.TeacherId).HasColumnName("id_user");

                entity.HasOne(p => p.Student).WithMany(u => u.Progresses).HasForeignKey(p => p.StudentId);
                entity.HasOne(p => p.Course).WithMany(c => c.Progresses).HasForeignKey(p => p.CourseId);
                entity.HasOne(p => p.Teacher).WithMany().HasForeignKey(p => p.TeacherId);
            });
        }
    }
}