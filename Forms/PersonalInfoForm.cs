using System;
using System.Linq;
using System.Windows.Forms;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class PersonalInfoForm : Form
    {
        private int userId;
        private string role;
        private DataService service;

        public PersonalInfoForm(int userId, string role)
        {
            InitializeComponent();
            this.userId = userId;
            this.role = role;
            service = new DataService();
            LoadPersonalInfo();
            if (role == "Студент") LoadStudentData();
            else if (role.Contains("Преподаватель")) LoadTeacherData();
            else LoadAdminData();
        }

        private void LoadPersonalInfo()
        {
            var user = service.GetUserById(userId);
            if (user != null)
            {
                lblName.Text = $"{user.Surname} {user.Name} {user.Patronymic}".Trim();
                lblPhone.Text = user.Number;
                lblEmail.Text = user.Email;
                lblBenefit.Text = user.Benefit?.BenefitName ?? "Нет";
            }
            var ach = service.GetAchievementsByUser(userId);
            dgvAchievements.DataSource = ach.Select(a => new { a.Description, Type = a.AchievementType?.TypeName, a.AchievementDate }).ToList();
        }

        private void LoadStudentData()
        {
            var courses = service.GetStudentCourses(userId);
            dgvCourses.DataSource = courses.Select(c => new
            {
                c.Name,
                c.Price,
                Type = c.CourseType?.TypeName
            }).ToList();

            var schedule = service.GetScheduleForStudent(userId);
            dgvSchedule.DataSource = schedule.Select(s => new
            {
                Course = s.Group?.Course?.Name ?? "Н/Д",
                Group = s.Group?.GroupName ?? "Н/Д",
                s.DayOfWeek,
                s.StartTime,
                s.EndTime,
                s.Classroom
            }).ToList();

            panelTeacherButtons.Visible = false;
        }

        private void LoadTeacherData()
        {
            var courses = service.GetCoursesByTeacher(userId);
            dgvCourses.DataSource = courses.Select(c => new
            {
                c.Id,
                c.Name,
                c.Price,
                Type = c.CourseType?.TypeName,
                c.DurationMinutes
            }).ToList();

            if (dgvCourses.Columns.Contains("Id"))
                dgvCourses.Columns["Id"].Visible = false;

            var schedule = service.GetScheduleForTeacher(userId);
            dgvSchedule.DataSource = schedule.Select(s => new
            {
                Course = s.Group?.Course?.Name ?? "Н/Д",
                Group = s.Group?.GroupName ?? "Н/Д",
                s.DayOfWeek,
                s.StartTime,
                s.EndTime,
                s.Classroom
            }).ToList();

            panelTeacherButtons.Visible = true;
        }

        private void LoadAdminData()
        {
            // Открываем новую форму администратора вместо отображения панели в этой форме

        }
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Преподаватель может добавлять только свои курсы
            var edit = new CourseEditForm(userId, role);  // role = "Преподаватель"
            if (edit.ShowDialog() == DialogResult.OK)
                LoadTeacherData();
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null) return;
            int id = (int)dgvCourses.CurrentRow.Cells["Id"].Value;
            var edit = new CourseEditForm(userId, role, id);
            if (edit.ShowDialog() == DialogResult.OK)
                LoadTeacherData();
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null) return;
            int id = (int)dgvCourses.CurrentRow.Cells["Id"].Value;
            if (MessageBox.Show("Удалить курс?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                service.DeleteCourse(id, userId);
                LoadTeacherData();
                LoadAdminData();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {

        }



        private void butt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAchievements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUsers_Click_1(object sender, EventArgs e)
        {
            try
            {
                var addForm = new AddUserForm(service);
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Новый пользователь успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}