using System;
using System.Linq;
using System.Windows.Forms;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class AddUserForm : Form
    {
        private DataService _service;

        public AddUserForm(DataService service)
        {
            InitializeComponent();
            _service = service;
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Загрузка ролей
                var roles = _service.GetAllRoles();
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "Id";
                cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

                // Загрузка льгот
                var benefits = _service.GetAllBenefits();
                cmbBenefit.DataSource = benefits;
                cmbBenefit.DisplayMember = "BenefitName";
                cmbBenefit.ValueMember = "Id";
                cmbBenefit.DropDownStyle = ComboBoxStyle.DropDownList;

                // Добавляем пустой пункт для льготы
                cmbBenefit.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            return true;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void grpUserInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                // Создание нового пользователя
                var newUser = new Models.User
                {
                    Surname = txtSurname.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Patronymic = txtPatronymic.Text.Trim(),
                    Number = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Login = txtLogin.Text.Trim(),
                    RoleId = (int)cmbRole.SelectedValue,
                    BenefitId = cmbBenefit.SelectedValue != null ? (int?)cmbBenefit.SelectedValue : null
                };

                _service.AddUser(newUser);

                MessageBox.Show("Пользователь успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}