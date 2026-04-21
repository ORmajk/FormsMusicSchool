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

            ConfigureDataGridViews();
            LoadAllData();
        }

        private void ConfigureDataGridViews()
        {
            // Удаляем автоматическую привязку событий из дизайнера
            // и настраиваем вручную

            // Настройка dgvUsers
            dgvUsers.CellClick -= DgvUsers_CellClick; // Отписываемся сначала
            dgvUsers.CellClick += DgvUsers_CellClick;

            // Настройка dgvCourses
            dgvCourses.CellClick -= DgvCourses_CellClick;
            dgvCourses.CellClick += DgvCourses_CellClick;

            // Настройка dgvSchedules
            dgvSchedules.CellClick -= DgvSchedules_CellClick;
            dgvSchedules.CellClick += DgvSchedules_CellClick;
        }

        // Отрисовка иконок для кнопок
        private void DgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            PaintButtonCell(e, dgvUsers);
        }

        private void DgvCourses_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            PaintButtonCell(e, dgvCourses);
        }

        private void DgvSchedules_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            PaintButtonCell(e, dgvSchedules);
        }

        private void PaintButtonCell(DataGridViewCellPaintingEventArgs e, DataGridView dgv)
        {
            if (e.RowIndex < 0) return;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string text = e.Value?.ToString() ?? dgv.Columns[e.ColumnIndex].HeaderText;
                Color color = Color.Black;

                if (dgv.Columns[e.ColumnIndex].Name.Contains("Delete"))
                    color = Color.Red;
                else if (dgv.Columns[e.ColumnIndex].Name.Contains("Edit"))
                    color = Color.Blue;

                TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font, e.CellBounds, color,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void LoadAllData()
        {
            LoadUsers();
            LoadCourses();
            LoadSchedules();
        }

        private void AddButtonColumns(DataGridView dgv, string editName, string deleteName)
        {
            try
            {
                // Проверяем, не добавлены ли уже кнопки
                if (!dgv.Columns.Contains(editName))
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                    {
                        Name = editName,
                        HeaderText = "",
                        Text = "✏️",
                        UseColumnTextForButtonValue = true,
                        Width = 40,
                        ToolTipText = "Редактировать"
                    };
                    dgv.Columns.Add(editColumn);
                }

                if (!dgv.Columns.Contains(deleteName))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = deleteName,
                        HeaderText = "",
                        Text = "🗑️",
                        UseColumnTextForButtonValue = true,
                        Width = 40,
                        ToolTipText = "Удалить"
                    };
                    dgv.Columns.Add(deleteColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления кнопок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadUsers()
        {
            try
            {
                var users = service.GetAllUsers();

                dgvUsers.DataSource = null;
                dgvUsers.Columns.Clear();

                if (users == null || !users.Any())
                {
                    dgvUsers.DataSource = null;
                    return;
                }

                var dataSource = users.Select(u => new
                {
                    u.Id,
                    Surname = u.Surname ?? "",
                    Name = u.Name ?? "",
                    Patronymic = u.Patronymic ?? "",
                    Number = u.Number ?? "",
                    Email = u.Email ?? "",
                    Role = u.Role?.RoleName ?? "Н/Д",
                    Login = u.Login ?? ""
                }).ToList();

                dgvUsers.DataSource = dataSource;

                // Скрываем колонку Id
                if (dgvUsers.Columns.Contains("Id"))
                    dgvUsers.Columns["Id"].Visible = false;

                // Настраиваем заголовки
                if (dgvUsers.Columns.Contains("Surname"))
                    dgvUsers.Columns["Surname"].HeaderText = "Фамилия";
                if (dgvUsers.Columns.Contains("Name"))
                    dgvUsers.Columns["Name"].HeaderText = "Имя";
                if (dgvUsers.Columns.Contains("Patronymic"))
                    dgvUsers.Columns["Patronymic"].HeaderText = "Отчество";
                if (dgvUsers.Columns.Contains("Number"))
                    dgvUsers.Columns["Number"].HeaderText = "Телефон";
                if (dgvUsers.Columns.Contains("Email"))
                    dgvUsers.Columns["Email"].HeaderText = "Email";
                if (dgvUsers.Columns.Contains("Role"))
                    dgvUsers.Columns["Role"].HeaderText = "Роль";
                if (dgvUsers.Columns.Contains("Login"))
                    dgvUsers.Columns["Login"].HeaderText = "Логин";

                // Добавляем кнопки
                AddButtonColumns(dgvUsers, "EditUser", "DeleteUser");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            try
            {
                var courses = service.GetAllCourses();

                dgvCourses.DataSource = null;
                dgvCourses.Columns.Clear();

                if (courses == null || !courses.Any())
                {
                    dgvCourses.DataSource = null;
                    return;
                }

                var dataSource = courses.Select(c => new
                {
                    c.Id,
                    Name = c.Name ?? "",
                    c.Price,
                    MinAge = c.MinAge,
                    MaxAge = c.MaxAge ?? 0,
                    DurationMinutes = c.DurationMinutes,
                    CourseType = c.CourseType?.TypeName ?? "Н/Д",
                    Teacher = c.Teacher != null ? $"{c.Teacher.Surname} {c.Teacher.Name}".Trim() : "Н/Д"
                }).ToList();

                dgvCourses.DataSource = dataSource;

                // Скрываем колонку Id
                if (dgvCourses.Columns.Contains("Id"))
                    dgvCourses.Columns["Id"].Visible = false;

                // Настраиваем заголовки
                if (dgvCourses.Columns.Contains("Name"))
                    dgvCourses.Columns["Name"].HeaderText = "Название курса";
                if (dgvCourses.Columns.Contains("Price"))
                    dgvCourses.Columns["Price"].HeaderText = "Цена (руб)";
                if (dgvCourses.Columns.Contains("MinAge"))
                    dgvCourses.Columns["MinAge"].HeaderText = "Мин. возраст";
                if (dgvCourses.Columns.Contains("MaxAge"))
                    dgvCourses.Columns["MaxAge"].HeaderText = "Макс. возраст";
                if (dgvCourses.Columns.Contains("DurationMinutes"))
                    dgvCourses.Columns["DurationMinutes"].HeaderText = "Длительность (мин)";
                if (dgvCourses.Columns.Contains("CourseType"))
                    dgvCourses.Columns["CourseType"].HeaderText = "Тип курса";
                if (dgvCourses.Columns.Contains("Teacher"))
                    dgvCourses.Columns["Teacher"].HeaderText = "Преподаватель";

                // Добавляем кнопки
                AddButtonColumns(dgvCourses, "EditCourse", "DeleteCourse");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки курсов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSchedules()
        {
            try
            {
                var schedules = service.GetAllSchedules();

                dgvSchedules.DataSource = null;
                dgvSchedules.Columns.Clear();

                if (schedules == null || !schedules.Any())
                {
                    dgvSchedules.DataSource = null;
                    return;
                }

                var dataSource = schedules.Select(s => new
                {
                    s.Id,
                    Course = s.Group?.Course?.Name ?? "Н/Д",
                    Group = s.Group?.GroupName ?? "Н/Д",
                    DayOfWeek = s.DayOfWeek ,
                    StartTime = s.StartTime.ToString(@"hh\:mm"),
                    EndTime = s.EndTime.ToString(@"hh\:mm"),
                    Classroom = s.Classroom ?? "Н/Д",
                    Teacher = s.Teacher != null ? $"{s.Teacher.Surname} {s.Teacher.Name}".Trim() : "Н/Д"
                }).ToList();

                dgvSchedules.DataSource = dataSource;

                // Скрываем колонку Id
                if (dgvSchedules.Columns.Contains("Id"))
                    dgvSchedules.Columns["Id"].Visible = false;

                // Настраиваем заголовки
                if (dgvSchedules.Columns.Contains("Course"))
                    dgvSchedules.Columns["Course"].HeaderText = "Курс";
                if (dgvSchedules.Columns.Contains("Group"))
                    dgvSchedules.Columns["Group"].HeaderText = "Группа";
                if (dgvSchedules.Columns.Contains("DayOfWeek"))
                    dgvSchedules.Columns["DayOfWeek"].HeaderText = "День недели";
                if (dgvSchedules.Columns.Contains("StartTime"))
                    dgvSchedules.Columns["StartTime"].HeaderText = "Начало";
                if (dgvSchedules.Columns.Contains("EndTime"))
                    dgvSchedules.Columns["EndTime"].HeaderText = "Конец";
                if (dgvSchedules.Columns.Contains("Classroom"))
                    dgvSchedules.Columns["Classroom"].HeaderText = "Аудитория";
                if (dgvSchedules.Columns.Contains("Teacher"))
                    dgvSchedules.Columns["Teacher"].HeaderText = "Преподаватель";

                // Добавляем кнопки
                AddButtonColumns(dgvSchedules, "EditSchedule", "DeleteSchedule");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики для пользователей
        // Обработчики для пользователей
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex < 0) return;

                var dgv = (DataGridView)sender;

                if (e.ColumnIndex >= dgv.Columns.Count) return;

                var columnName = dgv.Columns[e.ColumnIndex].Name;

                if (!dgv.Columns.Contains("Id"))
                {
                    MessageBox.Show("Колонка Id не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (e.RowIndex >= dgv.Rows.Count) return;

                var idCell = dgv.Rows[e.RowIndex].Cells["Id"];
                if (idCell == null || idCell.Value == null)
                {
                    MessageBox.Show("Невозможно получить ID записи", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = Convert.ToInt32(idCell.Value);

                if (columnName == "EditUser")
                {
                    var editForm = new AddUserForm(service, userId, "Администратор");
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadUsers();
                }
                else if (columnName == "DeleteUser")
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        service.DeleteUser(userId);
                        LoadUsers();
                        MessageBox.Show("Пользователь удален", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex < 0) return;

                var dgv = (DataGridView)sender;

                if (e.ColumnIndex >= dgv.Columns.Count) return;

                var columnName = dgv.Columns[e.ColumnIndex].Name;

                if (!dgv.Columns.Contains("Id"))
                {
                    MessageBox.Show("Колонка Id не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (e.RowIndex >= dgv.Rows.Count) return;

                var idCell = dgv.Rows[e.RowIndex].Cells["Id"];
                if (idCell == null || idCell.Value == null)
                {
                    MessageBox.Show("Невозможно получить ID записи", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int courseId = Convert.ToInt32(idCell.Value);

                if (columnName == "EditCourse")
                {
                    var editForm = new CourseEditForm(adminId, "Администратор", courseId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadCourses();
                }
                else if (columnName == "DeleteCourse")
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить этот курс?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        service.DeleteCourse(courseId, adminId);
                        LoadCourses();
                        MessageBox.Show("Курс удален", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики для расписания
        private void DgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex < 0) return;

                var dgv = (DataGridView)sender;

                // Проверяем, что индекс колонки в допустимых пределах
                if (e.ColumnIndex >= dgv.Columns.Count) return;

                var columnName = dgv.Columns[e.ColumnIndex].Name;

                // Проверяем, что колонка Id существует
                if (!dgv.Columns.Contains("Id"))
                {
                    MessageBox.Show("Колонка Id не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, что строка существует
                if (e.RowIndex >= dgv.Rows.Count) return;

                var idCell = dgv.Rows[e.RowIndex].Cells["Id"];
                if (idCell == null || idCell.Value == null)
                {
                    MessageBox.Show("Невозможно получить ID записи", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int scheduleId = Convert.ToInt32(idCell.Value);

                if (columnName == "EditSchedule")
                {
                    var editForm = new ScheduleEditForm(service, scheduleId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                        LoadSchedules();
                }
                else if (columnName == "DeleteSchedule")
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить это занятие?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        service.DeleteSchedule(scheduleId);
                        LoadSchedules();
                        MessageBox.Show("Занятие удалено", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            var addForm = new AddUserForm(service);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
                MessageBox.Show("Пользователь успешно добавлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddCourse_Click(object sender, EventArgs e)
        {
            var addForm = new CourseEditForm(adminId, "Администратор");
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCourses();
                MessageBox.Show("Курс успешно добавлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddSchedule_Click(object sender, EventArgs e)
        {
            var addForm = new ScheduleEditForm(service);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadSchedules();
                MessageBox.Show("Занятие успешно добавлено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
            MessageBox.Show("Данные обновлены", "Обновление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            service?.Dispose();
            base.OnFormClosed(e);
        }
    }
}