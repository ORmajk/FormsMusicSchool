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
        private int _scheduleId;          // 0 = новый, >0 = редактирование
        private ClassSchedule _schedule;

        public ScheduleEditForm(DataService service, int scheduleId = 0)
        {
            InitializeComponent();
            _service = service;
            _scheduleId = scheduleId;
            LoadComboBoxes();
            if (_scheduleId > 0)
                LoadScheduleData();
        }

        private void LoadComboBoxes()
        {
            // Загрузка групп
            var groups = _service.GetAllGroups();
            cmbGroup.DataSource = groups;
            cmbGroup.DisplayMember = "GroupName";
            cmbGroup.ValueMember = "Id";
            cmbGroup.SelectedIndex = -1;

            // Загрузка преподавателей (роль = Преподаватель)
            var teachers = _service.GetTeachers(); // нужно реализовать в DataService
            cmbTeacher.DataSource = teachers;
            cmbTeacher.DisplayMember = "FullName";
            cmbTeacher.ValueMember = "Id";
            cmbTeacher.SelectedIndex = -1;

            // Дни недели
            cmbDayOfWeek.Items.Clear();
            cmbDayOfWeek.Items.AddRange(new string[] {
                "Понедельник", "Вторник", "Среда", "Четверг",
                "Пятница", "Суббота", "Воскресенье"
            });
            cmbDayOfWeek.SelectedIndex = -1;
        }

        private void LoadScheduleData()
        {
            _schedule = _service.GetScheduleById(_scheduleId);
            if (_schedule == null) return;

            // Выбор группы
            if (_schedule.GroupId.HasValue)
                cmbGroup.SelectedValue = _schedule.GroupId.Value;

            // День недели (индекс 0-6)
            if (_schedule.DayOfWeek.HasValue && _schedule.DayOfWeek.Value >= 0 && _schedule.DayOfWeek.Value <= 6)
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
                if (!ValidateForm()) return;

                if (_scheduleId == 0)
                    _schedule = new ClassSchedule();

                _schedule.GroupId = cmbGroup.SelectedValue as int?;
                _schedule.DayOfWeek = cmbDayOfWeek.SelectedIndex;
                _schedule.StartTime = dtpStartTime.Value.TimeOfDay;
                _schedule.EndTime = dtpEndTime.Value.TimeOfDay;
                _schedule.Classroom = txtClassroom.Text.Trim();
                _schedule.TeacherId = cmbTeacher.SelectedValue as int?;

                if (_scheduleId == 0)
                    _service.AddSchedule(_schedule);
                else
                    _service.UpdateSchedule(_schedule);

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
                MessageBox.Show("Выберите группу!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbDayOfWeek.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите день недели!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpStartTime.Value >= dtpEndTime.Value)
            {
                MessageBox.Show("Время начала должно быть меньше времени окончания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClassroom.Text))
            {
                MessageBox.Show("Введите аудиторию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbTeacher.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите преподавателя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}