namespace MusicSchoolApp.Forms
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbBenefit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.GroupBox grpAccessInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPatronymic = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpAccessInfo = new System.Windows.Forms.GroupBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblBenefit = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.cmbBenefit = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpUserInfo.SuspendLayout();
            this.grpAccessInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.lblSurname);
            this.grpUserInfo.Controls.Add(this.lblName);
            this.grpUserInfo.Controls.Add(this.lblPatronymic);
            this.grpUserInfo.Controls.Add(this.lblPhone);
            this.grpUserInfo.Controls.Add(this.lblEmail);
            this.grpUserInfo.Controls.Add(this.txtSurname);
            this.grpUserInfo.Controls.Add(this.txtName);
            this.grpUserInfo.Controls.Add(this.txtPatronymic);
            this.grpUserInfo.Controls.Add(this.txtPhone);
            this.grpUserInfo.Controls.Add(this.txtEmail);
            this.grpUserInfo.Location = new System.Drawing.Point(37, 26);
            this.grpUserInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grpUserInfo.Size = new System.Drawing.Size(345, 162);
            this.grpUserInfo.TabIndex = 0;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "Личная информация";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(13, 23);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(59, 13);
            this.lblSurname.TabIndex = 9;
            this.lblSurname.Text = "Фамилия:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 49);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 13);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Имя:";
            // 
            // lblPatronymic
            // 
            this.lblPatronymic.AutoSize = true;
            this.lblPatronymic.Location = new System.Drawing.Point(13, 75);
            this.lblPatronymic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatronymic.Name = "lblPatronymic";
            this.lblPatronymic.Size = new System.Drawing.Size(57, 13);
            this.lblPatronymic.TabIndex = 11;
            this.lblPatronymic.Text = "Отчество:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(13, 101);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 12;
            this.lblPhone.Text = "Телефон:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 127);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(90, 22);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(2);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(241, 20);
            this.txtSurname.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 48);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(241, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Location = new System.Drawing.Point(90, 74);
            this.txtPatronymic.Margin = new System.Windows.Forms.Padding(2);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(241, 20);
            this.txtPatronymic.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 100);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(241, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 126);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(241, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // grpAccessInfo
            // 
            this.grpAccessInfo.Controls.Add(this.lblLogin);
            this.grpAccessInfo.Controls.Add(this.lblPassword);
            this.grpAccessInfo.Controls.Add(this.lblRole);
            this.grpAccessInfo.Controls.Add(this.lblBenefit);
            this.grpAccessInfo.Controls.Add(this.txtLogin);
            this.grpAccessInfo.Controls.Add(this.txtPassword);
            this.grpAccessInfo.Controls.Add(this.cmbRole);
            this.grpAccessInfo.Controls.Add(this.cmbBenefit);
            this.grpAccessInfo.Location = new System.Drawing.Point(37, 195);
            this.grpAccessInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grpAccessInfo.Name = "grpAccessInfo";
            this.grpAccessInfo.Padding = new System.Windows.Forms.Padding(2);
            this.grpAccessInfo.Size = new System.Drawing.Size(345, 162);
            this.grpAccessInfo.TabIndex = 1;
            this.grpAccessInfo.TabStop = false;
            this.grpAccessInfo.Text = "Доступ и права";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(13, 24);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(13, 50);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Пароль:";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(13, 80);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 13);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "Роль:";
            // 
            // lblBenefit
            // 
            this.lblBenefit.AutoSize = true;
            this.lblBenefit.Location = new System.Drawing.Point(13, 107);
            this.lblBenefit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBenefit.Name = "lblBenefit";
            this.lblBenefit.Size = new System.Drawing.Size(46, 13);
            this.lblBenefit.TabIndex = 10;
            this.lblBenefit.Text = "Льгота:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(90, 22);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(2);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(241, 20);
            this.txtLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 48);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(241, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // cmbRole
            // 
            this.cmbRole.Location = new System.Drawing.Point(90, 77);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(241, 21);
            this.cmbRole.TabIndex = 3;
            // 
            // cmbBenefit
            // 
            this.cmbBenefit.Location = new System.Drawing.Point(90, 105);
            this.cmbBenefit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBenefit.Name = "cmbBenefit";
            this.cmbBenefit.Size = new System.Drawing.Size(241, 21);
            this.cmbBenefit.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(126, 367);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(221, 367);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormsMusicSchool.Properties.Resources.FonNot;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 408);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpAccessInfo);
            this.Controls.Add(this.grpUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового пользователя";
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.grpAccessInfo.ResumeLayout(false);
            this.grpAccessInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPatronymic;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblBenefit;
    }
}