using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicSchoolApp.Forms
{
    public partial class MainForm : Form
    {
        private int userId;
        private string role;
        public MainForm(int userId, string role, string name)
        {
            InitializeComponent();
            this.userId = userId;
            this.role = role;
            Text = $"Музыкальная школа - {name} ({role})";
            ConfigureInterfaceByRole();
        }
        private void ConfigureInterfaceByRole()
        {
            bool isAdmin = role == "Администратор" || role == "Старший администратор";

            PnlOthersButts.Visible = !isAdmin;

            PnlForAdmin.Visible = isAdmin;

            btnExit.Visible = true;
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            new CoursesForm(userId, role).ShowDialog();
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            if (role != "Администратор" && role != "Старший администратор")
            {
                new PersonalInfoForm(userId, role).ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttAllInfoforAdmin_Click(object sender, EventArgs e)
        {
            new AdminForm(userId).ShowDialog();
        }
    }
}