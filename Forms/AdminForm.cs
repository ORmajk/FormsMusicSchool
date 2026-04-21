using MusicSchoolApp.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    public partial class AdminForm : Form
    {
        private int adminId;
        private DataService service;

        public AdminForm(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            service = new DataService();

            ConfigureDataGridView();
            LoadAllCourses();
            LoadUsers();
        }

        private void ConfigureDataGridView()
        {
            // Добавляем кнопки действий для курсов
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                Name = "EditCourse",
                HeaderText = "",
                Text = "✏️ Редактировать",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteCourse",
                HeaderText = "",
                Text = "🗑️ Удалить",
                UseColumnTextForButtonValue = true,
                Width = 100
            };

            dgvCourses.Columns.Add(editColumn);
            dgvCourses.Columns.Add(deleteColumn);

            // Аналогично для пользователей
            DataGridViewButtonColumn editUserColumn = new DataGridViewButtonColumn
            {
                Name = "EditUser",
                HeaderText = "",
                Text = "✏️ Редактировать",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            DataGridViewButtonColumn deleteUserColumn = new DataGridViewButtonColumn
            {
                Name = "DeleteUser",
                HeaderText = "",
                Text = "🗑️ Удалить",
                UseColumnTextForButtonValue = true,
                Width = 100
            };

            dgvUsers.Columns.Add(editUserColumn);
            dgvUsers.Columns.Add(deleteUserColumn);
        }

        private void LoadAllCourses()
        {
            var courses = service.GetAllCourses();
            dgvCourses.DataSource = courses.Select(c => new
            {
                c.Id,
                c.Name,
                c.Price,
                c.MinAge,
                c.MaxAge,
                c.DurationMinutes,
                CourseType = c.CourseType?.TypeName,
                Teacher = $"{c.Teacher?.Surname} {c.Teacher?.Name}".Trim()
            }).ToList();

            if (dgvCourses.Columns.Contains("Id"))
                dgvCourses.Columns["Id"].Visible = false;
        }

        private void LoadUsers()
        {
            var users = service.GetAllUsers();
            dgvUsers.DataSource = users.Select(u => new
            {
                u.Id,
                u.Surname,
                u.Name,
                u.Patronymic,
                u.Number,
                u.Email,
                Role = u.Role?.RoleName,
                u.Login
            }).ToList();

            if (dgvUsers.Columns.Contains("Id"))
                dgvUsers.Columns["Id"].Visible = false;
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int courseId = (int)dgvCourses.Rows[e.RowIndex].Cells["Id"].Value;

            if (e.ColumnIndex == dgvCourses.Columns["EditCourse"].Index)
            {
                // Администратор может редактировать любой курс
                var editForm = new CourseEditForm(adminId, courseId);
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadAllCourses();
            }
            else if (e.ColumnIndex == dgvCourses.Columns["DeleteCourse"].Index)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этот курс?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    service.DeleteCourse(courseId, adminId);
                    LoadAllCourses();
                }
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            // Администратор может создать курс для любого преподавателя
            var addForm = new CourseEditForm(adminId, "Администратор");
            if (addForm.ShowDialog() == DialogResult.OK)
                LoadAllCourses();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllCourses();
            LoadUsers();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            service?.Dispose();
            base.OnFormClosed(e);
        }
    }
}