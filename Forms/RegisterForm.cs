using System;
using System.Windows.Forms;
using MusicSchoolApp.Models;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm() => InitializeComponent();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Заполните обязательные поля");
                return;
            }

            using (var service = new DataService())
            {
                if (service.IsLoginExists(txtLogin.Text))
                {
                    MessageBox.Show("Логин уже занят");
                    return;
                }

                service.AddUser(new User
                {
                    Surname = txtSurname.Text,
                    Name = txtName.Text,
                    Patronymic = txtPatronymic.Text,
                    Number = txtPhone.Text,
                    Email = txtEmail.Text,
                    Login = txtLogin.Text,
                    Password = txtPassword.Text,
                    RoleId = 8
                });
                MessageBox.Show("Регистрация успешна!");
                Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}