using MusicSchoolApp.Models;
using MusicSchoolApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    public partial class AddUserForm : Form
    {
        private DataService service;
        private int userId;
        private string currentUserRole;

        public AddUserForm(DataService service)
        {
            InitializeComponent();
            this.service = service;
            this.userId = 0;
            this.currentUserRole = "";

            LoadRoles();
            LoadBenefits();
            this.Text = "Добавление нового пользователя";
        }

        public AddUserForm(DataService service, int userId, string currentUserRole)
        {
            InitializeComponent();
            this.service = service;
            this.userId = userId;
            this.currentUserRole = currentUserRole;

            LoadRoles();
            LoadBenefits();
            LoadUserData();
            this.Text = "Редактирование пользователя";
        }

        private void LoadRoles()
        {
            var roles = service.GetAllRoles();
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "Id";
            cmbRole.DataSource = roles;
        }

        private void LoadBenefits()
        {
            var benefits = service.GetAllBenefits();
            benefits.Insert(0, new Benefit { Id = 0, BenefitName = "Нет" });
            cmbBenefit.DisplayMember = "BenefitName";
            cmbBenefit.ValueMember = "Id";
            cmbBenefit.DataSource = benefits;
        }

        private void LoadUserData()
        {
            if (userId > 0)
            {
                var user = service.GetUserById(userId);
                if (user != null)
                {
                    txtSurname.Text = user.Surname;
                    txtName.Text = user.Name;
                    txtPatronymic.Text = user.Patronymic ?? "";
                    txtPhone.Text = user.Number;
                    txtEmail.Text = user.Email ?? "";
                    txtLogin.Text = user.Login;
                    txtPassword.Text = user.Password;
                    cmbRole.SelectedValue = user.RoleId;
                    cmbBenefit.SelectedValue = user.BenefitId ?? 0;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка уникальности логина
            if (userId == 0 && service.IsLoginExists(txtLogin.Text.Trim()))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = new User
                {
                    Id = userId,
                    Surname = txtSurname.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text.Trim(),
                    Number = txtPhone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Login = txtLogin.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    RoleId = (int)cmbRole.SelectedValue,
                    BenefitId = (int)cmbBenefit.SelectedValue == 0 ? (int?)null : (int)cmbBenefit.SelectedValue
                };

                if (userId == 0)
                    service.AddUser(user);
                else
                    service.UpdateUser(user);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удалите методы grpUserInfo_Enter, btnSave_Click_1, btnCancel_Click_1
        // Они не нужны, используйте btnSave_Click и btnCancel_Click
    }
}