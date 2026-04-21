using MusicSchoolApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MusicSchoolApp.Forms
{
    public partial class EditUserForm : Form
    {
        private int _userId;
        private DataService _service;
        private bool _isDataChanged = false;

        public EditUserForm(int userId, DataService service)
        {
            InitializeComponent();
            _userId = userId;
            _service = service;
            LoadUserData();
            LoadComboBoxes();
        }

        private void LoadUserData()
        {
            try
            {
                var user = _service.GetUserById(_userId);
                if (user != null)
                {
                    txtSurname.Text = user.Surname;
                    txtName.Text = user.Name;
                    txtPatronymic.Text = user.Patronymic;
                    txtPhone.Text = user.Number;
                    txtEmail.Text = user.Email;
                    txtLogin.Text = user.Login;
                    txtPassword.Text = "";

                    if (user.RoleId.HasValue)
                        cmbRole.SelectedValue = user.RoleId;

                    if (user.BenefitId.HasValue)
                        cmbBenefit.SelectedValue = user.BenefitId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                var roles = _service.GetAllRoles();
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "Id";
                cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

                var benefits = _service.GetAllBenefits();
                cmbBenefit.DataSource = benefits;
                cmbBenefit.DisplayMember = "BenefitName";
                cmbBenefit.ValueMember = "Id";
                cmbBenefit.DropDownStyle = ComboBoxStyle.DropDownList;

                // Добавляем пустой пункт для льготы
                if (benefits.Count > 0)
                {
                    cmbBenefit.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списков: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                    return;

                var user = _service.GetUserById(_userId);
                if (user != null)
                {
                    user.Surname = txtSurname.Text.Trim();
                    user.Name = txtName.Text.Trim();
                    user.Patronymic = txtPatronymic.Text.Trim();
                    user.Number = txtPhone.Text.Trim();
                    user.Email = txtEmail.Text.Trim();
                    user.Login = txtLogin.Text.Trim();

                    user.RoleId = cmbRole.SelectedValue as int?;
                    user.BenefitId = cmbBenefit.SelectedValue as int?;

                    _service.UpdateUser(user);
                    _isDataChanged = true;

                    MessageBox.Show("Данные пользователя успешно сохранены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
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

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
           
                this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры, +, -, пробел и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-' &&
                e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}