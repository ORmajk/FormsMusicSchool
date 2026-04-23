using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MusicSchoolApp.Models;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля (Фамилия, Имя, Логин, Пароль)",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidName(txtSurname.Text))
            {
                MessageBox.Show("Фамилия должна содержать только буквы (русские или английские), пробел и дефис",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return;
            }

            if (!IsValidName(txtName.Text))
            {
                MessageBox.Show("Имя должно содержать только буквы (русские или английские), пробел и дефис",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPatronymic.Text) && !IsValidName(txtPatronymic.Text))
            {
                MessageBox.Show("Отчество должно содержать только буквы (русские или английские), пробел и дефис",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPatronymic.Focus();
                return;
            }

            if (!IsValidLogin(txtLogin.Text))
            {
                MessageBox.Show("Логин должен быть от 4 до 20 символов и содержать только буквы латиницы, цифры, точку, дефис или подчеркивание",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (!IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show("Пароль должен быть от 6 до 30 символов",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Некорректный формат телефона. Пример: +79161234567 или 89161234567",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Некорректный формат email. Пример: name@domain.com",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (var service = new DataService())
                {
                    if (service.IsLoginExists(txtLogin.Text))
                    {
                        MessageBox.Show("Логин уже занят, выберите другой",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLogin.Focus();
                        return;
                    }

                    service.AddUser(new User
                    {
                        Surname = txtSurname.Text.Trim(),
                        Name = txtName.Text.Trim(),
                        Patronymic = string.IsNullOrWhiteSpace(txtPatronymic.Text) ? null : txtPatronymic.Text.Trim(),
                        Number = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        Login = txtLogin.Text.Trim(),
                        Password = txtPassword.Text,
                        RoleId = 8
                    });

                    MessageBox.Show("Регистрация успешна!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Методы валидации

        /// <summary>
        /// Проверка имени/фамилии/отчества (только буквы, пробел, дефис)
        /// </summary>
        private bool IsValidName(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            // Русские и английские буквы, пробел, дефис, от 2 до 50 символов
            var regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ\-\s]{2,50}$");
            return regex.IsMatch(input.Trim());
        }

        /// <summary>
        /// Проверка логина (латиница, цифры, точка, дефис, подчеркивание, 4-20 символов)
        /// </summary>
        private bool IsValidLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login)) return false;

            var regex = new Regex(@"^[a-zA-Z0-9._-]{4,20}$");
            return regex.IsMatch(login.Trim());
        }

        /// <summary>
        /// Проверка пароля (минимум 6 символов, максимум 30)
        /// </summary>
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            return password.Length >= 6 && password.Length <= 30;
        }

        /// <summary>
        /// Проверка телефона (российский формат)
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            // Убираем все пробелы, скобки и дефисы для чистоты проверки
            var cleaned = Regex.Replace(phone, @"[\s\-\(\)]", "");

            // Проверяем форматы: +79161234567, 89161234567, 9161234567
            var regex = new Regex(@"^(\+7|8)?\d{10}$");
            return regex.IsMatch(cleaned);
        }

        /// <summary>
        /// Проверка email
        /// </summary>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email.Trim());
        }

        #endregion

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}