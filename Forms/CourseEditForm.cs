using MusicSchoolApp.Models;
using MusicSchoolApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MusicSchoolApp.Forms
{
    public partial class CourseEditForm : Form  // ВАЖНО: Наследование от Form
    {
        private int courseId;
        private int currentUserId;
        private string currentUserRole;
        private DataService service;
        private bool isAdmin;

        public CourseEditForm(int currentUserId, string role, int courseId = 0)
        {
            InitializeComponent();
            this.currentUserId = currentUserId;
            this.currentUserRole = role;
            this.courseId = courseId;
            this.isAdmin = role == "Администратор" || role == "Старший администратор";

            service = new DataService();

            LoadCourseTypes();

            // Загружаем список преподавателей только для администратора
            if (isAdmin)
            {
                LoadTeachers();
            }
            else
            {
                lblTeacher.Visible = false;
                cmbTeacher.Visible = false;
            }

            if (courseId > 0)
                LoadCourseData();
            else
                this.Text = "Добавление нового курса";
        }

        private void LoadCourseTypes()
        {
            var types = service.GetCourseTypes();
            cmbCourseType.DisplayMember = "TypeName";
            cmbCourseType.ValueMember = "Id";
            cmbCourseType.DataSource = types;
        }

        private void LoadTeachers()
        {
            try
            {
                // Получаем всех пользователей
                var allUsers = service.GetAllUsers();

                // Фильтруем по ролям с ID от 4 до 7
                var teachers = allUsers
                    .Where(u => u.RoleId >= 4 && u.RoleId <= 7)
                    .Select(u => new
                    {
                        u.Id,
                        FullName = $"{u.Surname} {u.Name} {u.Patronymic}".Trim(),
                        RoleName = u.Role?.RoleName ?? ""
                    })
                    .OrderBy(t => t.FullName)
                    .ToList();

                if (!teachers.Any())
                {
                    MessageBox.Show("Нет доступных преподавателей в системе", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbTeacher.DisplayMember = "FullName";
                cmbTeacher.ValueMember = "Id";
                cmbTeacher.DataSource = teachers;

                // Устанавливаем первый элемент по умолчанию
                if (cmbTeacher.Items.Count > 0)
                    cmbTeacher.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки преподавателей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourseData()
        {
            var course = service.GetCourseById(courseId);
            if (course == null)
            {
                MessageBox.Show("Курс не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Проверяем права доступа
            if (!isAdmin && course.TeacherId != currentUserId)
            {
                MessageBox.Show("У вас нет прав на редактирование этого курса",
                    "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            txtName.Text = course.Name;
            numPrice.Value = course.Price;
            numMinAge.Value = course.MinAge;
            numMaxAge.Value = course.MaxAge ?? 0;
            numDuration.Value = course.DurationMinutes;

            // Выбираем тип курса
            if (course.CourseTypeId > 0)
                cmbCourseType.SelectedValue = course.CourseTypeId;

            // Выбираем преподавателя (только для админа)
            if (isAdmin && course.TeacherId > 0)
            {
                // Проверяем, есть ли такой преподаватель в списке
                if (cmbTeacher.Items.Count > 0)
                {
                    try
                    {
                        cmbTeacher.SelectedValue = course.TeacherId;
                    }
                    catch
                    {
                        // Если преподаватель не найден в списке (например, его роль изменилась)
                        MessageBox.Show("Преподаватель этого курса больше не является преподавателем",
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            this.Text = $"Редактирование курса: {course.Name}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название курса", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourseType.SelectedValue == null)
            {
                MessageBox.Show("Выберите тип курса", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Определяем ID преподавателя
                int teacherId;
                if (isAdmin)
                {
                    if (cmbTeacher.SelectedValue == null)
                    {
                        MessageBox.Show("Выберите преподавателя", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    teacherId = (int)cmbTeacher.SelectedValue;
                }
                else
                {
                    teacherId = currentUserId; // Преподаватель создает курс для себя
                }

                var course = new Course
                {
                    Id = courseId,
                    Name = txtName.Text.Trim(),
                    Price = (int)numPrice.Value,
                    MinAge = (int)numMinAge.Value,
                    MaxAge = numMaxAge.Value == 0 ? (int?)null : (int)numMaxAge.Value,
                    DurationMinutes = (int)numDuration.Value,
                    CourseTypeId = (int)cmbCourseType.SelectedValue,
                    TeacherId = teacherId
                };

                if (courseId == 0)
                    service.AddCourse(course);
                else
                    service.UpdateCourse(course);

                MessageBox.Show(courseId == 0 ? "Курс успешно добавлен" : "Курс успешно обновлен",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении курса: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            service?.Dispose();
            base.OnFormClosed(e);
        }

        private void CourseEditForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}