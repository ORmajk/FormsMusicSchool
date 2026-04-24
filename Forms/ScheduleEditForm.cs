using System;
using System.Linq;
using System.Windows.Forms;
using MusicSchoolApp.Models;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class ScheduleEditForm : Form
    {
        private DataService _service;
        private int _scheduleId;
        private ClassSchedule _schedule;

        public ScheduleEditForm(DataService service, int scheduleId = 0)
        {
            InitializeComponent();
            _service = service;
            _scheduleId = scheduleId;
            LoadComboBoxes();
            if (_scheduleId > 0)
                LoadScheduleData();
            else
                this.Text = "Добавление занятия";
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Загрузка групп
                var groups = _service.GetAllGroups();
                if (groups != null && groups.Any())
                {
                    cmbGroup.DataSource = null;  // Сбрасываем перед установкой
                    cmbGroup.DataSource = groups;
                    cmbGroup.DisplayMember = "GroupName";
                    cmbGroup.ValueMember = "Id";
                    cmbGroup.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Нет доступных групп", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Загрузка преподавателей
                var teachers = _service.GetTeachers();


                if (teachers != null && teachers.Any())
                {
                    var teacherList = teachers.Select(t => new
                    {
                        t.Id,
                        FullName = $"{t.Surname?.Trim()} {t.Name?.Trim()} {t.Patronymic?.Trim()}".Trim()
                    }).ToList();

                    cmbTeacher.DataSource = null;  // Сбрасываем
                    cmbTeacher.DataSource = teacherList;
                    cmbTeacher.DisplayMember = "FullName";
                    cmbTeacher.ValueMember = "Id";
                    cmbTeacher.SelectedIndex = -1;

                }

                // Дни недели
                cmbDayOfWeek.Items.Clear();
                cmbDayOfWeek.Items.AddRange(new string[] {
            "Понедельник", "Вторник", "Среда", "Четверг",
            "Пятница", "Суббота", "Воскресенье"
        });
                cmbDayOfWeek.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScheduleData()
        {
            _schedule = _service.GetScheduleById(_scheduleId);
            if (_schedule == null)
            {
                MessageBox.Show("Занятие не найдено", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            this.Text = $"Редактирование занятия: {_schedule.Group?.GroupName}";

            // Выбор группы
            if (_schedule.GroupId.HasValue)
                cmbGroup.SelectedValue = _schedule.GroupId.Value;

            // День недели (int?)
            if (_schedule.DayOfWeek.HasValue)
                cmbDayOfWeek.SelectedIndex = _schedule.DayOfWeek.Value;

            // Время
            dtpStartTime.Value = DateTime.Today.Add(_schedule.StartTime);
            dtpEndTime.Value = DateTime.Today.Add(_schedule.EndTime);

            txtClassroom.Text = _schedule.Classroom ?? "";

            if (_schedule.TeacherId.HasValue)
                cmbTeacher.SelectedValue = _schedule.TeacherId.Value;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                if (_scheduleId == 0)
                    _schedule = new ClassSchedule();

                _schedule.GroupId = (int)cmbGroup.SelectedValue;
                _schedule.DayOfWeek = cmbDayOfWeek.SelectedIndex;  // int, не string
                _schedule.StartTime = dtpStartTime.Value.TimeOfDay;
                _schedule.EndTime = dtpEndTime.Value.TimeOfDay;
                _schedule.Classroom = txtClassroom.Text.Trim();
                _schedule.TeacherId = (int)cmbTeacher.SelectedValue;

                if (_scheduleId == 0)
                    _service.AddSchedule(_schedule);
                else
                    _service.UpdateSchedule(_schedule);

                MessageBox.Show(_scheduleId == 0 ? "Занятие добавлено" : "Занятие обновлено",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (cmbGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите группу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDayOfWeek.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите день недели!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpStartTime.Value.TimeOfDay >= dtpEndTime.Value.TimeOfDay)
            {
                MessageBox.Show("Время начала должно быть меньше времени окончания!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClassroom.Text))
            {
                MessageBox.Show("Введите аудиторию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTeacher.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите преподавателя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}