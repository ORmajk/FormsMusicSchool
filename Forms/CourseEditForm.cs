using MusicSchoolApp.Models;
using MusicSchoolApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MusicSchoolApp.Forms
{
    public partial class CourseEditForm : Form
    {
        private int courseId, teacherId;
        private DataService service;

        public CourseEditForm(int teacherId, int courseId = 0)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.courseId = courseId;
            service = new DataService();
            LoadCourseTypes();
            if (courseId > 0) LoadCourseData();
        }

        private void LoadCourseTypes()
        {
            var types = service.GetCourseTypes();
            cmbCourseType.DisplayMember = "TypeName";
            cmbCourseType.ValueMember = "Id";
            cmbCourseType.DataSource = types;
        }

        private void LoadCourseData()
        {
            var c = service.GetCourseById(courseId);
            if (c != null && c.TeacherId == teacherId)
            {
                txtName.Text = c.Name;
                numPrice.Value = c.Price;
                numMinAge.Value = c.MinAge;
                numMaxAge.Value = c.MaxAge ?? 0;
                numDuration.Value = c.DurationMinutes;
                cmbCourseType.SelectedValue = c.CourseTypeId;
            }
            else
            {
                MessageBox.Show("Нет прав или курс не найден");
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }
            var course = new Course
            {
                Id = courseId,
                Name = txtName.Text,
                Price = (int)numPrice.Value,
                MinAge = (int)numMinAge.Value,
                MaxAge = numMaxAge.Value == 0 ? (int?)null : (int)numMaxAge.Value,
                DurationMinutes = (int)numDuration.Value,
                CourseTypeId = (int)cmbCourseType.SelectedValue,
                TeacherId = teacherId
            };
            if (courseId == 0) service.AddCourse(course);
            else service.UpdateCourse(course);
            MessageBox.Show(courseId == 0 ? "Курс добавлен" : "Курс обновлён");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numMaxAge_ValueChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            service.Dispose();
            base.OnFormClosed(e);
        }
    }
}