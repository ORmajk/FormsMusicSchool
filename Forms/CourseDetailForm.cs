using System;
using System.Linq;
using System.Windows.Forms;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class CourseDetailForm : Form
    {
        public CourseDetailForm(int courseId)
        {
            InitializeComponent();
            using (var service = new DataService())
            {
                var c = service.GetCourseById(courseId);
                if (c != null)
                {
                    lblCourseName.Text = c.Name;
                    lblPrice.Text = $"Цена: {c.Price} руб.";
                    lblAge.Text = $"Возраст: {c.MinAge} - {c.MaxAge} лет";
                    lblDuration.Text = $"Длительность: {c.DurationMinutes} мин";
                    lblType.Text = $"Тип: {c.CourseType?.TypeName}";
                    lblTeacher.Text = $"Преподаватель: {c.Teacher?.Surname} {c.Teacher?.Name}";
                }
            }
        }
    }
}