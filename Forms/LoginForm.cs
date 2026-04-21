using System;
using System.Windows.Forms;
using MusicSchoolApp.Services;

namespace MusicSchoolApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm() => InitializeComponent();


        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var service = new DataService())
            {
                var user = service.GetUserByLoginPassword(txtLogin.Text.Trim(), txtPassword.Text);
                if (user != null)
                {
                    string fullName = $"{user.Surname} {user.Name} {user.Patronymic}".Trim();
                    MainForm main = new MainForm(user.Id, user.Role?.RoleName ?? "Студент", fullName);
                    main.Show();
                }
                else MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }
    }
}