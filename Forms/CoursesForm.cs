using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MusicSchoolApp.Models;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class CoursesForm : Form
    {
        private int userId;
        private string role;
        private List<Course> allCourses;
        private List<Course> cart = new List<Course>();

        public CoursesForm(int userId, string role)
        {
            InitializeComponent();
            this.userId = userId;
            this.role = role;
            LoadCourses();
            SetupFilters();
            if (role != "Студент") btnAddToCart.Visible = false;
        }

        private void LoadCourses()
        {
            using (var service = new DataService())
                allCourses = service.GetAllCourses();
            ApplyFilterAndSort();
        }

        private void SetupFilters()
        {
            var types = allCourses.Select(c => c.CourseType?.TypeName).Distinct().Where(t => t != null).ToList();
            types.Insert(0, "Все");
            cmbType.DataSource = types;
            cmbType.SelectedIndex = 0;
            cmbSortBy.Items.AddRange(new[] { "Название (А-Я)", "Цена (возр.)", "Цена (убыв.)" });
            cmbSortBy.SelectedIndex = 0;
        }

        private void ApplyFilterAndSort()
        {
            var filtered = allCourses.AsEnumerable();
            if (!string.IsNullOrEmpty(txtSearch.Text))
                filtered = filtered.Where(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower()));
            if (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() != "Все")
                filtered = filtered.Where(c => c.CourseType?.TypeName == cmbType.SelectedItem.ToString());
            switch (cmbSortBy.SelectedIndex)
            {
                case 0: filtered = filtered.OrderBy(c => c.Name); break;
                case 1: filtered = filtered.OrderBy(c => c.Price); break;
                case 2: filtered = filtered.OrderByDescending(c => c.Price); break;
            }
            dgvCourses.DataSource = filtered.Select(c => new { c.Id, c.Name, c.Price, Type = c.CourseType?.TypeName, c.MinAge, c.MaxAge, c.DurationMinutes, Teacher = c.Teacher != null ? $"{c.Teacher.Surname} {c.Teacher.Name}" : "" }).ToList();
            dgvCourses.Columns["Id"].Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilterAndSort();
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSort();
        private void numPriceMin_ValueChanged(object sender, EventArgs e) => ApplyFilterAndSort();
        private void numPriceMax_ValueChanged(object sender, EventArgs e) => ApplyFilterAndSort();
        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndSort();

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null) return;
            int id = (int)dgvCourses.CurrentRow.Cells["Id"].Value;
            var course = allCourses.First(c => c.Id == id);
            if (!cart.Contains(course)) cart.Add(course);
            else MessageBox.Show("Курс уже в корзине");
            lblCartCount.Text = $"Корзина: {cart.Count}";
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0) { MessageBox.Show("Корзина пуста"); return; }
            var cartForm = new CartForm(cart, userId);
            if (cartForm.ShowDialog() == DialogResult.OK)
            {
                cart.Clear();
                lblCartCount.Text = "Корзина: 0";
                MessageBox.Show("Курсы добавлены. Проверьте личный кабинет.");
            }
        }

        private void btnCourseDetails_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow == null) return;
            new CourseDetailForm((int)dgvCourses.CurrentRow.Cells["Id"].Value).ShowDialog();
        }

        private void but_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}